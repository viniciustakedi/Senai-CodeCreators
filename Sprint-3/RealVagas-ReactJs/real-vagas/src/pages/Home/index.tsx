import React from 'react';
import './style.css';
import '../../assets/style/global.css';
import Header from '../../components/Header';
import Footer from '../../components/Footer';
import ImgLupa from '../../assets/image/ImgHome.png';
import { Link } from 'react-router-dom';
import { Button } from 'react-bootstrap';
import InverseLogo from '../../assets/image/Logoinvertida.png';
import InverseLogoSenai from '../../assets/image/senailogobranca.png';


function Home() {

    return (
        <div className="Home">
            <Header />

            <div className="padding-margin">
                <div className="titulo-home">
                    <h1>Real Vagas & SENAI</h1>
                </div>

                <div className="title-Home">
                    <p>
                        Cadastre uma vaga ou procure uma.
                    </p>
                </div>

                <Link to="/Cadastro"><button id="CadastroUsuario" name="Cadastre-se como usuário">Cadastre-se como usuário</button></Link>

                <div>
                    <Link to="/CadastroEmpresa"><button id="CadastroEmpresa" name="Cadastre sua empresa" >Cadastre sua empresa</button></Link>
                </div>

                <div className="footer-HomeAlterado">
                    <div className="Home-texto">
                            <p>Real Vagas & SENAI</p>
                            <p>Contato: (XX) XXXX-XXXX</p>
                            <p>senai@email.com</p>

                    </div>
                    <hr />
                    <div className="images">
                        <img id="logo" src={InverseLogo} alt="" />
                        <img id="logoSenai" src={InverseLogoSenai} alt="" />
                    </div>
                </div>
            </div>
        </div>
    )
}

export default Home;