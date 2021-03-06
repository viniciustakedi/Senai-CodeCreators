import React, { useEffect, useState } from 'react';
import { Col, Container, Modal, Row, Table } from 'react-bootstrap';
import Button from '../../components/Button/index';
import Footer from '../../components/Footer';
import Header from '../../components/Header';
import seta from '../../assets/image/seta.png';
import { Link } from 'react-router-dom';


function PagCurriculo() {
    const [modalShow, setModalShow] = useState(false);
    const [vagas, setVagas] = useState([]);
    const [inscricoes, setInscricoes] = useState([]);
    const [titulo, setTitulo] = useState('');

    useEffect(() => {
        Listar();
    }, []);

    const ListarInscricoes = (id: any) => {
        const url = "http://localhost:5000/api/Inscricao/ListarByIdVaga/id?Id=" + id;
        fetch(url, {
            method: "GET"
        }).then(Response => Response.json())
            .then(Respost => {
                setInscricoes(Respost);
            })
            .catch(err => {
                console.error(err); //retornar um erro 
            })


        var title = vagas.filter((item: any) => item.id == id);
        setTitulo(Object.values(title[0])[5] as any);
        setModalShow(true);
    }

    const Listar = () => {
        var IdEmpresa = localStorage.getItem("Real-Vagas-Id-Usuario") as any;
        const url = "http://localhost:5000/api/Vagas/VagaByIdEmpresa/id?Id=" + IdEmpresa;
        console.log(url);
        fetch(url, {
            headers: {
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

    const formatter = new Intl.NumberFormat('en-US', {
        style: 'currency',
        currency: 'USD',
        minimumFractionDigits: 2
    })
    function MyVerticallyCenteredModal(props: any) {
        return (
            <Modal
                {...props}
                size="lg"
                aria-labelledby="contained-modal-title-vcenter"
                centered
            >
                <Modal.Body>
                    <div className="cont-vagas">
                        <div className="tit-vagas">
                            <Container>
                                <Row>
                                    <Col xs={1}><img onClick={props.onHide} src={seta} alt="" /></Col>
                                    <Col xs={10}><h5 id="title-list">{titulo}</h5></Col>
                                    <Col xs={1}></Col>
                                </Row>
                            </Container>
                        </div>

                        <div className="tab-vgs">
                            <Table responsive="sm">
                                <thead>
                                    <tr>
                                        <th>Nome</th>
                                        <th>Periodo</th>
                                        <th>Tecnico</th>
                                        <th>Currículos</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {
                                        inscricoes.map((item: any) => {
                                            return (
                                                <tr>
                                                    <td>{item.idUsuarioNavigation.nome}</td>
                                                    <td>{item.idUsuarioNavigation.turno}</td>
                                                    <td>{item.idUsuarioNavigation.curso}</td>
                                                    <td><a href={item.idUsuarioNavigation.urlCurriculo} target="_blank" >Ver Currículo</a></td>
                                                </tr>
                                            )
                                        })
                                    }
                                </tbody>
                            </Table>
                        </div>

                    </div>
                </Modal.Body>
            </Modal>
        );
    }

    return (
        <div>
            <Header />
            <div className="pag">
                <div className="pag-title">
                    <Container>
                        <Row>
                            <Col xs={1}><Link to="Dashboard"><img src={seta} alt="" /></Link></Col>
                            <Col xs={10}><h4>Currículos recebidos</h4></Col>
                            <Col xs={1}></Col>
                        </Row>
                    </Container>
                </div>

                <MyVerticallyCenteredModal
                    show={modalShow}
                    onHide={() => setModalShow(false)}
                />
                <div className="conta-pag">
                    {
                        vagas.map((item: any) => {
                            return (
                                <div className="vagas-pag">
                                    <div className="itens-pag">
                                        <div className="vagas-imagem">
                                            <img src={atob(item.foto)} alt="" />
                                        </div>
                                        <div className="info-vagas">
                                            <h5>{item.cargo}</h5>
                                            <p>{item.localVaga}</p>
                                            <p>{formatter.format(item.salario)}</p>
                                        </div>
                                    </div>

                                    <div className="button-pag">
                                        <Button onClick={() => ListarInscricoes(item.id)} name="Ver Currículos">Ver Currículos</Button>
                                    </div>
                                </div>
                            )
                        })
                    }
                </div>
            </div>
            <Footer />
        </div>
    )
}

export default PagCurriculo;