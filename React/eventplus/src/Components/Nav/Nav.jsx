import React from 'react';
import './Nav.css'
//importando imagem do logotipo
import logoMobile from '../../assets/images/logo-white.svg';
import logoDesktop from '../../assets/images/logo-pink.svg';

const Nav = () => {
    return (
        <nav className='navbar'>
            <span className='navbar__close'>X</span>

            <a href="" className='eventlogo'>
                <img 
                className='eventlogo__logo-image' 
                src={windows.innerWidth >= 992 ? logoDesktop : logoMobile } 
                alt="Event Plus Logo" 
                />
            </a>

            <div className="navbar__items-box">
                <a href="">Home</a>
                <a href="">Tipos de Evento</a>
                <a href="">Usuários</a>
            </div>
        </nav>
    );
};

export default Nav;