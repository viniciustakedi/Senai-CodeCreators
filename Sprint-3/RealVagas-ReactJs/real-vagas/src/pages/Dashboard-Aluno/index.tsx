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
import { cpf } from '../../components/InputCurrency/Mask';
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

    const [cpf1, setCpf1] = useState('');
    const [senha, setSenha] = useState('');
    const [matricula, setMatricula] = useState('');

    const [nome, setNome] = useState('');
    const [data, setData] = useState('');
    const [telefone, setTelefone] = useState('');

    useEffect(() => {
        Listar();
    }, []);


    const Listar = () => {
        var idUsuario = localStorage.getItem("Real-Vagas-Id-Usuario") as any;
        var idUrl = parseInt(idUsuario);
        fetch('http://localhost:5000/api/Usuarios/' + idUrl, {
            method: 'GET',
            headers: {
                authorization: 'Bearer ' + localStorage.getItem('Real-Vagas-Token'),
                'content-type': 'application/json',
            }
        })
            .then(response => response.json())
            .then(dados => {
                setUsuarios(dados)
                setIdUsuario(dados.id)

                var CpfSenha = Object.values(dados)[16] as any;
                var cpf = Object.values(CpfSenha)[1] as any;
                var matricula = Object.values(CpfSenha)[2] as any;
                var senha = Object.values(CpfSenha)[3] as any;

                setCpf1(cpf)
                setSenha(senha)
                setMatricula(matricula)
            })


            .catch(Erro => console.error(Erro));
    } 

    const Atualizar = () => {

        //fazer um if ternario para manter o valor caso nào seja alterado
        //problema pegar a string digitada

        console.log(Object.values(usuarios)[1]);
        console.log(nome);

        const DadosUsuario = {
            "nome":  nome != Object.values(usuarios)[1] ? nome : Object.values(usuarios)[1],
            "dataNascimento": data != Object.values(usuarios)[2] ? data : Object.values(usuarios)[2],
            "sexo": "Masculino",
            "escola": "SENAI de Informatica",
            "email": "pedro@email.com",
            "telefone": telefone,
            "estadoCivil": "solteiro",
            "nivel": Object.values(usuarios)[8] as any,
            "tipoCurso": Object.values(usuarios)[9] as any,
            "curso": Object.values(usuarios)[10] as any,
            "turma": Object.values(usuarios)[11] as any,
            "turno": Object.values(usuarios)[12] as any,
            "termo": Object.values(usuarios)[13] as any,
            "idTipoUsuario": Object.values(usuarios)[14] as any,
            "idDados": Object.values(usuarios)[15] as any,
            "idDadosNavigation": {
                "id": Object.values(usuarios)[15] as any,
                "cpf": "3912831231",
                "numMatricula": "39878482",
                "senha": "123",
                "dbUsuarios": []
            },
            "dbInscricao": []
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
                                <Input onChange={e => setNome(e.target.value)} name="" id="InputEdit" label='Nome:' placeholder={Object.values(usuarios)[1]}/>
                            </div>
                            <div className="icon">
                                <Input onChange={e => setData(e.target.value)} id="InputEdit" label="Data Nascimento:" name="" placeholder={Object.values(usuarios)[2] as any} />
                            </div>
                            <div className="icon">
                                <Input onChange={e => setTelefone(e.target.value)} id="InputEdit" label="Telefone: " name="TEL" placeholder={Object.values(usuarios)[6] as any} />
                            </div>
                            <div className="icon">
                                <Input id="InputEdit" label="Estado Cívil: " name="EstadoCivil" placeholder={Object.values(usuarios)[7] as any} />
                            </div>
                            <div className="icon">
                                <Input id="InputEdit" label="Sexo: " name="" placeholder={Object.values(usuarios)[3] as any} />
                            </div>
                            <div className="icon">
                                <Input id="InputEdit" label="Escola: " name="" placeholder={Object.values(usuarios)[4] as any} />
                            </div>
                            <div className="Informacoes">
                                <div className="icon">
                                    <Input id="InputEdit" label="Email: " name="Email" placeholder={Object.values(usuarios)[5] as any} />
                                </div>
                                <div className="icon">
                                    <Input id="InputEdit" type="password" label="Senha: " name="Senha" placeholder={senha as any} />
                                    <button id="bt" onClick={handleShow} ><img id="IconEdit" src={IconEdit} alt="icone de edição de informação" /></button>
                                </div>
                            <div className="icon">
                                <Input id="InputEdit" label="Cpf: " name="CPF" placeholder={cpf1 as any }/>
                                <button id="bt" onClick={handleShow} ><img id="IconEdit" src={IconEdit} alt="icone de edição de informação" /></button>
                            </div>
                            </div> 
                            <input type="submit" id="btn1" onClick={Atualizar} value="salvar" />
                        </div>
                    </div>
                </div>
            </div>
            <Footer />
        </div>
    )
}


export default DashboardAluno;
