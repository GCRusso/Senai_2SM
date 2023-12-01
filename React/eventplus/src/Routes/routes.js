import react from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Header from "../Components/Header/Header";
import Footer from "../Components/Footer/Footer";
import HomePage from "../pages/HomePage/HomePage"
import LoginPage from "../pages/LoginPage/LoginPage";
import TiposEventosPage from "../pages/TiposEventosPage/TiposEventosPage";
import TestePage from "../pages/TestePage/TestePage";
import EventosPage from "../pages/EventosPage/EventosPage";
import TestePageCopy from "../pages/TestePageCopy/TestePageCopy";
import { PrivateRoute } from "./PrivateRoute";

const Rotas = () => {
    return (
        <BrowserRouter>

            <Header />

            <Routes>
                {/* Paginas Públicas */}
                <Route element={<LoginPage />} path={"/login"} exact />
                <Route element={<HomePage />} path={"/"} exact />

                {/* Testes */}
                <Route element={<TestePage />} path={"/testes"} exact />
                <Route element={<TestePageCopy />} path={"/testescopy"} exact />

                {/* Páginas Privadas */}
                <Route
                    path="/tipo-eventos"
                    element={
                        <PrivateRoute redirectTo="/">
                            <TiposEventosPage />
                        </PrivateRoute>
                    }
                    exact />

                <Route
                    path={"/eventos"}
                    element={
                        <PrivateRoute redirectTo="/">
                            <EventosPage />
                        </PrivateRoute>
                    } exact />



            </Routes>


            <Footer />
        </BrowserRouter>
    );
};

export default Rotas;
