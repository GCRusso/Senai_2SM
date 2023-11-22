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
    const [idEvento, setIdEvento] = useState(null);
    const [showSpinner, setShowSpinner] = useState(false); // Spinner de carregamento
    const [eventos, setEventos] = useState([]); //array
    const [tiposEventos, setTipoEventos] = useState([]);
    const [notifyUser, setNotifyUser] = useState(); // Componente de notificação


    function dePara(retornoApi) {
        let arrayOptions =[];
        retornoApi.forEach(e => {
            arrayOptions.push( {value: e.idTipoEvento, text: e.titulo});
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

    return (
        <div>
            {<Notification{...notifyUser} setNotifyUser={setNotifyUser} />}
            {showSpinner ? <Spinner/> : null}
            <MainContent>
                <section className="cadastro-evento">

                    <Container>
                        <div className='cadastro-evento__box'>
                            <Title titleText="Cadastro de Evento" />

                            <ImageIlustrator altText="teste" imageName={"evento"} />

                            <form className='f-evento'>
                                <Input placeholder={"Nome"} />
                                <Input placeholder={"Descrição"} />
                                <Select
                                    id="select"
                                    name="select-eventos"
                                    options={dePara(tiposEventos)}
                                />
                                <Input
                                placeholder={"dd/mm/aaaa"}
                                id={"data"}
                                type={"date"}
                                />
                                <Button
                                    textButton="Cadastrar"
                                    id={"cadastrar"}
                                    name="cadastrar"
                                    type="submit"
                                />
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
                        />

                    </Container>
                </section>


            </MainContent>

        </div>
    );
};


export default EventosPage;