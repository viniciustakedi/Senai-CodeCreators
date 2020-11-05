import React, { useState } from "react";
import "../../assets/style/global.css";
import "./style.css";
import Header from "../../components/Header/index";
import Footer from "../../components/Footer/index";
import { Link, useHistory } from "react-router-dom";
import Input from "../../components/Input";
import Button from "../../components/Button";
import { Col, Container, Row } from "react-bootstrap";


function Login() {
    let history = useHistory();

    const [email, setEmail] = useState(""); //Como se fosse {get; set;}
    const [senha, setSenha] = useState(""); // acessar e alterar //get set

    const login = () => {
        //Arrow function login
        const login = {
            //váriavel login para armazenar um array {}
            email: email,
            senha: senha, //Acessando e alterando (modelo) os dados como se fosse no postman
        };

        fetch("http://localhost:5000/api/Login", {
            //Fetch passando a url da API
            method: "POST", //Como é um login o método é o Post
            body: JSON.stringify(login), //Seleciona o tipo do corpo, no caso é json (Postman: Raw/Json)
            headers: {
                "content-type": "application/json", //Tipo do conteudo é uma aplicação Json
            },
        })
            .then((response) => response.json())
            .then((dados) => {
                if (dados.token != undefined) {
                    //Se dados token for diferente de Undefined
                    localStorage.setItem("Real-Vagas-Token", dados.token); //Local storage irá adicionar esta chave ao storage, ou atualizar o valor caso a chave já exista
                    history.push("/"); //Push indicando que ele está empurrando o usuário para uma pagina, no caso a Home
                } else alert("Email ou senha inválidos"); //Alerta caso o email ou senha estejam errados
            })
            
            .catch((error) => console.error(error)); // Como usando o fetch colocamos um catch caso algo de errado.
    };
    
    return (
        <div>
            <Header />
            <div className="log">
                <form
                    onSubmit={(event) => {
                        event.preventDefault();
                        login();
                    }}
                >
                        <div className="login-container">
                                <h1>Login</h1>
                            <div>
                                <Input className="email" type="Email" name="Email" label="E-mail" onChange={(e) => setEmail(e.target.value)} />
                                <Input className="senha" type="Password" name="Senha" label="Senha" onChange={(e) => setSenha(e.target.value)} />
                                <p>Esqueceu sua senha?</p> 
                            </div>
                                <Button name="Enviar" />
                            <Link id="cadastre-se" to="/Cadastro">Cadastre-se</Link> 
                        </div>
                </form>
            </div>
            <Footer />
        </div>
    );
}
export default Login;