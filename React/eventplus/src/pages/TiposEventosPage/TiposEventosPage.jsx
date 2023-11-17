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




const TiposEventosPage = () => {
    const [frmEdit, setFrmEdit] = useState(false);
    const [titulo, setTitulo] = useState("");
    const [tipoEventos, setTipoEventos] = useState([]); //array
    const [notifyUser, setNotifyUser] = useState();

    useEffect(() => {

        //Define a chamada em nossa API
        async function loadEventsType() {

            try {
                const retorno = await api.get(eventTypeResource);
                setTipoEventos(retorno.data);

            } catch (error) {
                console.log("Erro na API");
                console.log(error);
            }


        }
        //Chama a função/api no carregamento
        loadEventsType();
    }, []); //Fica observando o array tipoEventos, qualquer mudanca ele chama novamente o array atualizado

    function notify(textNote) {
        setNotifyUser({
            titleNote: "Sucesso",
            textNote,
            imgIcon: "success",
            imgAlt:
                "Imagem de ilustração de sucesso, Moça segurando um balão com simbolo de confirmação OK",
            showMessage: true
        });
    }


    //******************************************* CADASTRO DE DADOS *******************************************/

    async function handleSubmit(e) {
        e.preventDefault(); //Evita o submit do formulário vazio
        if (titulo.trim().length < 3) {
            alert("O Título deve ter pelo menos 3 caracteres")

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
            alert("Deu ruim no SUBMIT!")
        }
    }

    //******************************************* APAGAR DADOS ********************************************/
    async function handleDelete(idElement) {

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
    }



    //******************************************* EDIÇÃO DE DADOS ********************************************/

    //Mostra o formulário de edição
    async function showUpdateForm(idElement) {
        setFrmEdit(true);
        try {
            const retorno = await api.get(`${eventTypeResource}/${idElement}`);
            let tituloEvento = retorno.data.titulo;
            setTitulo(tituloEvento);
            console.log(tituloEvento)
        } catch (error) {
            
        }
    }

    //Cancela a ação de edição (volta para o from cadastro)
    function ediActionAbort() {
        setFrmEdit(false);
        setTitulo("");
    }

    //Cadastra a atualização na API
    async function handleUpdate(e) {

    }



    return (
        <>
            {<Notification{...notifyUser} setNotifyUser={setNotifyUser} />}
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
                                                        type="submit"
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