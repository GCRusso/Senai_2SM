import React, { useContext, useEffect, useState } from "react";
import Header from "../../Components/Header/Header";
import MainContent from "../../Components/MainContent/MainContent";
import Title from "../../Components/Title/Title";
import Table from "./TableEvA/TableEvA";
import Container from "../../Components/Container/Container";
import { Select } from "../../Components/FormComponents/FormComponents";
import Spinner from "../../Components/Spinner/Spinner";
import Modal from "../../Components/Modal/Modal";
import api from "../../Services/Service";


import "./EventosAlunoPage.css";
import { UserContext } from "../../context/AuthContext"

const EventosAlunoPage = () => {
    // state do menu mobile
    const [exibeNavbar, setExibeNavbar] = useState(false);
    const [eventos, setEventos] = useState([

        { idEvento: "1234", nomeEvento: "Evento de JavaScript", dataEvento: "20/12/2025" },
        { idEvento: "1234", nomeEvento: "Evento de JavaScript", dataEvento: "20/12/2025" },
        { idEvento: "1234", nomeEvento: "Evento de JavaScript", dataEvento: "20/12/2025" }

    ]);
    // select mocado
    const [quaisEventos, setQuaisEventos] = useState([
        { value: 1, text: "Todos os eventos" },
        { value: 2, text: "Meus eventos" },
    ]);

    const [tipoEvento, setTipoEvento] = useState(1); //código do tipo do Evento escolhido
    const [showSpinner, setShowSpinner] = useState(false);
    const [showModal, setShowModal] = useState(false);

    // recupera os dados globais do usuário
    const { userData, setUserData } = useContext(UserContext);

    useEffect(() => {
        loadEventsType();
    }, [tipoEvento]);

    async function loadEventsType() { 
            
    }

    setShowSpinner(true);
    if (tipoEvento == 1) {//Chama todos os eventos

    }
    else { }
    setShowSpinner(false);











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

    function handleConnect() {
        alert("Desenvolver a função conectar evento");
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
                        onChange={(e) => myEvents(e.target.value)} // aqui só a variável state
                        defaultValue={tipoEvento}
                        additionalClass="select-tp-evento"
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