import React from 'react';
import './style.css';
import '../../assets/style/global.css';
import { Nav, Image, Container, Row, Col } from 'react-bootstrap';
import Button from '../../components/Button/index'
import 'bootstrap/dist/css/bootstrap.min.css';
import { Link, useHistory } from 'react-router-dom';
import Logo from '../../assets/image/Logo.png';

function Header() {
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

                    <div className="d-flex">
                        <Nav.Item className="nav-person">
                            <Nav.Link ><Link to="/Login">Login</Link></Nav.Link>
                        </Nav.Item>

                        <Nav.Item className="person-nav ">
                            <Nav.Link><Link to="/Cadastro">Cadastrar</Link></Nav.Link>
                        </Nav.Item>
                    </div>
                </Nav>
            </Container>
        </div>
    )
}

export default Header;