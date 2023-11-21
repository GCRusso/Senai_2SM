import React from 'react';
import './EventosPage.css'
import Title from '../../Components/Title/Title';
import TableEvent from './TableEvent/TableEvent';
import MainContent from '../../Components/MainContent/MainContent';
import Container from '../../Components/Container/Container';
import ImageIlustrator from '../../Components/ImageIlustrator/ImageIlustrator'
import { Button, Input, Select, Label } from '../../Components/FormComponents/FormComponents'



const EventosPage = () => {
    return (
        <div>
            <MainContent>
                <section className="cadastro-evento">

                    <Container>
                        <div className='cadastro-evento__box'>
                            <Title titleText="Cadastro de Evento" />

                            <ImageIlustrator altText="teste" imageName={"evento"} />

                            <form className='f-evento'>
                                <Input />
                                <Input />
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

                {/* Listagem dos Eventos*/}
                <section className="lista-eventos-section">
                    <Container>
                        <Title titleText={'Lista de Eventos'} color={"white"} />

                        <TableEvent />

                    </Container>
                </section>


            </MainContent>

        </div>
    );
};

export default EventosPage;