import React, { useEffect, useState } from 'react';
import { Modal, Button, Card, Col, Container, Image, Row, Table, } from 'react-bootstrap';
import Footer from '../../components/Footer';
import Header from '../../components/Header';
import Input from '../../components/Input';
import '../../assets/style/global.css';
import './style.css';
import { Item } from 'react-bootstrap/lib/Breadcrumb';
import Logo from '../../assets/image/Logo.png'
import listarEmpresas from '../../assets/image/listarEmpresas.png'
import listarUsuariosimg from '../../assets/image/listarUsuariosimg.png'
import contrato from '../../assets/image/contrato.png'
import Visitas from '../../assets/image/Visitas.png'
import { Link, } from 'react-router-dom'

function DashboardAdm() {

    // Variáveis para o Modal funcionar
    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    const [show2, setShow2] = useState(false);

    const handleClose2 = () => setShow2(false);
    const handleShow2 = () => setShow2(true);

    const [show3, setShow3] = useState(false);

    const handleClose3 = () => setShow3(false);
    const handleShow3 = () => setShow3(true);


    //Começo funcionalidades vagas
    const [Empresa, setEmpresa] = useState(''); //duas '' pois é uma string
    const [idEmpresa, setIdEmpresa] = useState(0); //numero 0 pois é um int Id

    const [empresas, setEmpresas] = useState([]);

    const [Usuario, setUsuario] = useState(''); //duas '' pois é uma string
    const [idUsuario, setIdUsuario] = useState(0); //numero 0 pois é um int Id

    const [usuarios, setUsuarios] = useState([]);


    useEffect(() => {
        listar();
        listarUsuarios();


    }, []);

    //Listar vagas
    const UrlEmpresas = 'http://localhost:5000/api/Empresas';

    const UrlUsuarios = 'http://localhost:5000/api/Usuarios';


    const listar = () => {

        fetch(UrlEmpresas, {
            method: 'GET'
        })
            .then(response => response.json())
            .then(dados => {
                setEmpresas(dados)
                console.log(dados);
            })

            .catch(Erro => console.error(Erro));
    }
    const listarPorId = (id: number) => {

        fetch('http://localhost:5000/api/Empresas/BuscarPeloId/' + id, {
            method: 'GET'
        })
            .then(response => response.json())
            .then(dados => {
                setEmpresas(dados)
                console.log(dados);
            })

            .catch(Erro => console.error(Erro));
    }

    const listarUsuarios = () => {

        fetch(UrlUsuarios, {
            method: 'GET'
        })
            .then(response => response.json())
            .then(dados => {
                setUsuarios(dados)
                console.log(dados);
            })

            .catch(Erro => console.error(Erro));
    }

    const trash = (id: number) => {
        if (window.confirm('Deseja excluir a empresa?')) {
            fetch('http://localhost:5000/api/Empresas/' + id, {
                method: 'DELETE',

            })
                .then(response => response.json())
                .then(dados => {
                    listar();
                    console.log(dados);
                })
                .catch(err => console.error(err));
        }
    }

    const trashUsuarios = (id: number) => {
        if (window.confirm('Deseja excluir este usuário?')) {
            fetch('http://localhost:5000/api/Usuarios/' + id, {
                method: 'DELETE',

            })
                .then(response => response.json())
                .then(dados => {
                    listar();
                    console.log(dados);
                })
                .catch(err => console.error(err));
        }
    }

    return (
        <div>
            <Header />

            <Container >
                <Row>
                    <Col>
                        <Card className="quadro">
                            <Card.Body>

                                <div className="quadro-top">
                                    <Image id="LogoImg" src={Logo} alt="Logo real vagas" />
                                    <Card.Title>Aceitar cadastro de empresas</Card.Title>
                                </div>

                            </Card.Body>
                        </Card>
                    </Col>
                </Row>

                <Row>
                    <Col>
                        <Card className="text-center">
                            <Card.Body>
                                <Image src={listarEmpresas} className="img-fluid" />
                                <div className="card-ajuste">
                                    <Card.Title>Empresas cadastradas</Card.Title>

                                    <div className="btn-primary">
                                        <Button onClick={handleShow}>
                                            Listar
                                         </Button>
                                    </div>
                                </div>
                            </Card.Body>
                        </Card>
                    </Col>

                    <Col>
                        <Card className="text-center">
                            <Card.Body>
                                <Image src={listarUsuariosimg} className="img-fluid" />
                                <div className="card-ajuste">
                                    <Card.Title>Alunos cadastrados</Card.Title>
                                    <div className="btn-primary">
                                        <Button onClick={handleShow2}>
                                            Listar
                                         </Button>
                                    </div>
                                </div>
                            </Card.Body>
                        </Card>
                    </Col>

                    <Col>
                        <Card className="text-center">
                            <Card.Body>
                                <Image src={contrato} className="img-fluid" />
                                <div className="card-ajuste">
                                    <Card.Title>Alunos Contratados</Card.Title>

                                    <div className="btn-primary">
                                        <Link to="">Listar</Link>
                                    </div>
                                </div>
                            </Card.Body>
                        </Card>
                    </Col>


                </Row>

                <Row className="coluna">
                    <Col>
                        <Card className="text-center2">
                            <Card.Body>
                                <Image src={Visitas} className="img-fluid" />
                                <div className="card-ajuste">
                                    <Card.Title>Quantidade de visitas</Card.Title>
                                    <div className="btn-primary">
                                        <Link to="">Listar</Link>
                                    </div>
                                </div>
                            </Card.Body>
                        </Card>
                    </Col>


                </Row>
            </Container>



            <Footer />
            
            {
                empresas.map((item: any) => {
                    return (
                        <Modal className="Modal" show={show} onHide={handleClose}>
                            <Modal.Header closeButton>
                                <Modal.Title  >Empresas cadastradas</Modal.Title>
                            </Modal.Header>
                            <Modal.Body className="ModalBody" style={{ 'maxHeight': 'calc(100vh - 210px)', 'overflowY': 'auto' }}>




                                <h3>para excluir empresas clique no id desejado</h3>

                                <Table striped bordered hover size="sm">
                                    <thead>
                                        <tr>
                                            <th>Id</th>
                                            <th>Nome</th>
                                            <th>Email</th>
                                            <th>Telefone</th>
                                            <th>CNPJ</th>
                                            <th>RazaoSocial</th>
                                            <th>Responsavel</th>

                                        </tr>
                                    </thead>
                                    <tbody>
                                        {
                                            empresas.map((item: any) => {
                                                return (
                                                    <tr key={item.idEmpresa}>

                                                        <td className="td-Id"><label onClick={() => trash(item.id)}>{item.id}</label></td>
                                                        <td className="td-nome"  >{item.nome}</td>
                                                        <td className="td-email">{item.email}</td>
                                                        <td className="td-email">{item.telefone}</td>
                                                        <td className="td-email">{item.cnpj}</td>
                                                        <td className="td-email">{item.razaoSocial}</td>
                                                        <td className="td-email">{item.responsavel}</td>
                                                        {/* <td className="td-Deletar"><label onClick={() => trash(item.id)}>Deletar</label></td> */}

                                                    </tr>
                                                )
                                            })
                                        }
                                    </tbody>

                                </Table>





                            </Modal.Body>
                            <Modal.Footer>

                                <Button variant="secondary" onClick={handleClose}>
                                    Close
                        </Button>
                            </Modal.Footer>
                        </Modal>
                    )
                })
            }



            {
                usuarios.map((item: any) => {
                    return (
                        <Modal className="Modal" show={show2} onHide={handleClose2}>
                            <Modal.Header closeButton>
                                <Modal.Title  >Usuarios cadastrados</Modal.Title>
                            </Modal.Header>
                            <Modal.Body className="ModalBody" style={{ 'maxHeight': 'calc(100vh - 210px)', 'overflowY': 'auto' }}>


                                <div className="title1">


                                    <h3>para excluir usuários clique no id desejado</h3>

                                    <Table striped bordered hover size="sm">
                                        <thead>
                                            <tr>
                                                <th>Id</th>
                                                <th>Nome</th>
                                                <th>DataNascimento</th>
                                                <th>Sexo</th>
                                                <th>Escola</th>
                                                <th>Email</th>
                                                <th>Telefone</th>
                                                <th>EstadoCivil</th>
                                                <th>Nivel</th>
                                                <th>TipoCurso</th>
                                                <th>Curso</th>
                                                <th>Turma</th>
                                                <th>Turno</th>
                                                <th>Termo</th>


                                            </tr>
                                        </thead>
                                        <tbody>
                                            {
                                                usuarios.map((item: any) => {
                                                    return (
                                                        <tr key={item.idUsuario}>

                                                            <td className="td-Id"><label onClick={() => trashUsuarios(item.id)}>{item.id}</label></td>
                                                            <td className="td-nome"  >{item.nome}</td>
                                                            <td className="td-email">{item.dataNascimento}</td>
                                                            <td className="td-email">{item.sexo}</td>
                                                            <td className="td-email">{item.escola}</td>
                                                            <td className="td-email">{item.email}</td>
                                                            <td className="td-email">{item.telefone}</td>
                                                            <td className="td-email">{item.estadoCivil}</td>
                                                            <td className="td-email">{item.nivel}</td>
                                                            <td className="td-email">{item.tipoCurso}</td>
                                                            <td className="td-email">{item.curso}</td>
                                                            <td className="td-email">{item.turma}</td>
                                                            <td className="td-email">{item.turno}</td>
                                                            <td className="td-email">{item.termo}</td>
                                                            {/* <td className="td-Deletar"><label onClick={() => trash(item.id)}>Deletar</label></td> */}

                                                        </tr>
                                                    )
                                                })
                                            }
                                        </tbody>

                                    </Table>
                                </div>



                            </Modal.Body>
                            <Modal.Footer>

                                <Button variant="secondary" onClick={handleClose2}>
                                    Close
                        </Button>
                            </Modal.Footer>
                        </Modal>
                    )
                })
            }
        </div>
    )
}

export default DashboardAdm;