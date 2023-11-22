import React, { useEffect } from 'react';
import './TiposEventosPage.css'

import Title from "../../Components/Title/Title";
import MainContent from '../../Components/MainContent/MainContent';
import Container from '../../Components/Container/Container';
import ImageIlustrator from '../../Components/ImageIlustrator/ImageIlustrator';
import TableTp from './TableTP/TableTp';
import Notification from '../../Components/Notification/Notification';
import { useState } from 'react';
import { Input, Button } from '../../Components/FormComponents/FormComponents';
import api, { eventTypeResource } from '../../Services/Service'
import Spinner from '../../Components/Spinner/Spinner'

const TiposEventosPage = () => {
    const [frmEdit, setFrmEdit] = useState(false); // Esta em modo de edição?
    const [titulo, setTitulo] = useState("");
    const [tipoEventos, setTipoEventos] = useState([]); //array
    const [notifyUser, setNotifyUser] = useState(); // Componente de notificação
    const [idTipoEvento, setIdTipoEvento] = useState(null); //para editar, por causa do evento
    const [showSpinner, setShowSpinner] = useState(false); // Spinner de carregamento
    

    // ************************ PONTE DE DADOS *********************
    useEffect(() => {
        
        //Define a chamada em nossa API
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
        //Chama a função/api no carregamento
        loadEventsType();
    }, []); //Fica observando o array tipoEventos, qualquer mudanca ele chama novamente o array atualizado

    function notify(textNote) {
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
                titleNote:"Error",
                textNote:"Ocorreu um erro na API, verifique sua conexão com a internet.",
                imgIcon: "danger",
                imgAlt: "Imagem de ilustração de erro.",
                showMessage: true,
            });
        }
    }

    //******************************************* CADASTRO DE DADOS *******************************************

    async function handleSubmit(e) {
        setShowSpinner(true);
        e.preventDefault(); //Evita o submit do formulário vazio

        if (titulo.trim().length < 3) {
           setNotifyUser({
            titleNote:"Aviso",
            textNote:"O Titulo deve ter pelomenos 3 caracteres.",
            imgIcon:"warning",
            imgAlt: "Imagem uma mulher com um ponto de exclamação na frente.",
            showMessage: true,
           });
            return
        }

        try {
            const retorno = await api.post(eventTypeResource, {
                titulo: titulo
            });
            setTitulo(""); // esvazia o campo apos ser cadastrado
            notify('Cadastrado com sucesso!');
            const buscaEventos = await api.get(eventTypeResource);
            setTipoEventos(buscaEventos.data);//Atualiza a variavel
        } catch (error) {
            setNotifyUser({
                titleNote:"Error",
                textNote:"Ocorreu um erro na API, verifique sua conexão com a internet.",
                imgIcon: "danger",
                imgAlt: "Imagem de ilustração de erro.",
                showMessage: true,
            });
        }
        setShowSpinner(false);
    }

    //******************************************* APAGAR DADOS ********************************************/
    async function handleDelete(idElement) {
        setShowSpinner(true);
        //Se não confirma a exclusão, cancela a ação
        if (!window.confirm("Confirma a exclusão?")) {
            return;
        }

        try {
            const promise = await api.delete(`${eventTypeResource}/${idElement}`);

            if (promise.status == 204) {
                notify('Deletado com sucesso!');
                const buscaEventos = await api.get(eventTypeResource);
                setTipoEventos(buscaEventos.data);//Atualiza a variavel
            }

        } catch (error) {
            alert("Deu ruim no DELETE!")
        }
        setShowSpinner(false);
    }


    //******************************************* Mostra o formulário de edição EDIÇÃO DE DADOS /  ********************************************/
    async function showUpdateForm(idElement) {
        setShowSpinner(true);
        setFrmEdit(true);

        try {
            const dados = await api.get(`${eventTypeResource}/${idElement}`);
            let tituloEvento = dados.data.titulo;
            setTitulo(tituloEvento);
            setIdTipoEvento(dados.data.idTipoEvento);
            console.log(dados)
        } catch (error) {
            alert(error)
        }
        setShowSpinner(false);
    }

    // *********************** Cancela a ação de edição (volta para o from cadastro) / EdiActionAbort *****************************
    //
    function ediActionAbort() {
        setShowSpinner(true);
        setFrmEdit(false);
        setTitulo("");
        setIdTipoEvento(null);
        setShowSpinner(false);
    }

    // *********************** Cadastra a atualização na API / handleUpdate *****************************
    async function handleUpdate(e) {
        setShowSpinner(true);
        e.preventDefault();
        try {
            const retorno = await api.put(eventTypeResource + "/" + idTipoEvento, {titulo: titulo});

            if (titulo.trim().length < 3) {
                setNotifyUser({
                 titleNote:"Aviso",
                 textNote:"O Titulo deve ter pelomenos 3 caracteres.",
                 imgIcon:"warning",
                 imgAlt: "Imagem uma mulher com um ponto de exclamação na frente.",
                 showMessage: true,
                });
                 return
             }

            if (retorno.status === 204) {
                const buscaEventos = await api.get(eventTypeResource);
                setTipoEventos(buscaEventos.data);
                setFrmEdit(false);
                setTitulo("");
            }
        } catch (error) {
            alert(error);
        }
        setShowSpinner(false);
    }


    return (
        <>
            {<Notification{...notifyUser} setNotifyUser={setNotifyUser} />}
            {/* Spinner feito com POSITION */}
            {showSpinner ? <Spinner/> : null}

            <MainContent>
                {/* Formulário de cadastro do tipo do eventos*/}
                <section className="cadastro-evento-section">
                    <Container>
                        <div className="cadastro-evento__box">
                            {/* titulo  */}
                            <Title titleText="Cadastro Tipo de Eventos" />

                            {/* imagem de ilustração */}
                            <ImageIlustrator altText="teste" imageName={"tipo-evento"} />

                            {/* Componente de Formulário */}
                            <form
                                className="ftipo-evento"
                                onSubmit={frmEdit ? handleUpdate : handleSubmit}
                            >
                                {/* cadastrar ou editar? */}
                                {
                                    !frmEdit ? (
                                        //CADASTRAR *********************
                                        <>
                                            <Input
                                                id='Titulo'
                                                placeholder='Titulo'
                                                name={"titulo"}
                                                type={"text"}
                                                required={"required"}
                                                value={titulo}
                                                manipulationFunction={(e) => {
                                                    setTitulo(e.target.value);
                                                }}
                                            />

                                            <Button
                                                textButton="Cadastrar"
                                                id={"cadastrar"}
                                                name="cadastrar"
                                                type="submit"
                                            />
                                        </>
                                    )
                                        : (
                                            //EDITAR ********************
                                            <>
                                                <Input
                                                    id='Titulo'
                                                    placeholder='Titulo'
                                                    name={"titulo"}
                                                    type={"text"}
                                                    required={"required"}
                                                    value={titulo}
                                                    manipulationFunction={(e) => {
                                                        setTitulo(e.target.value);
                                                    }}
                                                />
                                                <div className="buttons-editbox">

                                                    <Button
                                                        textButton="Atualizar"
                                                        id={"atualizar"}
                                                        name="atualizar"
                                                        type="button"
                                                        manipulationFunction={handleUpdate}
                                                        additionalClass="button-component--middle"
                                                    />

                                                    <Button
                                                        textButton="Cancelar"
                                                        id={"cancelar"}
                                                        name="cancelar"
                                                        type="button"
                                                        manipulationFunction={ediActionAbort}
                                                        additionalClass="button-component--middle"
                                                    />
                                                </div>
                                            </>
                                        )
                                }
                            </form>
                        </div>
                    </Container>
                </section>

                {/* Listagem do tipo do eventos*/}
                <section className="lista-eventos-section">
                    <Container>
                        <Title titleText={'Lista Tipo de Eventos'} color={"white"} />

                        <TableTp
                            dados={tipoEventos}
                            fnUpdate={showUpdateForm}
                            fnDelete={handleDelete}
                        />

                    </Container>
                </section>
            </MainContent>
        </>
    );
};

export default TiposEventosPage;