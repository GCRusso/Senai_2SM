import React from 'react';
import './TableEvent.css';
import editPen from '../../../assets/images/edit-pen.svg';
import trashDelete from '../../../assets/images/trash-delete.svg';
import { dateFormatDbToView } from '../../Utils/stringFunctions';
import { Tooltip } from 'react-tooltip';
const Table = ({ dados, fnDelete = null, fnUpdate = null }) => {
    return (
        <table className='table-data'>
            <thead className="table-data__head">
                <tr className="table-data__head-row">
                    <th className="table-data__head-title table-data__head-title--big">Nome</th>
                    <th className="table-data__head-title table-data__head-title--big">Descrição</th>
                    <th className="table-data__head-title table-data__head-title--big">Tipo Evento</th>
                    <th className="table-data__head-title table-data__head-title--big">Data</th>
                    <th className="table-data__head-title table-data__head-title--little">Editar</th>
                    <th className="table-data__head-title table-data__head-title--little">Deletar</th>
                </tr>
            </thead>

            {/* CORPO  */}
            <tbody>
                {dados.map((evt) => {
                    return (
                        <tr key={evt.idEvento} className="table-data__head-row">
                            <td className="table-data__data table-data__data--big">
                                {evt.nomeEvento}
                            </td>
                            <td className="table-data__data table-data__data--big"
                                data-tooltip-id={evt.idEvento}
                                data-tooltip-content={evt.descricao}
                                data-tooltip-place="bottom"
                            >
                                {evt.descricao}

                                <Tooltip id={evt.idEvento} className='custom-tootip' />
                                {evt.descricao.substr(0, 15)}...
                            </td>
                            <td className="table-data__data table-data__data--big">
                                {evt.tiposEvento.titulo}
                            </td>
                            <td className="table-data__data table-data__data--big">
                                {dateFormatDbToView(evt.dataEvento)}
                            </td>

                            <td className="table-data__data table-data__data--little">
                                <img
                                    className="table-data__icon"
                                    src={editPen}
                                    alt="Imagem de uma caneta, para edição dos dados"
                                    idtipoevento={evt.idEvento}
                                    onClick={(e) => {
                                        fnUpdate(evt.idEvento)
                                    }}
                                />
                            </td>

                            <td className="table-data__data table-data__data--little">
                                <img
                                    className="table-data__icon"
                                    src={trashDelete}
                                    alt="Imagem de uma lixeira, para exclusao dos dados"
                                    onClick={() => {
                                        fnDelete((evt.idEvento))
                                    }}
                                />
                            </td>
                        </tr>
                    )
                })}

            </tbody>
        </table>
    );
};

export default Table;