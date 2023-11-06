import React from 'react';
import './Nav.css'
//importando imagem do logotipo
import logoMobile from '../../assets/images/logo-white.svg';
import logoDesktop from '../../assets/images/logo-pink.svg';

import { Link } from 'react-router-dom';
const Nav = () => {
    return (
        <nav className='navbar'>
            <span className='navbar__close'>X</span>

            <a href="" className='eventlogo'>
                <img 
                className='eventlogo__logo-image' 
                src={window.innerWidth >= 992 ? logoDesktop : logoMobile } 
                alt="Event Plus Logo" 
                />
            </a>

            <div className="navbar__items-box">
                <Link to="/">Home</Link> 
                <Link to="/tipo-eventos">Tipos de Evento</Link>
                <Link to="">Usuários</Link>
                <Link to="/login">Login</Link>
                <Link to="/eventos">Eventos</Link>
                <Link to="/testes">Testes</Link>
            </div>
        </nav>
    );
};

export default Nav;