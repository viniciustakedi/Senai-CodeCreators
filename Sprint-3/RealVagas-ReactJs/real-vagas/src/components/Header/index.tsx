import React from 'react';
import './style.css';
import { parseJWT } from '../../services/auth';
import '../../assets/style/global.css';
import { Nav, Image, Container } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Link, useHistory } from 'react-router-dom';
import Logo from '../../assets/image/Logo.png';

const Header = () => {

    let history = useHistory();

    const sair = () => {
        localStorage.removeItem('Real-Vagas-Token');
        history.push('/');
    }

    const menu = () => {
        const token = null;

        if (token === undefined || token === null) {
            return (
                <div className="d-flex">
                    <Nav.Item className="nav-person">
                        <Nav.Link ><Link to="/Login">Login</Link></Nav.Link>
                    </Nav.Item>

                    <Nav.Item className="person-nav ">
                        <Nav.Link><Link to="/Cadastro">Cadastrar</Link></Nav.Link>
                    </Nav.Item>
                </div>
            )
        } else {
            if (parseJWT() === 1) {
                return (
                    <div className="d-flex">
                        <Nav.Item className="nav-person">
                            <Nav.Link ><Link to="/Administrador">Perfil</Link></Nav.Link>
                        </Nav.Item>

                        <Nav.Item className="person-nav">
                            <Nav.Link><Link to="" onClick={event => {
                                event.preventDefault();
                                sair();
                            }}>Sair</Link></Nav.Link>
                        </Nav.Item>
                    </div>
                )
            } else if (parseJWT() === 2) {
                return (
                    <div className="d-flex">
                        <Nav.Item className="nav-person">
                            <Nav.Link ><Link to="/Dashboard">Perfil</Link></Nav.Link>
                        </Nav.Item>

                        <Nav.Item className="person-nav">
                            <Nav.Link><Link to="" onClick={event => {
                                event.preventDefault();
                                sair();
                            }}>Sair</Link></Nav.Link>
                        </Nav.Item>
                    </div>
                )
            } else if (parseJWT() === 3 || parseJWT() === 4) {
                return (
                    <div className="d-flex">
                        <Nav.Item className="nav-person">
                            <Nav.Link ><Link to="/Perfil">Perfil</Link></Nav.Link>
                        </Nav.Item>

                        <Nav.Item className="person-nav">
                            <Nav.Link><Link to="" onClick={event => {
                                event.preventDefault();
                                sair();
                            }}>Sair</Link></Nav.Link>
                        </Nav.Item>
                    </div>
                )
            }
        }
    }

    return (
        <div>
            <Container className="Container-nav">
                <Nav className="nav justify-content-around align-items-center" activeKey="/home">
                    <Nav.Item>
                        <Nav.Link ><Image src={Logo} className="img-fluid" /></Nav.Link>
                    </Nav.Item>

                    <div className="d-flex">
                        <Nav.Item className="nav-person">
                            <Nav.Link><Link to="/">Home</Link></Nav.Link>
                        </Nav.Item>
                        <Nav.Item className="nav-person">
                            <Nav.Link><Link to="/Vagas">Vagas</Link></Nav.Link>
                        </Nav.Item>
                        <Nav.Item className="nav-person">
                            <Nav.Link><Link to="/Dicas">Dicas do Possarle</Link></Nav.Link>
                        </Nav.Item>
                        <Nav.Item className="nav-person">
                            <Nav.Link ><Link to="/Sobre">Sobre nós</Link></Nav.Link>
                        </Nav.Item>
                    </div>
                    {menu()}
                </Nav>
            </Container>
        </div>
    )
}

export default Header;