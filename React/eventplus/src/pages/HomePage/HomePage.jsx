import React, { useEffect, useState } from 'react';
import './HomePage.css'
import Title from "../../Components/Title/Title";
import Banner from "../../Components/Banner/Banner";
import VisionSection from "../../Components/VisionSection/VisionSection";
import MainContent from "../../Components/MainContent/MainContent"
import NextEvent from "../../Components/NextEvent/NextEvent";
import Container from "../../Components/Container/Container"
import ContactSection from "../../Components/ContactSection/ContactSection";
import api from '../../Services/Service';
import { nextEventResource } from '../../Services/Service';

const HomePage = () => {

    const [nextEvents, setNextEvents] = useState([]);
    
    //Roda somente na inicialização do componente
    useEffect(()=>{
        async function getNextEvents(){
            try {
                const promise = await api.get(`${nextEventResource}`);
                const dados = await promise.data;

                setNextEvents(dados); //atualiza o state
            } catch (error) {
                alert ("Deu ruim na api!")
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