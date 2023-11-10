import react from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Header from "./Components/Header/Header";
import Footer from "./Components/Footer/Footer";
import HomePage from "./pages/HomePage/HomePage"
import LoginPage from "./pages/LoginPage/LoginPage";
import TiposEventosPage from "./pages/TiposEventosPage/TiposEventosPage";
import TestePage from "./pages/TestePage/TestePage";
import EventosPage from "./pages/EventosPage/EventosPage"
import TestePageCopy from "./pages/TestePageCopy/TestePageCopy";

const Rotas = () => {
    return (
        <BrowserRouter>

            <Header />

            <Routes>
                <Route element={<HomePage />} path={"/"} exact />
                <Route element={<TiposEventosPage />} path={"/tipo-eventos"} exact />
                <Route element={<EventosPage />} path={"/eventos"} exact />
                <Route element={<LoginPage />} path={"/login"} exact />
                <Route element={<TestePage />} path={"/testes"} exact />
                <Route element={<TestePageCopy />} path={"/testescopy"} exact />

            </Routes>

            {/* Caso passe um texto aqui ele assume este texto, caso nao passe ele assume o texto que ja contem na textRights lá no footer.jsx 

            <Footer textRights="Todos os direitos reservados." />
            */}
            
            <Footer/>   
        </BrowserRouter>
    );
};

export default Rotas;
