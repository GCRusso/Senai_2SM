import React, {useEffect} from "react";
import trashDelete from "../../assets/images/trash-delete-red.png";

import { Button, Input } from "../FormComponents/FormComponents";
import "./Modal.css";
import { UserContext } from "../../context/AuthContext";

const Modal = ({
  modalTitle = "Feedback",
  comentaryText = "Sem comentários",
  userId = null,
  showHideModal = false,
  fnNewCommentary = null,
  fnDelete= null,
  fnGet= null,

  newCommentary,
  setNewCommentary = null
}) => {

  useEffect(() => {
    async function carregarDados(){
    }

    carregarDados();
  },[]);


  return (
    <div className="modal">
      <article className="modal__box">
        
        <h3 className="modal__title">
          {modalTitle}
          <span className="modal__close" onClick={()=> showHideModal(true)}>x</span>
        </h3>

        <div className="comentary">
          <h4 className="comentary__title">Comentário</h4>
          <img
            src={trashDelete}
            className="comentary__icon-delete"
            alt="Ícone de uma lixeira"
            onClick={() =>{fnDelete()}}
          />

          <p className="comentary__text">{comentaryText}</p>

          <hr className="comentary__separator" />
        </div>

        <Input
          placeholder="Escreva seu comentário..."
          className="comentary__entry"
          required={"required"}
          type={"text"}

          value={newCommentary}
          manipulationFunction={(e) => {setNewCommentary(e.target.value)}}
        />

        <Button
          textButton="Comentar"
          className="comentary__button"
          manipulationFunction = {() => {fnNewCommentary()}}
        />
      </article>
    </div>
  );
};

export default Modal;