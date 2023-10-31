import react from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import HomePage from "./pages/HomePage/HomePage"
import LoginPage from "./pages/LoginPage/LoginPage";



const Rotas = () => {
    return (
        <BrowserRouter>
            <Routes>
                <Route element={ <HomePage />} path={"/"} exact />
                <Route element={ <LoginPage />} path={"/login"} exact />
            </Routes>
        </BrowserRouter>
    );
};

export default Rotas;
