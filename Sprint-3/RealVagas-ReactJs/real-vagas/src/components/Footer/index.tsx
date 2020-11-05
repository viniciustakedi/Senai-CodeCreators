import React from 'react';
import './style.css';
import '../../assets/style/global.css';
import InverseLogo from '../../assets/image/Logoinvertida.png';
import InverseLogoSenai from '../../assets/image/senailogobranca.png';

function Footer() {
    return (
            <div className="Footer">
                <div id="Text">
                        <p>Real Vagas & SENAI</p>
                        <p>Contato: (XX) XXXX-XXXX</p>
                        <p>senai@email.com</p>
                </div>

                <hr />

                <div className="images">
                    <img id="LogoInversa" src={InverseLogo} alt="" />
                    <img id="LogoSenai" src={InverseLogoSenai} alt="" />
                </div>
            </div>
    )
}

export default Footer;