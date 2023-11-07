import react from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Header from "./Components/Header/Header";
import Footer from "./Components/Footer/Footer";
import HomePage from "./pages/HomePage/HomePage"
import LoginPage from "./pages/LoginPage/LoginPage";
import TipoEventos from "./pages/TipoEventos/TipoEventos";
import TestePage from "./pages/TestePage/TestePage";
import EventosPage from "./pages/EventosPage/EventosPage"

const Rotas = () => {
    return (
        <BrowserRouter>

            <Header />

            <Routes>
                <Route element={<HomePage />} path={"/"} exact />
                <Route element={<TipoEventos />} path={"/tipo-eventos"} exact />
                <Route element={<EventosPage />} path={"/eventos"} exact />
                <Route element={<LoginPage />} path={"/login"} exact />
            </Routes>

            {/* Caso passe um texto aqui ele assume este texto, caso nao passe ele assume o texto que ja contem na textRights lá no footer.jsx 

            <Footer textRights="Todos os direitos reservados." />
            */}
            
            <Footer/>   
        </BrowserRouter>
    );
};

export default Rotas;
