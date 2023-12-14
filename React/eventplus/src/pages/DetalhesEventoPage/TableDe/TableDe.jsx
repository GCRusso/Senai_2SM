import React from 'react';
import './TableDe.css'
import "react-tooltip/dist/react-tooltip.css";
import { Tooltip } from "react-tooltip";
import { dateFormatDb } from '../../Utils/stringFunctions';

const TableDe = ({ evento, comentario, tipo }) => {
    return (
        <table className="table-data text-color">
            <thead className="table-data__head">
                <tr className="table-data__head-row">
                    <th className="table-data__head-title table-data__head-title--big">
                        Evento
                    </th>
                    <th className="table-data__head-title table-data__head-title--big">
                        Descrição
                    </th>
                    <th className="table-data__head-title table-data__head-title--big">
                        Tipo Evento
                    </th>
                    <th className="table-data__head-title table-data__head-title--big">
                        Data
                    </th>
                </tr>

                <tr
                    className='tbal-data__head-row tbal-data__head-row--red-color'
                >
                    <th className="table-data__head-title table-data__head-title--big font-color">{evento.nomeEvento}</th>
                    <th className="table-data__head-title table-data__head-title--big font-color" >{evento.descricao}</th>
                    <th className="table-data__head-title table-data__head-title--big font-color">{tipo.titulo}</th>
                    <th className="table-data__head-title table-data__head-title--big font-color">{dateFormatDb(evento.dataEvento)}</th>
                </tr>
            </thead>

            <tbody>
                <tr className="table-data__head-row">
                <th className="table-data__head-title table-data__head-title--big">
                        Comentário
                    </th>
                    <th className="table-data__head-title table-data__head-title--big">
                        Usuário
                    </th>
 
                </tr>
                {comentario.map((c)=>{
                    return(
                    <tr className="tbal-data__head-row" key={Math.random()}>
                        
                        <td>{c.descricao}</td>
                        <td className="table-data__head-title table-data__head-title--big">{c.usuario.nome}</td>
                    </tr>
                    )
                })}
            </tbody>



        </table>
    );
};

export default TableDe;