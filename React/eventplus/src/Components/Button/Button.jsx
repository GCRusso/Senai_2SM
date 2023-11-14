import React from "react";

const Button = ({textButton, type, className}) =>{
return(
    <button type={type}> {textButton}  </button>
);
};

export default Button;