import React from 'react';
import './style.css';
import '../../assets/style/global.css';
import InverseLogo from '../../assets/image/Logoinvertida.png';
import InverseLogoSenai from '../../assets/image/senailogobranca.png';

function Footer() {
    return (
            <div className="Footer">
                <div className="text">
                    <ul>
                        <li>Real Vagas & SENAI</li>
                        <li>Contato: (XX) XXXX-XXXX</li>
                        <li>senai@email.com</li>
                    </ul>
                </div>

                <hr />

                <div className="images">
                    <img id="logo" src={InverseLogo} alt="" />
                    <img id="logoSenai" src={InverseLogoSenai} alt="" />
                </div>
            </div>
    )
}

export default Footer;