import React from "react";
import './Container.css'


const Container = (props) => {
return(
    <div className="container">
        {/* Sempre utilizamos a props.children quando iremos utilizar algo dentro dele, como este exemplo que dentro do Container esta os CardEvento */}
        {props.children}
    </div>
);
};

export default Container;