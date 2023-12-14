import React, { useEffect, useState } from 'react';
import Title from '../../Components/Title/Title';
import Container from '../../Components/Container/Container';
import MainContent from '../../Components/MainContent/MainContent';
import Spinner from '../../Components/Spinner/Spinner';
import Notification from '../../Components/Notification/Notification';
import api, { detailsEventResource, eventsResource, eventTypeResource, myComentaryResource } from "../../Services/Service";
import './DetalhesEventoPage.css'
import Table from "./TableDe/TableDe";
import { Input, Button, Select } from "../../Components/FormComponents/FormComponents"
import { dateFormatDbToView } from '../Utils/stringFunctions';
import { useParams } from 'react-router-dom';

const DetalhesEventoPage = () => {

    const {idEvento} = useParams();

    const [nome, setNome] = useState("");
    const [descricao, setDescricao] = useState("");
    const [tipo, setTipo] = useState("");
    const [data, setData] = useState("");
    const [evento, setEvento] = useState([]);

    const [comentario, setComentario] = useState("");

    useEffect(() => {
        async function getEvent(id) {
            try {
                const eventoAqui = await api.get(`${eventsResource}/${idEvento}`);
                const tipoAqui = await api.get(`${eventTypeResource}/${eventoAqui.data.idTipoEvento}`)
                const comentario = await api.get(`${myComentaryResource}/${id}`)
                setNome(eventoAqui.data.nomeEvento);
                setDescricao(eventoAqui.data.descricao);
                setTipo(tipoAqui.data.titulo);
                setData(dateFormatDbToView(eventoAqui.data.dataEvento));
                setComentario(comentario.data);
                setEvento(eventoAqui.data);

            } catch (error) {
                alert("Erro ao buscar evento!")
            }
        }
        getEvent(idEvento);
    }, []);

    return (
        <>
            <MainContent>
                <section>
                    <Container>
                        <div>
                            <Title titleText={"Detalhes Evento"} />
                            <Table
                                nome={nome}
                                descricao={descricao}
                                tipo={tipo}
                                data={data}
                                comentario={comentario}  
                            />
                            <p>{evento.nomeEvento}</p>
                        </div>
                    </Container>
                </section>
            </MainContent>
        </>
    );
};

export default DetalhesEventoPage;