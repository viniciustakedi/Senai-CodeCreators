import React from 'react';
import './style.css';
import '../../assets/style/global.css';
import ImgPorsa from '../../assets/image/foto-possarle.jpg';
import Header from '../../components/Header';
import ButtonTeste from '../../components/Button-teste';
import InverseLogo from '../../assets/image/Logoinvertida.png';
import InverseLogoSenai from '../../assets/image/senailogobranca.png';
import imgTeste1 from '../../assets/image/imgTeste1.png';
import imgTeste2 from '../../assets/image/imgTeste2.png';
import imgTeste3 from '../../assets/image/imgTeste3.png';
import Row from 'react-bootstrap/esm/Row';
import Col from 'react-bootstrap/esm/Col';
import { Container } from 'react-bootstrap';

function TesteComp() {
    return (
        <div>
            <Header />

            <div className="container-background">
                <div>
                    <div className="container-teste">
                        <img className="imgPossarle" src={ImgPorsa} alt="Roberto Possarle" />

                        <div className="texto-principal">
                            <h1>Descubra quem você é</h1>
                            <h2>e como as outras pessoas são diferentes de você</h2>
                        </div>
                        <ButtonTeste value="Clique aqui para começar" />
                    </div>
                    <div className="container-texto">
                        <h1>Objetivos</h1>
                        <p id="texto-alinhado">Em sua carreira você é lobo, tubarão, gato ou águia?
                        As características do mundo animal também podem
                        ser usadas como inspiração no ambiente corporativo.
                        E hoje já é possível falar sobre o tipo de personalidade
                        e traçar o perfil de cada pessoa a partir de mapa
                        comportamental.
            </p>
                    </div>
                    <Container>
                        <div className="container-objetivos">
                            <Row>
                                <Col><img className="img1" src={imgTeste1} alt="produtividade" />
                                    <h1>Produtividade</h1>

                                    <p>Descubra as carreiras que se encaixam com seu jeito único de ser</p>
                                </Col>
                                <Col><img className="img2" src={imgTeste2} alt="tempo" />
                                    <h1>Tempo</h1>

                                    <p>Compreenda como você lida com um dos recursos mais valiosos do século 21</p>
                                </Col>
                                <Col>
                                    <img className="img3" src={imgTeste3} alt="percepção" />
                                    <h1>Percepção</h1>

                                    <p>Aprenda como você e outras pessoas enxergam e lidam com o mundo à sua volta</p>
                                </Col>
                            </Row>
                        </div>
                    </Container>

                    <div className="Footer-Alterado">
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
                </div>
            </div>
        </div>
    )
}
export default TesteComp;





