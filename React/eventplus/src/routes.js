import react from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import HomePage from "./pages/HomePage/HomePage"
import LoginPage from "./pages/LoginPage/LoginPage";
import TipoEventos from "./pages/TipoEventos/TipoEventos";
import TestePage from "./pages/TestePage/TestePage";



const Rotas = () => {
    return (
        <BrowserRouter>
            <Routes>
                <Route element={ <HomePage />} path={"/"} exact />
                <Route element={ <LoginPage />} path={"/login"} exact />
                <Route element={ <TipoEventos />} path={"/tipoeventos"} exact />
                <Route element={ <TestePage />} path={"/testes"} exact />
                
            </Routes>
        </BrowserRouter>
    );
};

export default Rotas;
