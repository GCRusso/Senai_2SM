import React from "react";
import { Link } from "react-router-dom";

const Header = () => {
    return(
        <header>
            <nav>
                <Link to="/">Home</Link>
                <br /><br />
                <Link to="/tipoeventos">Tipo Eventos</Link>
                <br /><br />
                <Link to="/eventos">Eventos</Link>
                <br /><br />
                <Link to="/login">Login</Link>
                <br /><br />
                <Link to="/testes">Teste</Link>
            </nav>
        </header>
    );
};

export default Header;