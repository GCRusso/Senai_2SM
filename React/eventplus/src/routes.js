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
                <Route element={ <HomePage />} path={"/"} exact />
                <Route element={ <LoginPage />} path={"/login"} exact />
                <Route element={ <TipoEventos />} path={"/tipo-eventos"} exact />
                <Route element={ <TestePage />} path={"/testes"} exact />
                <Route element={ <EventosPage />} path={"/eventos"} exact />
                
            </Routes>
            <Footer />
        </BrowserRouter>
    );
};

export default Rotas;
