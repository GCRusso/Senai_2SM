import React from 'react';
import './TableDe.css'
import "react-tooltip/dist/react-tooltip.css";
import { Tooltip } from "react-tooltip";

const TableDe = ({ nome, descricao, tipo, data, comentario }) => {
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
                    <th className="table-data__head-title table-data__head-title--big">{nome}</th>
                    <th className="table-data__head-title table-data__head-title--big">{descricao}</th>
                    <th className="table-data__head-title table-data__head-title--big">{tipo}</th>
                    <th className="table-data__head-title table-data__head-title--big">{data}</th>
                </tr>
            </thead>

            <tbody>
                {/* {comentario.map((c)=>{
                    return(
                    <tr className="tbal-data__head-row" key={Math.Random()}>
                        <td>{c.usuario.nome}</td>
                        <td>{c.descricao}</td>
                    </tr>
                    )
                })} */}
            </tbody>



        </table>
    );
};

export default TableDe;