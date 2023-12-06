import React, { useContext, useEffect, useState } from "react";
import Header from "../../Components/Header/Header";
import MainContent from "../../Components/MainContent/MainContent";
import Title from "../../Components/Title/Title";
import Table from "./TableEvA/TableEvA";
import Container from "../../Components/Container/Container";
import { Select } from "../../Components/FormComponents/FormComponents";
import Spinner from "../../Components/Spinner/Spinner";
import Modal from "../../Components/Modal/Modal";
import api, { eventsResource, myEventsResource, presencesEventResource } from "../../Services/Service";


import "./EventosAlunoPage.css";
import { UserContext } from "../../context/AuthContext"

const EventosAlunoPage = () => {
    // state do menu mobile
    const [exibeNavbar, setExibeNavbar] = useState(false);

    const [eventos, setEventos] = useState([]);

    // select mocado
    const [quaisEventos, setQuaisEventos] = useState([
        { value: 1, text: "Todos os eventos" },
        { value: 2, text: "Meus eventos" },
    ]);

    const [tipoEvento, setTipoEvento] = useState("1"); //código do tipo do Evento escolhido

    const [showSpinner, setShowSpinner] = useState(false);
    const [showModal, setShowModal] = useState(false);

    // recupera os dados globais do usuário
    const { userData, setUserData } = useContext(UserContext);


    //*****Listar meus eventos e todos eventos******
    useEffect(() => {
        async function loadEventsType() {
            setShowSpinner(true);
            // setEventos([]); //Zera o array de eventos

            if (tipoEvento === "1") {//Chama todos os eventos

                try {
                    const todosEventos = await api.get(eventsResource);
                    const meusEventos = await api.get(
                        `${myEventsResource}/${userData.userId}`
                    );

                    const eventosMarcados = verificaPresenca(todosEventos.data, meusEventos.data);
                    setEventos(eventosMarcados);

                    console.clear();
                    console.log("TODOS OS EVENTOS: ")
                    console.log(todosEventos.data);
                    console.log("MEUS EVENTOS: ")
                    console.log(meusEventos.data);
                    console.log("EVENTOS MARCADOS: ")
                    console.log(eventosMarcados);

                } catch (error) {
                    console.log("ERRO na API");
                    console.log(error);
                }
            }
            else if (tipoEvento === "2") {
                try {
                    const retornoEventos = await api.get(`${myEventsResource}/${userData.userId}`);
                    console.log(retornoEventos.data);

                    const arrEventos = [];//array vazio

                    retornoEventos.data.forEach(e => {
                        arrEventos.push({ ...e.evento, situacao: e.situacao });
                    });

                    setEventos(arrEventos);

                } catch (error) {
                    console.log("ERRO NA API");
                    console.log(error);
                }
            }
            //Deixamos o select com o "selecione o tipo do evento" com array vazio, para quando ele estiver selecionado não mostrar nada 
            else {
                setEventos([]);
            }
            setShowSpinner(false);
        }
        loadEventsType();
    }, [tipoEvento]);


    const verificaPresenca = (arrAllEvents, eventsUser) => {
        for (let x = 0; x < arrAllEvents.length; x++) { //Para cada evento
            for (let i = 0; i < eventsUser.length; i++) { //procurar a corre
                if (arrAllEvents[x].idEvento === eventsUser[i].idEvento) {
                    arrAllEvents[x].situacao = true;
                    arrAllEvents[x].idPresencaEvento = eventsUser[i].idPresencaEvento;
                    break; //paro de procurar para o evento principal atual
                }
            }
        }
        //Retorna todos os eventos marcados com a presença do usuário
        return arrAllEvents;
    };


    // toggle meus eventos ou todos os eventos
    function myEvents(tpEvent) {
        setTipoEvento(tpEvent);
    }

    async function loadMyComentary(idComentary) {
        return "????";
    }

    const showHideModal = () => {
        setShowModal(showModal ? false : true);
    };

    const commentaryRemove = () => {
        alert("Remover o comentário");
    };

    //CONNECT CONECTAR AO EVENTO *****

    async function handleConnect(eventId, whatTheFunction, presencaId = null) {
        if (whatTheFunction === 'connect') {
            try {

                const promise = await api.post(presencesEventResource, {
                    situacao: true,
                    idUsuario: userData.userId,
                    idEvento: eventId
                }
                );

                if (promise.status === 201) {
                    loadEventsType();
                    alert("Presença confirmada, Parabéns!");
                }

           
            } catch (error) {
                alert(error);
            }
            return;
        }
        console.log(`
        ${whatTheFunction}
        ${presencaId}
        `);

        //UNCONNECTED DESCONECTAR DO EVENTO *****
        try {
            const unconnected = await api.delete(`${presencesEventResource}/${presencaId}`);
            if (unconnected.status === 204) {
                alert("DESCONECTADO DO EVENTO")
                const todosEventos = await api.get(eventsResource);
                loadEventsType();
                setEventos(todosEventos.data);
            }
        } catch (error) {

        }

    }
    return (
        <>
            {/* <Header exibeNavbar={exibeNavbar} setExibeNavbar={setExibeNavbar} /> */}

            <MainContent>
                <Container>
                    <Title titleText={"Eventos"} className="custom-title" />

                    <Select
                        id="id-tipo-evento"
                        name="tipo-evento"
                        required={true}
                        options={quaisEventos} // aqui o array dos tipos
                        manipulationFunction={(e) => myEvents(e.target.value)} // aqui só a variável state
                        defaultValue={tipoEvento}
                        className="select-tp-evento"
                    />

                    <Table
                        dados={eventos}
                        fnConnect={handleConnect}
                        fnShowModal={() => {
                            showHideModal();
                        }}
                    />
                </Container>
            </MainContent>

            {/* SPINNER -Feito com position */}
            {showSpinner ? <Spinner /> : null}

            {showModal ? (
                <Modal
                    userId={userData.userId}
                    showHideModal={showHideModal}
                    fnDelete={commentaryRemove}
                />
            ) : null}
        </>
    );
};

export default EventosAlunoPage;
