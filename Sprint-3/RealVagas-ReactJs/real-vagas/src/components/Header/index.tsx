import React from 'react';
import './style.css';
import '../../assets/style/global.css';
import { Navbar, Nav } from 'react-bootstrap';
import { Link, useHistory } from 'react-router-dom';
import Logo from '../../assets/image/Logo.png';

function Header() {
    return (
        <div className="centro">
            <div className="Header">
                <nav>
                    <img id="LogoImg" src={Logo} alt="Logo real vagas" />
                    <ul>
                        <li>Home</li>
                        <li>Vagas</li>
                        <li>Dicas do Possarle</li>
                        <li>Sobre nós</li>
                    </ul>
                    <div className="login">
                        <ul>
                            <li>Login</li>
                        </ul>
                        <input 
                        type="button" value="Cadastre-se" />
                    </div>
                </nav>
            </div>
        </div>
    )
}

export default Header;