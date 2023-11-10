import React from 'react';
import './TiposEventosPage.css'
import Title from "../../Components/Title/Title";
import MainContent from '../../Components/MainContent/MainContent';
import Container from '../../Components/Container/Container';
import ImageIlustrator from '../../Components/ImageIlustrator/ImageIlustrator';

const TiposEventosPage = () => {
    return (
            <>
            <MainContent>
                <section className="cadastro-evento-section">
                    <Container>
                        <div className="cadastro-evento-box">
                            {/* titulo  */}
                            <Title titleText="Cadastro Tipo de Eventos" />

                            {/* imagem de ilustração */}
                            <ImageIlustrator />

                            {/* Componente de Formulário */}
                            <form className="ftipo-evento">
                                <p>Formulário Será criado aqui</p>
                            </form>
                        </div>
                    </Container>
                </section>
            </MainContent>
        </>
    );
};

export default TiposEventosPage;