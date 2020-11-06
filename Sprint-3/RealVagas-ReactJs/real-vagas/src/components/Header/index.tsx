import React from 'react';
import './style.css';
import { parseJWT } from '../../services/auth';
import '../../assets/style/global.css';
import { Nav, Image, Container } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Link, useHistory } from 'react-router-dom';
import Logo from '../../assets/image/Logo.png';
import Button from '../Button';

const Header = () => {

    let history = useHistory();

    const sair = () => {
        localStorage.removeItem('Real-Vagas-Token');
        localStorage.removeItem('Real-Vagas-Id-Usuario');
        history.push('/');
    }

    const menu = () => {
        const token = localStorage.getItem('Real-Vagas-Token');
        if (token === undefined || token === null) {
            return (
                <div className="Container-Nav">
                    <nav>
                        <ul>
                            <li><img src={Logo} alt="Logo"/></li>
                        </ul>
                        <ul>
                            <li><Link to="/">Home</Link></li>
                            <li><Link to="/Vagas">Vagas</Link></li>
                            <li><Link to="/Dicas">Dicas do Possarle</Link></li>
                            <li><Link to ="/Sobre">Sobre Nós</Link></li>
                        </ul>
                        <ul>
                            <li><Link to="/Login">Login</Link></li>
                            <li><Link to="/Cadastro"><Button id="btnCadastro" name="Cadastre-se"></Button></Link></li>
                        </ul>
                    </nav>
                </div>
            )
        } else {
            if (parseJWT() == 1) {
                return (
                    <div className="Container-Nav">
                    <nav>
                        <ul>
                            <li><img src={Logo} alt="Logo"/></li>
                        </ul>
                        <ul>
                            <li><Link to="/">Home</Link></li>
                            <li><Link to="/Dicas">Dicas do Possarle</Link></li>
                            <li><Link to ="/Sobre">Sobre Nós</Link></li>
                        </ul>
                        <ul>
                            <li><Link to="" onClick={event => {
                                event.preventDefault();
                                sair();
                            }}>Sair</Link></li>
                            <li><Link to="/Administrador"><Button id="btnCadastro" name="Perfil"></Button></Link></li>
                        </ul>
                    </nav>
                </div>
                )
            } else if (parseJWT() == 2) {
                return (
                    <div className="Container-Nav">
                    <nav>
                        <ul>
                            <li><img src={Logo} alt="Logo"/></li>
                        </ul>
                        <ul>
                            <li><Link to="/">Home</Link></li>
                            <li><Link to="/Dicas">Dicas do Possarle</Link></li>
                            <li><Link to ="/Sobre">Sobre Nós</Link></li>
                        </ul>
                        <ul>
                            <li><Link to="" onClick={event => {
                                event.preventDefault();
                                sair();
                            }}>Sair</Link></li>
                            <li><Link to="/Dashboard"><Button id="btnCadastro" name="Perfil"></Button></Link></li>
                        </ul>
                    </nav>
                </div>
                )
            } else if (parseJWT() == 3 || parseJWT() == 4) {
                return (
                    <div className="Container-Nav">
                    <nav>
                        <ul>
                            <li><img src={Logo} alt="Logo"/></li>
                        </ul>
                        <ul>
                            <li><Link to="/">Home</Link></li>
                            <li><Link to="/Vagas">Vagas</Link></li>
                            <li><Link to="/Dicas">Dicas do Possarle</Link></li>
                            <li><Link to ="/Sobre">Sobre Nós</Link></li>
                        </ul>
                        <ul>
                            <li><Link to="" onClick={event => {
                                event.preventDefault();
                                sair();
                            }}>Sair</Link></li>
                            <li><Link to="/Perfil"><Button id="btnCadastro" name="Perfil"></Button></Link></li>
                        </ul>
                    </nav>
                </div>
                )
            }
        }
    }

    return (
        <div>
                {menu()}
        </div>
    )
}

export default Header;