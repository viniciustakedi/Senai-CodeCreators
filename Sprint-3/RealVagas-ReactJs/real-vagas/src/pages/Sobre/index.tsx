import React from 'react';
import Footer from '../../components/Footer';
import Header from '../../components/Header';
import './style.css';
import InverseLogo from '../../assets/image/Logoinvertida.png';
import InverseLogoSenai from '../../assets/image/senailogobranca.png';

function Sobre() {

    return (
        <div >
            <Header />
            <div className="sobre" >

                <div className="containersobre">
                    <div className="imagens">
                        < img id="logo" src={InverseLogo} alt="logonegativo" />
                        <img id="logoSenai" src={InverseLogoSenai} alt="logonegativo" />
                    </div>

                    <div className="texto">
                            <p>A Real Vaga é uma agência de empregos paulista de grande
                            prestígio no mercado de trabalho, parceira da renomada 
                            instituição de ensino SENAI. Nosso objetivo é capacitar
                            alunos e ex-alunos desta instituição a encontrar empregos
                            adequados para sua formação profissional de forma simples e rápida.</p>
                    </div>
                </div>



            </div>

            <div className="footer-sobre">
                <Footer />
            </div>


        </div>
    )
}

export default Sobre;