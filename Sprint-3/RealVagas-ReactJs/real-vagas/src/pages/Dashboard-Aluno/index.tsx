import React, { useState, useEffect } from 'react';
import Footer from '../../components/Footer';
import Header from '../../components/Header';
import { Modal, Button } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import Input from '../../components/Input';
import ImgUsuario from '../../assets/image/usuario.jpg';
import IconEdit from '../../assets/image/icone-editar.png';
import '../../assets/style/global.css';
import './style.css';

function DashboardAluno() {

    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    //Atualizar dados
    const [usuario, setUsuario] = useState(''); //duas '' pois é uma string
    const [idUsuario, setIdUsuario] = useState(0); //numero 0 pois é um int Id

    const [dado, setDado] = useState('');
    const [idDado, setIdDado] = useState(0);

    const [usuarios, setUsuarios] = useState({});
    const [dados, setDadaos] = useState([]);

    useEffect(() => {
        Listar();
    }, []);


    const Listar = () => {
        var idUsuario = localStorage.getItem("Real-Vagas-Id-Usuario") as any;
        var idUrl = parseInt(idUsuario);
        fetch('http://localhost:5000/api/Usuarios/' + idUrl, {
            method: 'GET',
            headers: {
                authorization: 'Bearer ' + localStorage.getItem('Real-Vagas-Token')
            }
        })
            .then(response => response.json())
            .then(dados => {
                setUsuarios(dados)
                console.log("===========");
                console.log(dados);
                console.log("===========");
            })

            .catch(Erro => console.error(Erro));
    }

    const Atualizar = () => {
        var DadosUsuario = {
            "nome": "string",
            "dataNascimento": "2020-11-07T20:05:47.824Z",
            "sexo": "string",
            "escola": "string",
            "email": "string",
            "telefone": "string",
            "estadoCivil": "string",
            "nivel": "string",
            "tipoCurso": "string",
            "curso": "string",
            "turma": "string",
            "turno": "string",
            "termo": 0
        };

        var idUsuario = localStorage.getItem("Real-Vagas-Id-Usuario") as any;
        var idUrl = parseInt(idUsuario);

        fetch('http://localhost:5000/api/Usuarios/' + idUrl, {
            method: 'PUT',
            body: JSON.stringify(DadosUsuario),
            headers: {
                //Bearer é o token authentication, um Schema paraautenticação HTTP
                //Ele indentifica recursos protegidos por um OAuth2
                authorization: 'Bearer ' + localStorage.getItem('Real-Vagas-Token'),
                'Content-Type': 'application/json'
            }
        })
            .then(response => response.json())
            .then(dados => {
                setUsuarios(dados)
            })

            .catch(Erro => console.error(Erro));
    }


    return (
        <div>
            <Header />
            <div className="Perfil">

                <div className="title">
                    <h1>Informações pessoais</h1>
                </div>

                <div className="conteudo">
                    <div>
                        <div className="foto">
                            <img src={ImgUsuario} alt="Image de um usuário" />
                            <div className="icon">
                                <Input id="InputEdit" label='Nome: ' name="" value={Object.values(usuarios)[1] as any}   />
                                <button id="bt" onClick={handleShow} ><img id="IconEdit" src={IconEdit} alt="icone de edição de informaçãos" /></button>
                            </div>
                            <div className="icon">
                                <Input id="InputEdit" label="Data Nascimento:"  name="" value={Object.values(usuarios)[2] as any} />
                                <button id="bt" onClick={handleShow} ><img id="IconEdit" src={IconEdit} alt="icone de edição de informaçãos" /></button>
                            </div>
                            <div className="icon">
                                <Input id="InputEdit" label="Sexo: " name="" value={Object.values(usuarios)[3] as any}/>
                                <button id="bt" onClick={handleShow} ><img id="IconEdit" src={IconEdit} alt="icone de edição de informação" /></button>
                            </div>
                            <div className="icon">
                                <Input id="InputEdit" label="Escola: " name="" value={Object.values(usuarios)[4] as any} />
                                <button id="bt" onClick={handleShow} ><img id="IconEdit" src={IconEdit} alt="icone de edição de informação" /></button>
                            </div>
                            <div className="Informacoes">
                                <div className="icon">
                                    <Input id="InputEdit" label="Email: " name="Email" value={Object.values(usuarios)[5] as any} />
                                    <button id="bt" onClick={handleShow} ><img id="IconEdit" src={IconEdit} alt="icone de edição de informação" /></button>
                                </div>
                                <div className="icon">
                                    <Input id="InputEdit" label="Senha: "  name="Senha"/>
                                    <button id="bt" onClick={handleShow} ><img id="IconEdit" src={IconEdit} alt="icone de edição de informação" /></button>
                                </div>
                                <div className="icon">
                                    <Input id="InputEdit" label="Telefone: " name="TEL" value={Object.values(usuarios)[6] as any}/>
                                    <button id="bt" onClick={handleShow} ><img id="IconEdit" src={IconEdit} alt="icone de edição de informação" /></button>
                                </div>
                                <div className="icon">
                                    <Input id="InputEdit" label="Estado Cívil: " name="EstadoCivil" value={Object.values(usuarios)[7] as any} />
                                    <button id="bt" onClick={handleShow} ><img id="IconEdit" src={IconEdit} alt="icone de edição de informação" /></button>
                                </div>
                                <div className="icon">
                                    <Input id="InputEdit" label="Cpf: " name="CPF" value={Object.values(dados)[2] as any} />
                                    <button id="bt" onClick={handleShow} ><img id="IconEdit" src={IconEdit} alt="icone de edição de informação" /></button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <Footer />

            <Modal className="Modal" show={show} onHide={handleClose}>
                <Modal.Header id="ModalColor" closeButton>
                    <Modal.Title id="ModalColor1" >Alteração de dados</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Input id="InputEdit1" name="Alteração" label="Insira o dado atualizado: " />
                </Modal.Body>
                <Modal.Footer id="ModalColor">
                    <Button id="btn" variant="primary" onClick={handleClose}>
                        Salvar
            </Button>
                </Modal.Footer>
            </Modal>
        </div>
    )
}

export default DashboardAluno;