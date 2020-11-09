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
import { Item } from 'react-bootstrap/lib/Breadcrumb';

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

    const [cpf, setCpf] = useState('');
    const [senha, setSenha] = useState('');
    const [matricula, setMatricula] = useState('');


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

                var CpfSenha = Object.values(dados)[16] as any;
                var cpf = Object.values(CpfSenha)[1] as any;
                var matricula = Object.values(CpfSenha)[2] as any;
                var senha = Object.values(CpfSenha)[3] as any;

                setCpf(cpf)
                setSenha(senha)
                setMatricula(matricula)
            })


            .catch(Erro => console.error(Erro));
    }

    const Atualizar = () => {
        var DadosUsuario = {
            "nome": "Davi Takedi",
            "dataNascimento": "2008-04-30T00:00:00",
            "sexo": "Masculino",
            "escola": "Escola SENAI de Informática",
            "email": "davi@gmail.com",
            "telefone": "11974878388",
            "estadoCivil": "solteiro",
            "nivel": Object.values(dados)[8] as any,
            "tipoCurso": Object.values(dados)[9] as any,
            "curso": Object.values(dados)[10] as any,
            "turma": Object.values(dados)[11] as any,
            "turno": Object.values(dados)[12] as any,
            "termo": Object.values(dados)[13] as any,
            "idTipoUsuario": Object.values(dados)[14] as any,
            "idDados": Object.values(dados)[15] as any,
            "idDadosNavigation": {
                "id": Object.values(dados)[15] as any,
                "cpf": "487382736100",
                "numMatricula": matricula,
                "senha": "123"
            }
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
                                <Input id="InputEdit" label='Nome: ' name="" value={Object.values(usuarios)[1] as any} />
                                <button id="bt" onClick={handleShow} ><img id="IconEdit" src={IconEdit} alt="icone de edição de informaçãos" /></button>
                            </div>
                            <div className="icon">
                                <Input id="InputEdit" label="Data Nascimento:" name="" value={Object.values(usuarios)[2] as any} />
                                <button id="bt" onClick={handleShow} ><img id="IconEdit" src={IconEdit} alt="icone de edição de informaçãos" /></button>
                            </div>
                            <div className="icon">
                                <Input id="InputEdit" label="Telefone: " name="TEL" value={Object.values(usuarios)[6] as any} />
                                <button id="bt" onClick={handleShow} ><img id="IconEdit" src={IconEdit} alt="icone de edição de informação" /></button>
                            </div>
                            <div className="icon">
                                <Input id="InputEdit" label="Cpf: " name="CPF" value={cpf as any} />
                                <button id="bt" onClick={handleShow} ><img id="IconEdit" src={IconEdit} alt="icone de edição de informação" /></button>
                            </div>
                            <div className="icon">
                                <Input id="InputEdit" label="Estado Cívil: " name="EstadoCivil" value={Object.values(usuarios)[7] as any} />
                                <button id="bt" onClick={handleShow} ><img id="IconEdit" src={IconEdit} alt="icone de edição de informação" /></button>
                            </div>
                            <div className="icon">
                                <Input id="InputEdit" label="Sexo: " name="" value={Object.values(usuarios)[3] as any} />
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
                                    <Input id="InputEdit" type="password" label="Senha: " name="Senha" value={senha as any} />
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