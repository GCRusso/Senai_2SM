import React from 'react';
import './TableEvent.css';

const Table = () => {
    return (
        <table>
            <thead>
            <tr className="table-data__head-row">
                    <th className="table-data__head-title table-data__head-title--big">Nome</th>
                    <th className="table-data__head-title table-data__head-title--little">Tipo Evento</th>
                    <th className="table-data__head-title table-data__head-title--little">Editar</th>
                    <th className="table-data__head-title table-data__head-title--little">Deletar</th>
                </tr>
            </thead>

            <tbody>

            </tbody>
        </table>
    );
};

export default Table;