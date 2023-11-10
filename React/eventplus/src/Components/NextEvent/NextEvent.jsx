import './NextEvent.css'
import React from 'react';
import { dateFormatDbToView } from '../../pages/Utils/stringFunctions';
import { Tooltip } from 'react-tooltip';

const NextEvent = ({ title, description, eventDate, idEvent }) => {

    function conectar(idEvent) {
        alert(`Chamar o recurso para conectar ${idEvent}`)
    }
    return (

        <article className='event-card'>

            <h2 className='event-card__title'> {title.substr(0, 15)} </h2>

            <p 
            className='event-card__description'
            
            data-tooltip-id={idEvent}
            data-tooltip-content={description}
            data-tooltip-place="bottom"
            >
                <Tooltip id={idEvent} className='tooltip'/>
                {description.substr(0, 15)}...{/* Limita os caracteres que aparece dentro da box, ele mostra do caracter  0 até o 15 */}
            </p> 

            <p className='event-card__description'> {dateFormatDbToView(eventDate)} </p>

            <a href="/" onClick={() => { conectar(idEvent) }} className='event-card__connect-link'>Conectar</a>

        </article>


    );
};

export default NextEvent