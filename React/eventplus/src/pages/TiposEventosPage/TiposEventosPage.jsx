import React from 'react';
import './TiposEventosPage.css'
import Title from "../../Components/Title/Title";
import MainContent from '../../Components/MainContent/MainContent';
import Container from '../../Components/Container/Container';
import ImageIlustrator from '../../Components/ImageIlustrator/ImageIlustrator';
import { useState } from 'react';

const TiposEventosPage = () => {
    const [frmEdit, setFrmEdit] = useState(false);

    function handleSubmit() {
        alert('Bora Editar2');
    }

    function handleUpdate(){
        alert('Bora Editar');
    }
    return (
            <>
            <MainContent>
                <section className="cadastro-evento-section">
                    <Container>
                        <div className="cadastro-evento__box">
                            {/* titulo  */}
                            <Title titleText="Cadastro Tipo de Eventos" />

                            {/* imagem de ilustração */}
                            <ImageIlustrator altText="teste" imageName={"tipo-evento"}/>

                            {/* Componente de Formulário */}
                            <form 
                            className="ftipo-evento"
                            onSubmit={frmEdit ? handleUpdate : handleSubmit}
                            >
                            {/* cadastrar ou editar? */}
                            {
                                !frmEdit? (<p>Tela de Cadastro</p>) : (<p>Tela de Edição</p>)
                            }                               
                            </form>
                        </div>
                    </Container>
                </section>
            </MainContent>
        </>
    );
};

export default TiposEventosPage;