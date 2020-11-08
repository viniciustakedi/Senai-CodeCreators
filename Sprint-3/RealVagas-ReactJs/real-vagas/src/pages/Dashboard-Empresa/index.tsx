import React, { useEffect, useState } from 'react';
import Footer from '../../components/Footer';
import Header from '../../components/Header';
import { Card, Col, Container, Image, Row } from 'react-bootstrap'
import './style.css';
import Logo from '../../assets/image/Logo.png';
import { Link, useHistory } from 'react-router-dom';
import { Pie } from 'react-chartjs-2';
import Button from '../../components/Button';

function DashboardEmpresa() {

    const [vagas, setVagas] = useState([]);
    const[grafic, setgrafic] = useState([]);

    useEffect(() => {
        Listar();
        grafico();
    }, []);

    const legends = {
        display: false,
        position: "bottom",
        textDirection: "column",
        labels: {
            fontColor: "#323130",
            fontSize: 14
        }
    } as any;

    const data = {
        labels: [
            'Vagas Cadastradas',
            'Currículos Recebidos',
            'Mensagem Enviadas'
        ],
        colors: [
            '#C5483E',
            '#79CC76',
            '#005086'
        ],
        datasets: [{
            data: [vagas.length, grafic.length, 0],
            backgroundColor: [
                '#C5483E',
                '#79CC76',
                '#005086'
            ]
        }]
    };

    var dados = [{}];
    const generate = () => {
        let count = 0;
        var obj = {};
        data.labels.map((item: any) => {
            obj = { "name": item, "color": data.colors[count], "valor": data.datasets[0].data[count] };
            dados[count] = obj;
            count++;
        });

        dados.sort(function (a: any, b: any) {
            return a.valor - b.valor;
        }).reverse()
        return (
            <ul>
                {
                    dados.map((item: any) =>
                        <li>
                            <div>
                                <div className="ponto" style={{ backgroundColor: item.color }}></div>
                                <li>{item.name}</li>
                            </div>
                            <p id="sub-title">{item.valor}</p>
                        </li>
                    )
                }
            </ul>
        );
    }


    const Listar = () => {
        var IdEmpresa = localStorage.getItem("Real-Vagas-Id-Usuario") as any;
        const url = "http://localhost:5000/api/Vagas/VagaByIdEmpresa/id?Id=" + IdEmpresa;
        console.log(url);
        fetch(url, {
            headers:{
                authorization: 'Bearer ' + localStorage.getItem('Real-Vagas-Token')
            },
            method: "GET"
        }).then(Response => Response.json())
            .then(Respost => {
                setVagas(Respost);
                console.log(Respost);
            })
            .catch(err => {
                console.log("Deu erro!!!")
                console.error(err); //retornar um erro 
            })
    }

    const grafico = () =>{
        var IdEmpresa =  localStorage.getItem("Real-Vagas-Id-Usuario") as any;
        const url = "http://localhost:5000/api/Inscricao/ListarByIdEmpresa/id?Id="+IdEmpresa;
        console.log(url);
        fetch(url,{
            headers:{
                authorization: 'Bearer ' + localStorage.getItem('Real-Vagas-Token')
            },
            method: "GET"
        }).then(Response => Response.json())
        .then(Respost =>{
            setgrafic(Respost);
        })
        .catch(err => {
          console.error(err); //retornar um erro 
      })
    }

    const Deleta = (Id:any) => {
        let resposta = window.prompt("Digite 'excluir vaga' para excluir essa vaga:")?.toLowerCase();

        console.log(resposta);
        if(resposta == "excluir vaga")
        {
            const form ={
                StatusVaga: false
            }
            const url = "http://localhost:5000/api/Vagas/" + Id;
            fetch(url, {
                headers:{
                authorization: 'Bearer ' + localStorage.getItem('Real-Vagas-Token'),
                'Content-Type': 'application/json'
            },
            method: "PUT",
            body: JSON.stringify(form)
        }).then(()=>{
            Listar();
        })
        .catch(err => {
            console.log("Deu erro!!!")
            console.error(err); //retornar um erro 
        })
    }
}

    return (
        <div>
            <Header />
            <Container className="Banner fluid"></Container>
            <Container >
                <Row>
                    <Col>
                        <Card className="text-center">
                            <Card.Body>
                                <Image src={Logo} className="img-fluid" />
                                <div className="card-ajuste">
                                    <Card.Title>Criar anúncio de vaga
                        <br /><br /></Card.Title>
                                    <div className="button-card">
                                        <Link to="/CadastroVaga">Criar</Link>
                                    </div>
                                </div>
                            </Card.Body>
                        </Card>
                    </Col>

                    <Col>
                        <Card className="text-center">
                            <Card.Body>
                                <Image src={Logo} className="img-fluid" />
                                <div className="card-ajuste">
                                    <Card.Title>Seleciona currículos recebidos</Card.Title>
                                    <div className="button-card">
                                        <Link to="/Curriculos">Selecionar</Link>
                                    </div>
                                </div>
                            </Card.Body>
                        </Card>
                    </Col>
                </Row>

            </Container>
            <div className="tabela-dash">
                <table >
                    <thead>
                        <tr>
                            <th>Função</th>
                            <th>Salário</th>
                            <th>Recrutadora(o)</th>
                            <th>Local</th>
                            <th>Inscrições</th>
                            <th>Deletar</th>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            vagas.map((item: any) => {
                                return (
                                    <tr>
                                        <td>{item.cargo}</td>
                                        <td>R$ {item.salario.toFixed(2)}</td>
                                        <td>{item.nomeRecrutador}</td>
                                        <td>{item.localVaga}</td>
                                        <td><Link id="link-dash" to="/Curriculos">Ver Inscrições</Link></td>
                                        <td><Button id="button-dash" name="Deletar" onClick={() =>Deleta(item.id)}/></td>
                                    </tr>
                                )
                            })
                        } 

                    </tbody>
                </table>

                <div className="grafico">
                    <p className="title-grafico">Estatísticas dos ultimos 30 dias</p>
                    <Pie legend={legends}data={data}/>

                    <div className="legends">{generate()}</div>
                </div>
            </div>

            <Footer />
        </div>
    )
}

export default DashboardEmpresa;