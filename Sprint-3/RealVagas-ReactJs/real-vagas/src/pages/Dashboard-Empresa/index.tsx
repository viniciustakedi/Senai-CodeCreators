import React, { useEffect, useState } from 'react';
import Footer from '../../components/Footer';
import Header from '../../components/Header';
import { Card, Col, Container, Image, Row, Table } from 'react-bootstrap'
import './style.css';
import Logo from '../../assets/image/Logo.png';
import { Link } from 'react-router-dom';
import { Pie } from 'react-chartjs-2';

function DashboardEmpresa() {

    const [vagas, setVagas] = useState([]);

    useEffect(() => {
        Listar();
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
            data: [vagas.length, 50, 90],
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
                <Table responsive="sm">
                    <thead>
                        <tr>
                            <th>Função</th>
                            <th>Salário</th>
                            <th>Recrutadora(o)</th>
                            <th>Descrição</th>
                            <th>Inscrições</th>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            vagas.map((item: any) => {
                                return (
                                    <tr>
                                        <td>{item.cargo}</td>
                                        <td>{item.salario.toFixed(2)}</td>
                                        <td>{item.nomeRecrutador}</td>
                                        <td>{item.descricao}</td>
                                        <td></td>
                                    </tr>
                                )
                            })
                        } 

                    </tbody>
                </Table>

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