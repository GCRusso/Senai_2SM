// Importa a biblioteca React, necessária para criar componentes React
import React from "react";

// Importa os estilos definidos no arquivo "CardEvento.css"
import './CardEvento.css'

// Define um componente funcional chamado CardEvento
// const CardEvento = (props) => {

//     return (
//         <div className="box-card">
//             <h1 className="box-card__titulo">{props.titulo}</h1>
//             <p className="box-card__descricao">{props.descricao}</p>
//             <a href="" className="box-card__link">{props.link}</a>
//         </div> 
//     );

// };

//PARA A DESESTRUTURAÇÃO CHAMA APENAS AS PROPRIEDADES QUE DESEJA
// Define um componente funcional chamado CardEvento
const CardEvento = ( {titulo, descricao, link} ) => {

    return (
        <div className="box-card">
            <h1 className="box-card__titulo">{titulo}</h1>
            <p className="box-card__descricao">{descricao}</p>
            <a href="" className="box-card__link">{link}</a>
        </div> 
    );
};

// Exporta o componente CardEvento para que ele possa ser usado em outros lugares do aplicativo
export default CardEvento;
