import React, { useContext, useState } from 'react';
import ImageIllustrator from "../../Components/ImageIlustrator/ImageIlustrator";
import logo from "../../assets/images/logo-pink.svg";
import { Input, Button } from "../../Components/FormComponents/FormComponents";
import api, { loginResource } from '../../Services/Service'
import { UserContext, userDecodeToken } from '../../context/AuthContext';

import "./LoginPage.css";

const LoginPage = () => {
    const [user, setUser] = useState({ email: "gabriel@gmail.com", senha: "123456" });

    //Importa os dados globais do usuario
    const { userData, setUserData } = useContext(UserContext);


    async function handleSubmit(e) {
        e.preventDefault();

        if (user.email.trim().length >= 3 && user.senha.trim().length >= 3) {
            try {
                const promise = await api.post(loginResource, {
                    email: user.email,
                    senha: user.senha
                });

                //Decodifica o token vindo da API
                const userFullToken = userDecodeToken(promise.data.token);

                //Guarda o token globalmente
                setUserData(userFullToken);
            
                localStorage.setItem("token", JSON.stringify(userFullToken));

            } catch (error) {
                //Erro da API: bad request(401) ou erro de conexão
                alert("Verifique os dados e a conexão com a internet!")
            }
        }

        else {
            alert("Preencha os dados corretamente!")
        }


    }

    return (
        <div className="layout-grid-login">
            <div className="login">
                <div className="login__illustration">
                    <div className="login__illustration-rotate"></div>
                    <ImageIllustrator
                        imageName="login-img"
                        altText="Imagem de um homem em frente de uma porta de entrada"
                        additionalClass="login-illustrator"
                    />
                </div>

                <div className="frm-login">
                    <img src={logo} className="frm-login__logo" alt="" />

                    <form className="frm-login__formbox" onSubmit={handleSubmit}>
                        <Input
                            className="frm-login__entry"
                            type="email"
                            id="login"
                            name="login"
                            required={true}
                            value={user.email}
                            manipulationFunction={(e) => {
                                setUser({ ...user, email: e.target.value.trim() })
                            }}
                            placeholder="Username"
                        />
                        <Input
                            className="frm-login__entry"
                            type="password"
                            id="senha"
                            name="senha"
                            required={true}
                            value={user.senha}
                            manipulationFunction={(e) => {
                                setUser({ ...user, senha: e.target.value.trim() }) //...user para manter o dado que tinha antes, para depois atualizar com o valor inserido
                            }}
                            placeholder="****"
                        />

                        <a href="" className="frm-login__link">
                            Esqueceu a senha?
                        </a>

                        <Button
                            textButton="Login"
                            id="btn-login"
                            name="btn-login"
                            type="submit"
                            additionalClass="frm-login__button"
                        />
                    </form>
                </div>
            </div>
        </div>
    );
};

export default LoginPage;
