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

    const [usuarios, setUsuarios] = useState([]);
    const [dados, setDadaos] = useState([]);

    useEffect(() => {
        Listar();
    }, []);

    const Listar = () => {
        fetch('http://localhost:5000​/api​/Usuarios​/', {
            method: 'GET',
            headers: {
                //Bearer é o token authentication, um Schema paraautenticação HTTP
                //Ele indentifica recursos protegidos por um OAuth2
                authorization: 'Bearer ' + localStorage.getItem('Real-Vagas-Token, Real-Vagas-Id-Usuario')
            }
        })
            .then(response => response.json())
            .then(dados => {
                setUsuarios(dados)
                console.log(dados);
            })

            .catch(Erro => console.error(Erro));
    }

    //Atualizar usuario
    const Atualizar = (id: number) => {
        fetch('http://localhost:5000​/api​/Usuarios​/' + id, {
            method: 'GET',
            headers: {
                authorization: 'Bearer ' + localStorage.getItem('Real-Vagas-Token')
            }
        })
            .then(response => response.json())
            .then(dados => {
                setIdUsuario(dados.idUsuario);
                setIdDado(dados.idDado);
                setUsuario(dados.nome);
                setUsuario(dados.dataNascimento);
                setUsuario(dados.sexo);
                setUsuario(dados.escola);
                setUsuario(dados.email);
                setDado(dados.senha);
                setUsuario(dados.telefone);
                setUsuario(dados.EstadoCivil);
                setDado(dados.cpf);
            })
            .catch(err => console.error(err));
    }

    return (
        <div>
            <Header />
            <div className="Perfil">

                <div className="title">
                    <h1>Informações pessoais</h1>
                </div>
                
                <div className="conteudo">
                    {
                        usuarios.map((item: any) => {
                            return (
                                <div key={item.id}>
                                    <div className="foto">
                                        <img src={ImgUsuario} alt="Image de um usuário" />
                                        <div className="icon">
                                            <Input id="InputEdit" label="Nome: " name="Nome">{item.nome}</Input>
                                            <button id="bt" onClick={handleShow} ><img id="IconEdit" src={IconEdit} alt="icone de edição de informaçãos" /></button>
                                        </div>
                                        <div className="icon">
                                            <Input id="InputEdit" label="Data Nascimento: " name="DataNascimento">{item.dataNascimento}</Input>
                                            <button id="bt" onClick={handleShow} ><img id="IconEdit" src={IconEdit} alt="icone de edição de informaçãos" /></button>
                                        </div>
                                        <div className="icon">
                                            <Input id="InputEdit" label="Sexo: " name="Sexo">{item.sexo}</Input>
                                            <button id="bt" onClick={handleShow} ><img id="IconEdit" src={IconEdit} alt="icone de edição de informação" /></button>
                                        </div>
                                        <div className="icon">
                                            <Input id="InputEdit" label="Escola: " name="Escola">{item.escola}</Input>
                                            <button id="bt" onClick={handleShow} ><img id="IconEdit" src={IconEdit} alt="icone de edição de informação" /></button>
                                        </div>
                                        <div className="Informacoes">
                                            <div className="icon">
                                                <Input id="InputEdit" label="Email: " name="Email" />
                                                <button id="bt" onClick={handleShow} ><img id="IconEdit" src={IconEdit} alt="icone de edição de informação" /></button>
                                            </div>
                                            <div className="icon">
                                                <Input id="InputEdit" label="Senha: " name="Senha" />
                                                <button id="bt" onClick={handleShow} ><img id="IconEdit" src={IconEdit} alt="icone de edição de informação" /></button>
                                            </div>
                                            <div className="icon">
                                                <Input id="InputEdit" label="Telefone: " name="TEL" />
                                                <button id="bt" onClick={handleShow} ><img id="IconEdit" src={IconEdit} alt="icone de edição de informação" /></button>
                                            </div>
                                            <div className="icon">
                                                <Input id="InputEdit" label="Estado Cívil: " name="EstadoCivil" />
                                                <button id="bt" onClick={handleShow} ><img id="IconEdit" src={IconEdit} alt="icone de edição de informação" /></button>
                                            </div>
                                            <div className="icon">
                                                <Input id="InputEdit" label="Cpf: " name="CPF" />
                                                <button id="bt" onClick={handleShow} ><img id="IconEdit" src={IconEdit} alt="icone de edição de informação" /></button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            )
                        })
                    }

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