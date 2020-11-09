import React, { useEffect, useState } from 'react';
import { Modal, Button } from 'react-bootstrap';
import Footer from '../../components/Footer';
import Header from '../../components/Header';
import { parseJWT } from '../../services/auth';
import ButtonInscricao from '../../components/Button-inscricao';
import ImgLupa from '../../assets/image/icone-busca.png';
import '../../assets/style/global.css';
import './style.css';


function Vagas() {

    // Variáveis para o Modal funcionar
    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);

    const handleShow = (id: any) => {
        const item = vagas.filter((element: any) => element.id === id);
        setModal(item);
        setShow(true);
    }

    //Começo funcionalidades vagas

    //useState é um Hook que te permite adicionar o state do React a um componente de função.
    //O state, em React, é onde guardamos os dados do nosso componente
    const [cargoVaga, setCargoVaga] = useState('');
    const [nomeEmpresa, setNomeEmpresa] = useState('')

    const [inscricao, setInscricao] = useState('');
    const [inscricaoTrue, setInscricaoTrue] = useState([]);
    const [inscricoes, setInscricoes] = useState([]);


    const [idVaga, setIdVaga] = useState(0); //numero 0 pois é um int Id
    const [vagas, setVagas] = useState([]);

    const [modal, setModal] = useState([]);

    useEffect(() => {
        listar();
        InscricoesUsuario();
        parseJWT();
    }, []);

    //Listar vagas
    const UrlVagas = 'http://localhost:5000/api/Vagas';

    const listar = () => {

        fetch(UrlVagas, {
            method: 'GET'

        })
            .then(response => response.json())
            .then(dados => {
                setVagas(dados)
            })

            .catch(Erro => console.error(Erro));
    }

    //Função para buscar a vaga
    function buscarVaga(cargo: string) { //Paramêtro: cargo é uma string

        //se vagas for diferente de indefinido ele executa
        if (vagas.length != 0) {
            //Variavel Filtrados com filter para a pesquisa de vagas.
            //O que o filter faz: A função Filter recebe como parâmetro uma função de callback, onde o retorno dado será um novo array com os elementos que passaram na validação realizada. Lembrando que o array original não é alterado, trazendo assim um dos conceitos da programação funcional.   
            //vaga: any define que vaga pode ser qualquer tipo de objeto, podendo ser int, string etc.
            //=> (arrow function) vaga.cargo busca pelo nome da vaga que se denomina "cargo" na array
            //toUpperCase define que todas as letras vao ser maiusculas
            //includes determina se um conjunto de caracteres pode ser encontrado dentro de outra string, retornando true ou false. ou seja, ele pesquisa e se existir é true se n existir é false, retorna ou não retorna
            //O parametro dentro do includes serve para todas as vagas aparecerem quando n há nada digitado no input de pesquisa.
            var filtrados = vagas.filter((vaga: any) => vaga.cargo.toUpperCase().includes(cargo.toUpperCase()));
            console.log(filtrados)
            //Se os filtrador forem diferente de indefinido ele executa
            if (filtrados != undefined)
                return filtrados; //Retorna a vaga que o usuario pesquisou
        }
        return vagas; //Retorna todas as vagas
    }


    ;

    // // Obtém a data/hora atual
    // var data = new Date();

    // // Guarda cada pedaço em uma variável
    // var dia = data.getDate();           // 1-31
    // var dia_sem = data.getDay();            // 0-6 (zero=domingo)
    // var mes = data.getMonth();          // 0-11 (zero=janeiro)
    // var ano4 = data.getFullYear();       // 4 dígitos
    // var hora = data.getHours();          // 0-23
    // var min = data.getMinutes();        // 0-59
    // var seg = data.getSeconds();        // 0-59
    // var mseg = data.getMilliseconds();   // 0-999
    // var tz = data.getTimezoneOffset(); // em minutos

    // // Formata a data e a hora (note o mês + 1)
    // var str_hora = hora + ':' + min + ':' + seg; 
    // var str_data = ano4 +'/'+ (mes + 1) + '/' + dia ;

    // // Mostra o resultado
    // console.log(str_data);

    //Postar inscricao


    const Inscrito = (id: any) => {
        var inscricao = {};
        var Metodo = "";
        var UrlInscricao = "";
        const itemBuscado = Object.values(inscricoes).filter((user:any)=> user.idVaga === id)

        var IdInscricao = (itemBuscado.length != 0 ) ? Object.values(itemBuscado[0])[0] : false;

        console.log(itemBuscado.length)
        UrlInscricao = (itemBuscado.length == 0) ? "http://localhost:5000/api/Inscricao/" : "http://localhost:5000/api/Inscricao/" + IdInscricao;

        Metodo = (itemBuscado.length == 0) ? "POST" : "PUT";

        var putStatus = (itemBuscado.length != 0 && Object.values(itemBuscado[0])[1] == false)? true : false;

        if (itemBuscado.length == 0) {
            inscricao = {
                statusInscricao: true,
                dataInscricao: new Date(),
                idVaga: id,
                idUsuario: parseInt(localStorage.getItem("Real-Vagas-Id-Usuario") as any)
            }
        } 
        else
        {
            inscricao = {
                statusInscricao: putStatus,
                dataInscricao: new Date(),
                idVaga: id,
                idUsuario: parseInt(localStorage.getItem("Real-Vagas-Id-Usuario") as any)
            }
        }

        console.log(JSON.stringify(inscricao));
        console.log(Metodo);
        console.log(UrlInscricao)

        fetch(UrlInscricao, {
            method: Metodo,
            body: JSON.stringify(inscricao),
            headers: {
                authorization: 'Bearer ' + localStorage.getItem('Real-Vagas-Token'),
                'content-type': 'application/json', //Tipo do conteudo é uma aplicação Json
            },
        })
        .then(()=>{
            var putButton = (itemBuscado.length == 0)? id : Object.values(itemBuscado[0])[3]; 
            console.log(putButton)
            ButtonChange(putButton);
            InscricoesUsuario();
        })
            .catch(Erro => console.error(Erro));

    }


    var idUsuarioInsc = localStorage.getItem("Real-Vagas-Id-Usuario") as any;

    //Listar as inscrições do usuário
    const InscricoesUsuario = () => {
        fetch("http://localhost:5000/api/Inscricao/ListarById/id?id=" + idUsuarioInsc, {
            method: 'GET',
            headers: {
                authorization: 'Bearer ' + localStorage.getItem('Real-Vagas-Token'),
                'content-type': 'application/json', //Tipo do conteudo é uma aplicação Json
            }
        })
            .then(response => response.json())
            .then(dados => {
                setInscricoes(dados)
            })

            .catch(Erro => console.error(Erro));
    }


    function ButtonChange(id: any) {
        if(inscricoes.length !== 0)
        {
            const itemBuscado = Object.values(inscricoes).filter((user:any)=> user.idVaga === id)
            var string = "";
            var bool;

            itemBuscado.map((item: any) => {
                bool = item.statusInscricao
            })
            
            if (bool == true) {
                
                string = "Inscrito";
            }
            else {
                string = "Inscrever-se";
            }
            
            return string;
        }else{
            return "Inscrever-se";
        }
    }


        const formatter = new Intl.NumberFormat('en-US', {
        style: 'currency',
        currency: 'USD',
        minimumFractionDigits: 2
            })
    return (
        <div>
            <Header />
            <div className="vagas">
                <div className="title">
                    <h1>Encontre a sua vaga!</h1>
                </div>

                {/* Formulário para enviar/executar/chamar uma ação */}
                <form onSubmit={event => {
                    event.preventDefault();
                    buscarVaga(cargoVaga);
                }}>
                    <div className="pesquisa">
                        <img src={ImgLupa} alt="Icone de uma lupa" />
                        {/* Mecanismo de pesquisa de vagas*/}
                        <input type="text" id="InputEdit" value={cargoVaga} onChange={e => setCargoVaga(e.target.value)} placeholder="Buscar vaga"></input>
                    </div>
                </form>
                {
                    //Chama função buscar vaga junto com as vagas no paramêtro.
                    buscarVaga(cargoVaga).map((item: any) => {
                        return (
                            <div className="fetch" key={item.idVagas}>
                                <div className="Conteudo" >
                                    <div className="TitleImg">
                                        <div className="img">
                                            {/* Imagem da vaga */}
                                            <img src={atob(item.foto)} alt="Foto vaga" />
                                        </div>
                                        <div className="title1">
                                            {/* Nome da vaga */}
                                            <h1>{item.cargo}</h1>

                                            {/* Local da vaga */}
                                            <h2>{item.localVaga}</h2>

                                            {/* Salário */}
                                            <h3>{'Salário: R$ ' + formatter.format(item.salario)}</h3>
                                        </div>


                                    </div>

                                    <div className="buttons">
                                        <div className="inscricao">
                                            {/* Botão para inscrever-se na vaga */}
                                            <ButtonInscricao id="Botao" onClick={() => Inscrito(item.id)} value={ButtonChange(item.id)} />
                                        </div>
                                        <div className="verMais">
                                            {/* Botão para ver mais informação sobre a vaga */}
                                            <button onClick={() => handleShow(item.id)} id="btn1" value="VerMais">Ver mais...</button>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        )
                    })
                }
            </div>
            <Footer />
            <div>
                {
                    modal.map((dado: any) => {
                        return (
                            <Modal className="Modal" show={show} onHide={handleClose} >
                                <Modal.Header id="ModalColor" closeButton>
                                    <Modal.Title id="ModalColor1" >{dado.nomeEmpresa}</Modal.Title>
                                </Modal.Header>
                                <Modal.Body className="ModalBody">
                                    <div className="bodyModal">
                                        <div className="img">
                                            {/* Imagem da vaga */}
                                            <img src={atob(dado.foto)} alt="Foto vaga" />
                                        </div>
                                        <div className="title1">
                                            {/* Nome da vaga */}
                                            <h1>{dado.cargo}</h1>

                                            {/* Local da vaga */}
                                            <h2>{dado.localVaga}</h2>

                                            {/* Salário */}
                                            <h3>{'Salário: R$ ' + dado.salario.toFixed(3)}</h3>
                                        </div>
                                    </div>

                                    <div className="informacoes">
                                        <div className="ulInformacoes">
                                            <h5>Informações</h5>
                                            <ul>
                                                <li>{'Recrutador: ' + dado.nomeRecrutador}</li>
                                                <li id="liInformacoesMeio">{'Quantidade de vagas: ' + dado.qntVagas}</li>
                                                <li>{'Tipo de contrato: ' + dado.tipoContrato}</li>
                                            </ul>
                                        </div>
                                        <p>{dado.descricao}</p>
                                    </div>

                                </Modal.Body>
                                <Modal.Footer id="ModalColor">
                                    <Button id="btn" onClick={handleClose}>Fechar</Button>
                                    <ButtonInscricao id="btn" onClick={() => Inscrito(dado.id)} value={ButtonChange(dado.id)} />
                                </Modal.Footer>
                            </Modal >
                        )
                    })
                }
            </div>
        </div>
    )
}

export default Vagas;