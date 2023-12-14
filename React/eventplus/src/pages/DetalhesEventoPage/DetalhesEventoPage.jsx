import React, { useEffect, useState } from 'react';
import Title from '../../Components/Title/Title';
import Container from '../../Components/Container/Container';
import MainContent from '../../Components/MainContent/MainContent';
import Spinner from '../../Components/Spinner/Spinner';
import Notification from '../../Components/Notification/Notification';
import api, { detailsEventResource, eventsResource, myComentaryResource, commentaryEventResource, eventTypeResource } from "../../Services/Service";
import './DetalhesEventoPage.css'
import Table from "./TableDe/TableDe";
import { Input, Button, Select } from "../../Components/FormComponents/FormComponents"
import { dateFormatDbToView } from '../Utils/stringFunctions';
import { useParams } from 'react-router-dom';

const DetalhesEventoPage = () => {

    const { idEvento } = useParams();

    const [evento, setEvento] = useState({})

    const [comentario, setComentario] = useState([]);

    const [tipo, setTipo] = useState({});

    async function getType(){
        try {
            const tipoAqui = await api.get(`${eventTypeResource}/${evento.idTipoEvento}`)
            setTipo(tipoAqui.data)
        } catch (error) {
            alert("Erro ao buscar o Tipo do evento!")
        }
    }

    async function getEvent() {
        try {
            const eventoAqui = await api.get(`${eventsResource}/${idEvento}`);
            const comentario = await api.get(`${commentaryEventResource}/ListarSomenteExibe${idEvento}`)

            setEvento(eventoAqui.data);
            setComentario(comentario.data)
            
        } catch (error) {
            alert("Erro ao buscar evento!")
        }
    }

    useEffect(() => {
        getEvent();
        getType();
    }, []);

    return (
        <>
            <MainContent>
                <section>
                    <Container>
                        <div>
                            <Title titleText={"Detalhes Evento"} />
                            <Table
                                evento={evento}
                                comentario={comentario}
                                tipo={tipo}
                            />
                        </div>
                    </Container>
                </section>
            </MainContent>
        </>
    );
};

export default DetalhesEventoPage;