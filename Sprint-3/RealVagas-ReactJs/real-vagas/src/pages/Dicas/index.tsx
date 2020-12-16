import React, { useState } from 'react';
import Header from '../../components/Header';
import icone1 from '../../assets/image/icone1.png';
import lupa from '../../assets/image/icone-busca.png';
import curriculo from '../../assets/image/curriculo.png';
import Modelo_de_Curriculo1 from '../../assets/image/Modelo_de_Curriculo1.jpg';
import Modelo_de_Curriculo2 from '../../assets/image/Modelo_de_Curriculo2.jpg';
import teste from '../../assets/image/teste.png';
import './style.css';
import '../../assets/style/global.css';
import Footer from '../../components/Footer';
import Button from "../../components/Button";
import { Modal } from 'react-bootstrap';
import { Link } from 'react-router-dom';



function Dicas() {
    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);



    return (
        <div >

            <Header />




            <div className="Dicas">

                <div className="conteudo-sobre">


                    <div className="conteudo-icon">

                        <div className="imagem">
                            <img id="imgicone" src={icone1} alt='icone1' title="Icone Dicas" />

                        </div>

                        <div className="texto-icon">
                            <h3>Dicas para montar um currículo</h3>
                        </div>

                    </div>




                    <div className="dicas">

                        <ul>
                            <li>1. Seja objetivo.</li>
                            <li>2. Se imagine no lugar do seu recrutador.</li>
                            <li>3. Escolha tamanho e formato adequados.</li>
                            <li>4. Priorize as informações essenciais.</li>
                            <li>5. Tome cuidado ao inserir sua foto.</li>
                            <li>6. Evite colocar sua pretensão salarial.</li>
                            <li>7. Fique esperto com suas redes sociais.</li>
                            <li>8. Saiba como driblar a falta de experiência.</li>
                            <li>9. Preste atenção aos erros de ortografia.</li>
                        </ul>
                    </div>


                    <div className="teste">
                        <img id="imgteste" src={teste} alt='teste' title="Icone teste comportamental" /><Link id="titulo-teste" to="/Teste">Teste comportamental</Link>
                    </div>

                    <div className="conteudo-icon">
                        <div className="imagem">
                            <img id="imgicone" src={icone1} alt='icone1' title="Icone Dicas" />
                        </div>

                        <div className="texto-icon">
                            <h3>Dicas de como se comportar em uma entrevista</h3>
                        </div>

                    </div>



                    <div className="dicas">


                        <ul>
                            <li>1. Durma bem e alimente-se adequadamente.</li>
                            <li>2. Seja pontual.</li>
                            <li>3. Vista-se de maneira adequada.</li>
                            <li>4. Comporte-se adequadamente desde a recepção.</li>
                            <li>5. Comunique-se de maneira formal/profissional.</li>
                            <li>6. Leve uma cópia do currículo e caneta.</li>
                            <li>7. Domine seu CV.</li>
                            <li>8. Olhe o entrevistador nos olhos.</li>
                        </ul>

                    </div>




                    <div className="curriculo">
                        <img id="imgcurriculo" src={curriculo} alt='curriculo' title="Icone modelo de currículo" /><input onClick={handleShow} type="button" name="botao-analise" value="Modelos de currículos " className="input-modal"></input>



                    </div>



                </div>

            </div>



            <Modal show={show} onHide={handleClose} >
                <Modal.Header closeButton >
                    <Modal.Title>Modelos de currículo</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <div className="curriculos">

                        <div className="curriculo1">

                            <a href={require('../../assets/documents/Modelo_de_Curricul01.pdf')} target="_blank">
                                <img
                                    id="curriculos" src={Modelo_de_Curriculo1} alt='curriculo' title="curriculo" />
                            </a>

                        </div>


                        <div className="curriculo2">
                            <a href={require('../../assets/documents/Modelo_de_Curricul02.pdf')} target="_blank">
                                <img
                                    id="curriculos" src={Modelo_de_Curriculo2} alt='curriculo' title="curriculo" />
                            </a>
                        </div>

                    </div>

                </Modal.Body>
            </Modal>




            <div>
                <Footer />


            </div>
        </div>
    );
}

export default Dicas;