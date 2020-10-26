import React, { useEffect, useState } from 'react';
import { Modal, Button } from 'react-bootstrap';
import Footer from '../../components/Footer';
import Header from '../../components/Header';
import Input from '../../components/Input';
import ButtonInscricao from '../../components/Button-inscricao';
import ImgLupa from '../../assets/image/icone-busca.png';
import '../../assets/style/global.css';
import './style.css';
import { Item } from 'react-bootstrap/lib/Breadcrumb';

function Vagas() {

    // Variáveis para o Modal funcionar
    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    //Começo funcionalidades vagas
    const [vaga, setVaga] = useState(''); //duas '' pois é uma string
    const [idVaga, setIdVaga] = useState(0); //numero 0 pois é um int Id

    const [vagas, setVagas] = useState([]);

    useEffect(() => {
        listar();
    }, []);

    //Listar vagas
    const UrlVagas = 'http://localhost:5000/api/Vagas';

    const listar = () => {

        fetch(UrlVagas, {
            method: 'GET'
        })
            .then(response => response.json())
            .then(dados => {
                setVagas(dados)
                console.log(dados);
            })

            .catch(Erro => console.error(Erro));
    }

    return (
        <div>
            <Header />
            <div className="vagas">
                <div className="title">
                    <h1>Encontre a sua vaga!</h1>
                </div>
                <div className="pesquisa">
                    <img src={ImgLupa} alt="Icone de uma lupa" />

                    {/* Mecanismo de pesquisa de vagas */}
                    <Input id="InputEdit" name="pesquisa" label="" placeholder="Buscar vaga" />
                </div>
                {
                    vagas.map((item: any) => {
                        return (
                            <div className="fetch">
                                <div className="Conteudo" key={item.idVagas}>
                                    <div className="TitleImg">
                                        <div className="img">
                                            {/* Imagem da vaga */}
                                            <img src="" alt="Foto vaga" />
                                        </div>
                                        <div className="title1">
                                            {/* Nome da vaga */}
                                            <h1>{item.cargo}</h1>

                                            {/* Local da vaga */}
                                            <h2>{item.localVaga}</h2>

                                            {/* Salário */}
                                            <h3>{'R$' + item.salario}</h3>

                                        </div>


                                    </div>

                                    <div className="buttons">
                                        <div className="inscricao">
                                            {/* Botão para inscrever-se na vaga */}
                                            <ButtonInscricao value="Inscrever-se" />
                                        </div>
                                        <div className="verMais">
                                            {/* Botão para ver mais informação sobre a vaga */}
                                            <button onClick={handleShow} id="btn1" value="VerMais">Ver mais...</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        )
                    })
                }
            </div>
            <Footer />
            {
                vagas.map((item: any) => {
                    return (
                        <Modal className="Modal" show={show} onHide={handleClose} key={item.idVagas}>
                            <Modal.Header id="ModalColor" closeButton>
                                <Modal.Title id="ModalColor1" >{item.idEmpresa}</Modal.Title>
                            </Modal.Header>
                            <Modal.Body className="ModalBody">
                                <div className="bodyModal">
                                    <div className="img">
                                        {/* Imagem da vaga */}
                                        <img src="" alt="Foto vaga" />
                                    </div>
                                    <div className="title1">
                                        {/* Nome da vaga */}
                                        <h1>{item.cargo}</h1>

                                        {/* Local da vaga */}
                                        <h2>{item.localVaga}</h2>

                                        {/* Salário */}
                                        <h3>{'R$' + item.salario}</h3>
                                    </div>
                                </div>

                                <div className="informacoes">
                                    <p>{item.descricao}</p>
                                </div>
                            </Modal.Body>
                            <Modal.Footer id="ModalColor">
                                <Button id="btn" variant="primary" onClick={handleClose}>Inscrever-se</Button>
                            </Modal.Footer>
                        </Modal>
                    )
                })
            }
        </div>
    )
}

export default Vagas;