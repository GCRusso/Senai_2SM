import React, { useEffect, useState } from 'react';
import './HomePage.css'
import Title from "../../Components/Title/Title";
import Banner from "../../Components/Banner/Banner";
import VisionSection from "../../Components/VisionSection/VisionSection";
import MainContent from "../../Components/MainContent/MainContent"
import NextEvent from "../../Components/NextEvent/NextEvent";
import Container from "../../Components/Container/Container"
import ContactSection from "../../Components/ContactSection/ContactSection";
import api, { eventsResource } from '../../Services/Service';
import { nextEventResource } from '../../Services/Service';
import Notification from '../../Components/Notification/Notification';

const HomePage = () => {
    const [notifyUser, setNotifyUser] = useState();
    const [nextEvents, setNextEvents] = useState([]);
    const [previousEvents, setPreviousEvents] = useState([]);
    
    //Roda somente na inicialização do componente
    useEffect(()=>{
        async function getNextEvents(){
            try {
                const promise = await api.get(`${nextEventResource}`);
                const dados = await promise.data;
                const request = await api.get(`${eventsResource}/ListarAnteriores`)

                setPreviousEvents(request.data); //atualiza o previous events

                setNextEvents(dados); //atualiza o state
            } catch (error) {
                setNotifyUser({
                    titleNote:"Erro",
                    textNote:"Nao foi possível carregar os próximos eventos.",
                    imgIcon:"danger",
                    imgAlt: "Imagem uma mulher com um ponto de exclamação na frente.",
                    showMessage: true,
                   });
            }
        }

        getNextEvents();//Roda a função
    },[]);



     //Dados em "mocados"
    // const [nextEvents, setNextEvents] = useState([
    //     { id: 1, title: "Evento X", description: "Evento foi LEGAL!", eventDate: "10/11/2023" },
    //     { id: 2, title: "Evento Z", description: "Evento foi TOP!", eventDate: "13/12/2023" },
    //     { id: 3, title: "Evento U", description: "Evento foi BACANA!", eventDate: "15/12/2023" },
    // ]);

    return (
        <MainContent>
            {<Notification{...notifyUser} setNotifyUser={setNotifyUser} />}
            <Banner />
            <section className="proximos-eventos">
                <Container>
                    <Title titleText={"Proximos Eventos"} />
                    <div className="events-box">
                        {
                            nextEvents.map((e) => {
                                return(
                                    //Necessario puxar os nomes das propriedades la no BD ou pelo swagger
                                    <NextEvent
                                    key={e.idEvento} //Para retirar o Warning, a key precisa de algo unico, como foi passado o ID
                                    title={e.nomeEvento}
                                    description={e.descricao}
                                    eventDate={e.dataEvento}
                                    idEvent={e.idEvento}
                                    linkText={"Conectar"}
                                />
                                )

                            })
                        }

                    </div>
                </Container>
                <Container>
                    <Title titleText={"Eventos anteriores"} />
                    <div className="events-box">
                        {
                            previousEvents.map((e) => {
                                return(
                                    //Necessario puxar os nomes das propriedades la no BD ou pelo swagger
                                    <NextEvent
                                    key={e.idEvento} //Para retirar o Warning, a key precisa de algo unico, como foi passado o ID
                                    title={e.nomeEvento}
                                    description={e.descricao}
                                    eventDate={e.dataEvento}
                                    idEvent={e.idEvento}
                                    linkText={"Detalhes"}
                                />
                                )
                            })
                        }

                    </div>
                </Container>

            </section>
            <VisionSection />
            <ContactSection />
        </MainContent>


    );
};

export default HomePage;