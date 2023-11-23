import React, { useEffect, useState } from 'react';
import './EventosPage.css'
import api, { eventsResource, eventTypeResource } from '../../Services/Service'

import Spinner from '../../Components/Spinner/Spinner'
import Title from '../../Components/Title/Title';
import TableEvent from './TableEvent/TableEvent';
import MainContent from '../../Components/MainContent/MainContent';
import Container from '../../Components/Container/Container';
import ImageIlustrator from '../../Components/ImageIlustrator/ImageIlustrator';
import Notification from '../../Components/Notification/Notification';

import { Button, Input, Select, Label } from '../../Components/FormComponents/FormComponents'

const EventosPage = () => {
    const [frmEdit, setFrmEdit] = useState(false);//esta em modo de edicao
    const [showSpinner, setShowSpinner] = useState(false); // Spinner de carregamento
    const [eventos, setEventos] = useState([]); //array
    const [tiposEventos, setTipoEventos] = useState([]);
    const [notifyUser, setNotifyUser] = useState(); // Componente de notificação
    const [nomeEvento, setNomeEvento] = useState("");
    const [descricao, setDescricao] = useState("");
    const [dataEvento, setDataEvento] = useState(null);
    const [idTipoEvento, setIdTipoEvento] = useState('');
    const [idEvento, setIdEvento] = useState(null);
    const idInstituicao = "6ec00127-94c1-43d3-a391-3935cfda4ddf";


    function dePara(retornoApi) {
        let arrayOptions = [];
        retornoApi.forEach(e => {
            arrayOptions.push({ value: e.idTipoEvento, text: e.titulo });
        });
        return arrayOptions;
    }

    // ************************ PONTE DE DADOS EVENTOS *********************
    useEffect(() => {
        async function loadEvents() {
            setShowSpinner(true);
            try {
                const retorno = await api.get(eventsResource);
                setEventos(retorno.data);

            } catch (error) {
                console.log(error);
            }
            setShowSpinner(false);
        }
        loadEvents();
    }, []);


    // ************************ PONTE DE DADOS TIPO EVENTOS *********************
    useEffect(() => {
        async function loadEventsType() {
            setShowSpinner(true);
            try {
                const retorno = await api.get(eventTypeResource);
                setTipoEventos(retorno.data);

            } catch (error) {
                console.log(error);
            }
            setShowSpinner(false);
        }
        loadEventsType();
    }, []);

    //************************ NOTIFICAÇÃO *********************
    function notify(textNote) {
        setShowSpinner(true);
        try {
            setNotifyUser({
                titleNote: "Sucesso",
                textNote,
                imgIcon: "success",
                imgAlt:
                    "Imagem de ilustração de sucesso, Moça segurando um balão com simbolo de confirmação OK",
                showMessage: true
            });
        }

        catch (error) {
            setNotifyUser({
                titleNote: "Error",
                textNote: "Ocorreu um erro na API, verifique sua conexão com a internet.",
                imgIcon: "danger",
                imgAlt: "Imagem de ilustração de erro.",
                showMessage: true,
            });
            setShowSpinner(false);
        }
    }

    //******************************************* APAGAR DADOS ********************************************/
    async function handleDelete(idElement) {
        setShowSpinner(true);
        if (!window.confirm("Confirma a exclusão?")) {
            return;
        }

        try {
            const promise = await api.delete(`${eventsResource}/${idElement}`);

            if (promise.status == 204) {
                notify('Deletado com sucesso!');
                const buscaEventos = await api.get(eventsResource);
                setEventos(buscaEventos.data);//Atualiza a variavel
            }

        } catch (error) {
            alert("Deu ruim no DELETE!")
        }

        setShowSpinner(false);
    }

    //******************************************* CADASTRO DE DADOS *******************************************

    async function handleSubmit(e) {
        setShowSpinner(true);
        e.preventDefault(); //Evita o submit do formulário vazio

        try {
            const retorno = await api.post(eventsResource, {
                nomeEvento: nomeEvento,
                descricao: descricao,
                tiposEventos: tiposEventos,
                idInstituicao: idInstituicao,
                dataEvento: dataEvento,
                idTipoEvento: idTipoEvento

            });

            notify('Cadastrado com sucesso!');

        } catch (error) {
            setNotifyUser({
                titleNote: "Error",
                textNote: "Ocorreu um erro na API, verifique sua conexão com a internet.",
                imgIcon: "danger",
                imgAlt: "Imagem de ilustração de erro.",
                showMessage: true,
            });
        }

        const buscaEventos = await api.get(eventsResource);
        setEventos(buscaEventos.data);//Atualiza a variavel

        setNomeEvento(""); // esvazia o campo apos ser cadastrado
        setDescricao(""); // esvazia o campo apos ser cadastrado
        setDataEvento("");

        setShowSpinner(false);
    }


    //******************************************* MOSTRAR FORMULARIO DE EDICAO *******************************************

    async function showUpdateForm(idElement) {
        setShowSpinner(true);
        setFrmEdit(true)
        try {
            const promise = await api.get(`${eventsResource}/${idElement}`, { idElement })
            setDataEvento(promise.data.dataEvento.slice(0, 10))
            setNomeEvento(promise.data.nomeEvento)
            setDescricao(promise.data.descricao)
            setIdTipoEvento(promise.data.idTipoEvento)

        } catch (error) {
            alert('erro')
        }
        setShowSpinner(false);
    }


    // *********************** Cancela a ação de edição (volta para o from cadastro) / EdiActionAbort *****************************
    function editActionAbort() {
        setShowSpinner(true);
        setFrmEdit(false);
        setNomeEvento(""); // esvazia o campo apos ser cadastrado
        setDescricao(""); // esvazia o campo apos ser cadastrado
        setDataEvento("");
        setIdTipoEvento(null);
        setShowSpinner(false);
    }


    //******************************************* ATUALIZAR CADASTRO *******************************************
    async function handleUpdate(e) {
        setShowSpinner(true);
        e.preventDefault();
        try {
            const retorno = await api.put(eventsResource + "/" + idEvento, { 
                nomeEvento: nomeEvento,
                descricao: descricao,
                idTipoEvento: idTipoEvento,
                dataEvento: dataEvento,
                idInstituicao: idInstituicao,
            });

            if (retorno.status === 204) {
                const buscaEventos = await api.get(eventsResource);
                setEventos(buscaEventos.data);
                setFrmEdit(false);
                setNomeEvento("");
                setDescricao(""); 
                setDataEvento("");
            }
        } catch (error) {
            alert(error);
        }
        setShowSpinner(false);

    }


    //Funcao titulo tipo ***************************************
    function tituloTipo(tipoEventos) {
        let arrayOptions = []

        tipoEventos.forEach(element => {
            arrayOptions.push({ value: element.idTipoEvento, text: element.titulo })
        })
        return arrayOptions
    }



    return (
        <div>
            {<Notification{...notifyUser} setNotifyUser={setNotifyUser} />}
            {showSpinner ? <Spinner /> : null}
            <MainContent>
                <section className="cadastro-evento">

                    <Container>
                        <div className='cadastro-evento__box'>
                            <Title titleText="Cadastro de Evento" />

                            <ImageIlustrator altText="teste" imageName={"evento"} />

                            {/*************** CADASTRAR **************/}
                            <form className='f-evento' onSubmit={frmEdit ? handleUpdate : handleSubmit}>
                                {
                                    !frmEdit ?
                                        (
                                            <>
                                                <Input
                                                    id='Nome'
                                                    type={'text'}
                                                    placeholdder={'Nome'}
                                                    name={'nome'}
                                                    required={'required'}
                                                    value={nomeEvento}
                                                    manipulationFunction={(e) => {
                                                        setNomeEvento(e.target.value)
                                                    }}
                                                />

                                                <Input
                                                    id='Descricao'
                                                    type={'text'}
                                                    placeholdder={'Descrição'}
                                                    name={'descricao'}
                                                    required={'required'}
                                                    value={descricao}
                                                    manipulationFunction={(e) => {
                                                        setDescricao(e.target.value)
                                                    }}
                                                />

                                                <Select
                                                    id='TiposEvento'
                                                    name={'tiposEvento'}
                                                    required={'required'}
                                                    options={tituloTipo(tiposEventos)}
                                                    value={idTipoEvento}
                                                    manipulationFunction={(e) => {
                                                        setIdTipoEvento(e.target.value)
                                                    }}
                                                />

                                                <Input
                                                    id='dataEvento'
                                                    type={'date'}
                                                    placeholdder={'dd/mm/aaaa'}
                                                    name={'Data'}
                                                    required={'required'}
                                                    value={dataEvento}
                                                    manipulationFunction={(e) => {
                                                        setDataEvento(e.target.value)
                                                    }}
                                                />

                                                <Button
                                                    textButton="Cadastrar"
                                                    id="cadastrar"
                                                    name="cadastrar"
                                                    //formulário só será chamado pois seu type é submit
                                                    type="submit"
                                                />
                                            </>
                                        ) :
                                        <>
                                            <Input
                                                id='Nome'
                                                type={'text'}
                                                placeholdder={'Nome'}
                                                name={'nome'}
                                                required={'required'}
                                                value={nomeEvento}
                                                manipulationFunction={(e) => {
                                                    setNomeEvento(e.target.value)
                                                }}
                                            />

                                            <Input
                                                id='Descricao'
                                                type={'text'}
                                                placeholdder={'Descrição'}
                                                name={'descricao'}
                                                required={'required'}
                                                value={descricao}
                                                manipulationFunction={(e) => {
                                                    setDescricao(e.target.value)
                                                }}
                                            />

                                            <Select
                                                id='TiposEventos'
                                                name={'tiposEvento'}
                                                required={'required'}
                                                options={tituloTipo(tiposEventos)}
                                                value={idTipoEvento}
                                                manipulationFunction={(e) => {
                                                    setIdTipoEvento(e.target.value)
                                                }}
                                            />

                                            <Input
                                                id='dataEvento'
                                                type={'date'}
                                                placeholdder={'dd/mm/aaaa'}
                                                name={'Data'}
                                                required={'required'}
                                                value={dataEvento}
                                                manipulationFunction={(e) => {
                                                    setDataEvento(e.target.value)
                                                }}
                                            />

                                            <div className="buttons-editbox">
                                                <Button
                                                    textButton="Atualizar"
                                                    id="atualizar"
                                                    name="atualizar"
                                                    //formulário só será chamado pois seu type é submit
                                                    type="submit"
                                                    addtionalClass="button-component--middle"
                                                />

                                                <Button
                                                    textButton="Cancelar"
                                                    id="cancelar"
                                                    name="cancelar"
                                                    //formulário só será chamado pois seu type é submit
                                                    type="submit"
                                                    manipulationFunction={editActionAbort}
                                                    addtionalClass="button-component--middle"
                                                />
                                            </div>

                                        </>
                                }

                            </form>
                        </div>
                    </Container>
                </section>

                {/* Tabela Listagem dos Eventos*/}
                <section className="lista-eventos-section">
                    <Container>
                        <Title titleText={'Lista de Eventos'} color={"white"} />

                        <TableEvent
                            dados={eventos}
                            fnDelete={handleDelete}
                            fnUpdate={showUpdateForm}
                        />

                    </Container>
                </section>
            </MainContent>

        </div>
    );
};


export default EventosPage;