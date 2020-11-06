import React, { useState } from 'react';
import './style.css';
import Footer from '../../components/Footer';
import Header from '../../components/Header';
import Input from '../../components/Input';
import { useHistory, Link } from 'react-router-dom';
import { Col, Container, Row } from 'react-bootstrap';
import seta from '../../assets/image/seta.png';
import Logo from '../../assets/image/Logo.png';
import { stringify } from 'querystring';

function Oportunidade() {
    let history = useHistory();

    const [empresa, setEmpresa] = useState('');
    const [recrutador, setRecrutador] = useState('');
    const [local, setLocal] = useState('');
    const [cargo, setCargo] = useState('');
    const [contrato, setContrato] = useState('');
    const [publicacao, setPublicacao] = useState(new Date());
    const [qtdVagas, setqtdVagas] = useState(0);
    const [salario, setSalario] = useState(0.00);
    const [descricao, setDescricao] = useState("");
    const [foto, setFoto] = useState('');
    const [combinar, setCombinar] = useState(false);

    const handleClick = () => setCombinar(!combinar);

    function ConvertImg(item: any) {
        if (item.length > 0) {
            var fileToLoad = item[0];
            var fileReader = new FileReader();
            fileReader.onload = function (fileLoadedEvent: any) {
                var base64value = fileLoadedEvent.target.result;
                setFoto(btoa(base64value));
            };
            fileReader.readAsDataURL(fileToLoad);
        }
    }

    var IdEmpresa = localStorage.getItem("Real-Vagas-Id-Usuario") as any;

    const Salvar = () => {
        const form = {
            nomeRecrutador: recrutador,
            localVaga: local,
            tipoContrato: contrato,
            dataPublicacao: publicacao,
            cargo: cargo,
            qntVagas: qtdVagas,
            salario: (combinar == true) ? 0.00 : salario,
            descricao: descricao,
            foto: foto,
            statusVaga: true,
            idEmpresa: parseInt(IdEmpresa)
        };
        console.log(JSON.stringify(form))

        fetch("http://localhost:5000/api/Vagas", {
            headers: {
                authorization: 'Bearer ' + localStorage.getItem('Real-Vagas-Token'),
                'Content-Type': 'application/json'
            },
            method: "POST",
            body: JSON.stringify(form)
        })
            .then(() => {
                history.push("/Dashboard");
            }).catch(err => {
                console.error(err);
            });
    }

    return (
        <div>
            <Header />
            <div className="express">
                <form onSubmit={e => {
                    e.preventDefault();
                    Salvar();
                }}>

                    <div className="container-express">

                        <div className="express-title">
                            <Container>
                                <Row>
                                    <Col id="seta" xs={1}><Link to="/Dashboard"><img src={seta} alt="" /></Link></Col>
                                    <Col xs={10}>
                                        <div className="title-principal">
                                            <img src={Logo} />
                                            <h3>Cadastro de vaga</h3>
                                        </div>
                                    </Col>
                                    <Col xs={1}></Col>
                                </Row>
                            </Container>
                        </div>

                        <div className="express-cont">
                            <div>
                                <Input onChange={e => setEmpresa(e.target.value)} className="inputsVagas" id="campo" label="Nome da empresa:" name="NomeEmpresa:" />
                                <Input onChange={e => setLocal(e.target.value)} className="inputsVagas" id="campo" label="Local:" name="Local" />
                                <Input onChange={e => setCargo(e.target.value)} className="inputsVagas" id="campo" label="Nome do cargo:" name="NomeCargo" />
                                <Input disabled={combinar} onChange={e => setSalario(parseFloat(e.target.value))} className="inputsVagas" label="Valor do salário:" name="salario" />
                                <div className="inputPerson">
                                    <label htmlFor="Descricao">Descrição da vaga:</label>
                                    <textarea onChange={e => setDescricao(e.target.value)} id="campo" name="Descricao"></textarea>
                                </div>
                            </div>
                            <div>
                                <Input onChange={e => setRecrutador(e.target.value)} className="inputsVagas" id="campo" label="Nome do recrutador(a):" name="recrutador" />
                                <Input onChange={e => setContrato(e.target.value)} className="inputsVagas" id="campo" label="Tipo de contrato:" name="contrato" />
                                <Input type="number" onChange={e => setqtdVagas(parseInt(e.target.value))} className="inputsVagas" id="campo" label="Quantidade de vagas:" name="QuantidadeVagas" />
                                <div className="toggle">
                                    <label id="toggle-menu" className="switch">
                                        <input onClick={handleClick} checked={combinar} type="checkbox" />
                                        <span className="slider round"></span>
                                    </label>
                                    <label>Á combinar salário</label>
                                </div>
                                <div className="FilePerson">
                                    <Input onChange={e => ConvertImg(e.target.files)} id="arquivo" type="file" label="Selecione o logo da empresa" name="arquivo" />
                                </div>
                            </div>
                        </div>
                        <div className="btnVagas">
                            <Input type="submit" label="publicas" value="Publicar vaga" name="Publicar" />
                        </div>
                    </div>
                </form>
            </div>
            <Footer />
        </div>
    )
}

export default Oportunidade;