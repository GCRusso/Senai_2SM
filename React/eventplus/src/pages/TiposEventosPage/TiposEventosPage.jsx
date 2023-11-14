import React, { useEffect } from 'react';
import './TiposEventosPage.css'

import Title from "../../Components/Title/Title";
import MainContent from '../../Components/MainContent/MainContent';
import Container from '../../Components/Container/Container';
import ImageIlustrator from '../../Components/ImageIlustrator/ImageIlustrator';
import TableTp from './TableTP/TableTp';
import { useState } from 'react';
import { Input, Button } from '../../Components/FormComponents/FormComponents';
import api, { eventTypeResource } from '../../Services/Service'


const TiposEventosPage = () => {
    const [frmEdit, setFrmEdit] = useState(false);
    const [titulo, setTitulo] = useState("");
    const [tipoEventos, setTipoEventos] = useState([]);

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
    }, []);


    async function handleSubmit(e) {
        e.preventDefault(); //Evita o submit do formulário vazio
        if (titulo.trim().length <= 3) {
            alert("O Título deve ter pelo menos 3 caracteres")
        }

        try {
            const retorno = await api.post(eventTypeResource, {
                titulo: titulo
            });
            setTitulo(""); // esvazia o campo apos ser cadastrado
            alert("Cadastrado com sucesso!")
        } catch (error) {
            alert("Deu ruim no SUBMIT!")
        }
    }


    function handleUpdate() {
        alert('Bora Editar');
    }

    //Cancela a ação de edição (volta para o from cadastro)
    function ediActionAbort() {
        alert("Cancelar a tela de edição de dados")
    }

    //Apaga o evento na API
    function handleDelete(idElement) {
        alert(`Vamos apagar o evento de id: ${idElement}`);
    }

    //Mostra o formulário de edição
    function showUpdateForm() {
        alert('Vamos mostrar o formulário de edição');
    }

    return (
        <>
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
                                        //Cadastrar 
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
                                                textButton='Cadastrar'
                                                id="cadastrar"
                                                name="cadastrar"
                                                type="submit"

                                            />
                                        </>
                                    )
                                        : (
                                            //Editar
                                            <p>Tela de Edição</p>
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