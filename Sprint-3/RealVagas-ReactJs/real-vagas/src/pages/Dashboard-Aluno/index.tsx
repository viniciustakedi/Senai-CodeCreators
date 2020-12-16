import React, { useState, useEffect } from 'react';
import Footer from '../../components/Footer';
import Header from '../../components/Header';
import { Link, useHistory } from 'react-router-dom';
import Input from '../../components/Input';
import ImgUsuario from '../../assets/image/usuario.jpg';
import IconEdit from '../../assets/image/icone-editar.png';
import '../../assets/style/global.css';
import './style.css';
import { Item } from 'react-bootstrap/lib/Breadcrumb';
import { cpf } from '../../components/InputCurrency/Mask';

function DashboardAluno() {

    //Atualizar dados
    const [idUsuario, setIdUsuario] = useState(0); //numero 0 pois é um int Id

    const [usuarios, setUsuarios] = useState([]);
    const [dados, setDados] = useState([]);

    const [cpf1, setCpf1] = useState('');
    const [senha, setSenha] = useState('');
    const [matricula, setMatricula] = useState('');

    const [nome, setNome] = useState('');
    const [data, setData] = useState('');
    const [sexo, setSexo] = useState('');
    const [estado, setEstado] = useState('');
    const [url, setUrl] = useState('');
    const [telefone, setTelefone] = useState('');
    const [email, setEmail] = useState('');
    const [escola, setEscola] = useState('');

    const [dadosSenha, setDadosSenha] = useState('');
    const [dadosCpf, setDadosCpf] = useState('');


    useEffect(() => {
        Listar();
    }, []);

    let history = useHistory();


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

                var CpfSenha = Object.values(dados)[17] as any;
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
        console.log(url)

        const DadosUsuario = {
            "nome": nome == Object.values(usuarios)[1] || nome == "" ? Object.values(usuarios)[1] : nome,
            "dataNascimento": data == Object.values(usuarios)[2] || data == "" ? Object.values(usuarios)[2] : data,
            "sexo": sexo == Object.values(usuarios)[3] || sexo == "" ? Object.values(usuarios)[3] : sexo,
            "escola": escola == Object.values(usuarios)[4] || escola == "" ? Object.values(usuarios)[4] : escola,
            "email": email == Object.values(usuarios)[5] || email == "" ? Object.values(usuarios)[5] : email,
            "telefone": telefone == Object.values(usuarios)[6] || telefone == "" ? Object.values(usuarios)[6] : telefone,
            "estadoCivil": estado == Object.values(usuarios)[7] || estado == "" ? Object.values(usuarios)[7] : estado,
            "UrlCurriculo": url == Object.values(usuarios)[8] || url == "" ? Object.values(usuarios)[8] : url,
            "nivel": Object.values(usuarios)[9] as any,
            "tipoCurso": Object.values(usuarios)[10] as any,
            "curso": Object.values(usuarios)[11] as any,
            "turma": Object.values(usuarios)[12] as any,
            "turno": Object.values(usuarios)[13] as any,
            "termo": Object.values(usuarios)[14] as any,
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
            .then(() => {
                window.location.reload();
            })

            .catch(Erro => console.error(Erro));
    }

    function DadosSigilosos() {
        const form = {
            "cpf": dadosCpf == cpf1 || dadosCpf == "" ? cpf1 : dadosCpf, 
            "numMatricula": matricula,
            "senha": dadosSenha == senha || dadosSenha == "" ? senha : dadosSenha,
        };

        var IdUsuario_sigiloso =  Object.values(usuarios)[16] as any
        const UrlDados = "http://localhost:5000/api/Dados/" +IdUsuario_sigiloso;

        fetch(UrlDados, {
            method: 'PUT',
            body: JSON.stringify(form),
            headers: {
                //Bearer é o token authentication, um Schema paraautenticação HTTP
                //Ele indentifica recursos protegidos por um OAuth2
                authorization: 'Bearer ' + localStorage.getItem('Real-Vagas-Token'),
                'Content-Type': 'application/json'
            }
        })
            .then(() => {
                window.location.reload();
            })

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
                                <Input onChange={e => setNome(e.target.value)} name="" id="InputEdit" label='Nome:' placeholder={Object.values(usuarios)[1]} />
                            </div>
                            <div className="icon">
                                <Input onChange={e => setEmail(e.target.value)} id="InputEdit" label="Email: " name="Email" placeholder={Object.values(usuarios)[5] as any} />
                            </div>
                            <div className="icon">
                                <Input onChange={e => setUrl(e.target.value)} id="InputEdit" label="Url Currículo" name="UrlCurriculo" placeholder={Object.values(usuarios)[8] as any} />
                            </div>
                            <div className="icon">
                                <Input onChange={e => setData(e.target.value)} id="InputEdit" label="Data Nascimento:" name="" placeholder={Object.values(usuarios)[2] as any} />
                            </div>
                            <div className="icon">
                                <Input onChange={e => setTelefone(e.target.value)} id="InputEdit" label="Telefone: " name="TEL" placeholder={Object.values(usuarios)[6] as any} />
                            </div>
                            <div className="icon">
                                <Input onChange={e => setEstado(e.target.value)} id="InputEdit" label="Estado Cívil: " name="EstadoCivil" placeholder={Object.values(usuarios)[7] as any} />
                            </div>
                            <div className="icon">
                                <Input onChange={e => setSexo(e.target.value)} id="InputEdit" label="Sexo: " name="" placeholder={Object.values(usuarios)[3] as any} />
                            </div>
                            <div className="icon">
                                <Input onChange={e => setEscola(e.target.value)} id="InputEdit" label="Escola: " name="" placeholder={Object.values(usuarios)[4] as any} />
                            </div>
                            <input type="submit" id="btn1" onClick={Atualizar} value="salvar" />
                            <div className="Informacoes">
                                <h3 id='dadosSig'>Dados sigilosos: </h3>
                                <div className="icon">
                                    <Input onChange={e => setDadosSenha(e.target.value)} id="InputEdit" type="password" label="Senha: " name="Senha" placeholder={senha as any} />
                                    <button onClick={DadosSigilosos} id="bt"  ><img id="IconEdit" src={IconEdit} alt="icone de edição de informação" /></button>
                                </div>
                                <div className="icon">
                                    <Input onChange={e => setDadosCpf(e.target.value)} id="InputEdit" label="Cpf: " name="CPF" placeholder={cpf1 as any} />
                                    <button onClick={DadosSigilosos} id="bt" ><img id="IconEdit" src={IconEdit} alt="icone de edição de informação" /></button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <Footer />
        </div>
    )
}


export default DashboardAluno;
