import React, { useState } from 'react';
import './style.css';
import '../../assets/style/global.css';
import Header from '../../components/Header';
import Footer from '../../components/Footer';
import ImgLupa from '../../assets/image/ImgHome.png';
import { Link } from 'react-router-dom';
import { Button } from 'react-bootstrap';
import InverseLogo from '../../assets/image/Logoinvertida.png';
import InverseLogoSenai from '../../assets/image/senailogobranca.png';
import { Pie } from 'react-chartjs-2';


function TestePronto() {

    const [tubarao, setTubarao] = useState(0);
    const [aguia, setAguia] = useState(0);
    const [gato, setGato] = useState(0);
    const [lobo, setLobo] = useState(0);
    const [show, setShow] = useState(false);


    var respostas = [] as any;
    const Registrar = (num: any, id: any) => {
        respostas[id] = num;
    }

    const resultado = () => {
        var elementos = [1, 2, 3, 4];
        var valores = [0, 0, 0, 0];
        for (let i = 0; i < elementos.length; i++) {
            for (let j = 0; j < respostas.length; j++) {
                if (respostas[j] == elementos[i]) {
                    valores[i] = valores[i] += 1;
                }
            }
        }
        console.log(valores);
        console.log(valores[0]);
        console.log(valores[1]);
        console.log(valores[2]);
        console.log(valores[3]);

        setTubarao((valores[0] * 100) / 25);
        setAguia((valores[1] * 100) / 25);
        setGato((valores[2] * 100) / 25);
        setLobo((valores[3] * 100) / 25);

        generate();
        setShow(true);
    }

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
            'Tubarão',
            'Aguia',
            'Gato',
            'Lobo'
        ],
        colors: [
            '#C5483E',
            '#79CC76',
            '#FFD700',
            '#005086'
        ],
        datasets: [{
            data: [tubarao, aguia, gato, lobo],
            backgroundColor: [
                '#C5483E',
                '#79CC76',
                '#FFD700',
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
                                <div className="quadrado" style={{ backgroundColor: item.color }}></div>
                                <li>{item.name}</li>
                            </div>
                            <p id="quadrado-title">{item.valor}%</p>
                        </li>
                    )
                }
            </ul>
        );
    }
    return (
        <div>
            <Header />
            <div className="questionario">

                <h1>Teste comportamental</h1>
                <form onSubmit={e => {
                    e.preventDefault();
                    resultado();
                }}>
                    <div className="questionario-perguntas">
                        <div className="q-perguntas">
                            <p>1. Eu sou...</p>
                            <div>
                                <input onChange={() => Registrar(2, 0)} type="radio" name="pergunta1" />
                                <label>Idealista, criativo e visionário</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(3, 0)} type="radio" name="pergunta1" />
                                <label>Divertido, espiritual e benéfico</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(4, 0)} type="radio" name="pergunta1" />
                                <label> Confiável, meticuloso e previsível</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(1, 0)} type="radio" name="pergunta1" />
                                <label>Focado, determinado e persistente</label>
                            </div>
                        </div>

                        <div className="q-perguntas">
                            <p>2. Eu gosto de... </p>
                            <div>
                                <input onChange={() => Registrar(1, 1)} type="radio" name="pergunta2" />
                                <label>Ser piloto</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(3, 1)} type="radio" name="pergunta2" />
                                <label >Conversar com os passageiros</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(4, 1)} type="radio" name="pergunta2" />
                                <label >Planejar a viagem </label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(2, 1)} type="radio" name="pergunta2" />
                                <label >Explorar novas rotas</label>
                            </div>
                        </div>

                        <div className="q-perguntas">
                            <p>3. Se você quiser se dar bem comigo...</p>
                            <div>
                                <input onChange={() => Registrar(2, 2)} type="radio" name="pergunta3" />
                                <label >Me dê liberdade</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(4, 2)} type="radio" name="pergunta3" />
                                <label >Me deixe saber sua expectativa</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(1, 2)} type="radio" name="pergunta3" />
                                <label >Lidere, siga ou saia do caminho</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(3, 2)} type="radio" name="pergunta3" />
                                <label > Seja amigável, carinhoso e compreensivo</label>
                            </div>
                        </div>
                        <div className="q-perguntas">
                            <p>4. Para conseguir obter bons resultados é preciso... </p>
                            <div>
                                <input onChange={() => Registrar(2, 3)} type="radio" name="pergunta4" />
                                <label>Ter incertezas</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(4, 3)} type="radio" name="pergunta4" />
                                <label>Controlar o essencial</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(3, 3)} type="radio" name="pergunta4" />
                                <label>Diversão e celebração</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(2, 3)} type="radio" name="pergunta4" />
                                <label>Planejar e obter recursos</label>
                            </div>
                        </div>
                        <div className="q-perguntas">
                            <p>5. Eu me divirto quando...</p>
                            <div>
                                <input onChange={() => Registrar(1, 4)} type="radio" name="pergunta5" />
                                <label >Estou me exercitando</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(4, 4)} type="radio" name="pergunta5" />
                                <label >Tenho novidades</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(3, 4)} type="radio" name="pergunta5" />
                                <label >Estou com os outros</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(2, 4)} type="radio" name="pergunta5" />
                                <label>Determino as regras</label>
                            </div>
                        </div>
                        <div className="q-perguntas">
                            <p>6. Eu penso que...</p>
                            <div>
                                <input onChange={() => Registrar(3, 5)} type="radio" name="pergunta6" />
                                <label>Unidos venceremos, divididos perderemose</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(1, 5)} type="radio" name="pergunta6" />
                                <label>O ataque é melhor que a defesa</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(2, 5)} type="radio" name="pergunta6" />
                                <label>É bom ser manso, mas andar com um porrete</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(4, 5)} type="radio" name="pergunta6" />
                                <label>Um homem prevenido vale por dois</label>
                            </div>
                        </div>
                        <div className="q-perguntas">
                            <p>7. Minha preocupação é...</p>
                            <div>
                                <input onChange={() => Registrar(2, 6)} type="radio" name="pergunta7" />
                                <label >Me dê liberdade</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(3, 6)} type="radio" name="pergunta7" />
                                <label >Me deixe saber sua expectativa</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(4, 6)} type="radio" name="pergunta7" />
                                <label >Lidere, siga ou saia do caminho</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(1, 6)} type="radio" name="pergunta7" />
                                <label > Seja amigável, carinhoso e compreensivo</label>
                            </div>
                        </div>
                        <div className="q-perguntas">
                            <p>8. Eu prefiro...</p>
                            <div>
                                <input onChange={() => Registrar(2, 7)} type="radio" name="pergunta8" />
                                <label >Perguntas a respostas</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(4, 7)} type="radio" name="pergunta8" />
                                <label >Ter todos os detalhes</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(1, 7)} type="radio" name="pergunta8" />
                                <label >Vantagens a meu favor</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(3, 7)} type="radio" name="pergunta8" />
                                <label>Que todos tenham a chance de ser ouvidos</label>
                            </div>
                        </div>
                        <div className="q-perguntas">
                            <p>9. Eu gosto de...</p>
                            <div>
                                <input onChange={() => Registrar(1, 8)} type="radio" name="pergunta9" />
                                <label>Fazer progresso</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(3, 8)} type="radio" name="pergunta9" />
                                <label >Construir memórias</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(4, 8)} type="radio" name="pergunta9" />
                                <label>Fazer sentido</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(2, 8)} type="radio" name="pergunta9" />
                                <label>Tornar as pessoas confortáveis</label>
                            </div>
                        </div>
                        <div className="q-perguntas">
                            <p>10. Eu gosto de chegar...</p>
                            <div>
                                <input onChange={() => Registrar(1, 9)} type="radio" name="pergunta10" />
                                <label >Na frente</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(3, 9)} type="radio" name="pergunta10" />
                                <label>Junto</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(4, 9)} type="radio" name="pergunta10" />
                                <label>Na hora</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(2, 9)} type="radio" name="pergunta10" />
                                <label>Em outro lugar</label>
                            </div>
                        </div>
                        <div className="q-perguntas">
                            <p>11. Um ótimo dia para mim é quando...</p>
                            <div>
                                <input onChange={() => Registrar(2, 10)} type="radio" name="pergunta11" />
                                <label>Consigo fazer muitas coisas</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(3, 10)} type="radio" name="pergunta11" />
                                <label>Me divirto com meus amigos</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(4, 10)} type="radio" name="pergunta11" />
                                <label>Tudo segue conforme planejado</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(2, 10)} type="radio" name="pergunta11" />
                                <label >Desfruto de coisas novas e estimulantes</label>
                            </div>
                        </div>
                        <div className="q-perguntas">
                            <p>12. Eu vejo a morte como...</p>
                            <div>
                                <input onChange={() => Registrar(2, 11)} type="radio" name="pergunta12" />
                                <label >Uma grande aventura misteriosa</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(3, 11)} type="radio" name="pergunta12" />
                                <label >Oportunidade de rever os falecidos</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(4, 11)} type="radio" name="pergunta12" />
                                <label >Um modo de receber recompensas</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(1, 11)} type="radio" name="pergunta12" />
                                <label >Algo que sempre chega muito cedo</label>
                            </div>
                        </div>
                        <div className="q-perguntas">
                            <p>13. Minha filosofia de vida é...</p>
                            <div>
                                <input onChange={() => Registrar(1, 12)} type="radio" name="pergunta13" />
                                <label >Há ganhadores e perdedores, e eu acredito ser um ganhador</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(3, 12)} type="radio" name="pergunta13" />
                                <label >Para eu ganhar, ninguém precisa perder</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(4, 12)} type="radio" name="pergunta13" />
                                <label >- Para ganhar é preciso seguir as regras</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(2, 12)} type="radio" name="pergunta13" />
                                <label>Para ganhar, é necessário inventar novas regras</label>
                            </div>
                        </div>
                        <div className="q-perguntas">
                            <p>14. Eu sempre gostei de...</p>
                            <div>
                                <input onChange={() => Registrar(2, 13)} type="radio" name="pergunta14" />
                                <label >Explorar</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(4, 13)} type="radio" name="pergunta14" />
                                <label >Evitar surpresas</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(3, 13)} type="radio" name="pergunta14" />
                                <label >Focalizar a meta</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(3, 13)} type="radio" name="pergunta14" />
                                <label>Realizar uma abordagem natural</label>
                            </div>
                        </div>
                        <div className="q-perguntas">
                            <p>15. Eu gosto de mudanças se...</p>
                            <div>
                                <input onChange={() => Registrar(1, 14)} type="radio" name="pergunta15" />
                                <label >Me der uma vantagem competitiva</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(3, 14)} type="radio" name="pergunta15" />
                                <label >For divertido e puder ser compartilhado</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(2, 14)} type="radio" name="pergunta15" />
                                <label >Me der mais liberdade e variedade</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(4, 14)} type="radio" name="pergunta15" />
                                <label >Melhorar ou me der mais controle</label>
                            </div>
                        </div>
                        <div className="q-perguntas">
                            <p>16. Não existe nada de errado em...</p>
                            <div>
                                <input onChange={() => Registrar(1, 15)} type="radio" name="pergunta16" />
                                <label >Se colocar na frente </label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(3, 15)} type="radio" name="pergunta16" />
                                <label >Colocar os outros na frente</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(2, 15)} type="radio" name="pergunta16" />
                                <label >Mudar de ideia</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(4, 15)} type="radio" name="pergunta16" />
                                <label >Ser consistente</label>
                            </div>
                        </div>
                        <div className="q-perguntas">
                            <p>17. Eu gosto de buscar conselhos de...</p>
                            <div>
                                <input onChange={() => Registrar(1, 16)} type="radio" name="pergunta17" />
                                <label >Pessoas bem-sucedidas</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(3, 16)} type="radio" name="pergunta17" />
                                <label >Anciões e conselheiros</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(4, 16)} type="radio" name="pergunta17" />
                                <label >Autoridades no assunto</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(2, 16)} type="radio" name="pergunta17" />
                                <label >Lugares, os mais estranhos</label>
                            </div>
                        </div>
                        <div className="q-perguntas">
                            <p>18. Meu lema é...</p>
                            <div>
                                <input onChange={() => Registrar(2, 17)} type="radio" name="pergunta18" />
                                <label >Fazer o que precisa ser feito</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(4, 17)} type="radio" name="pergunta18" />
                                <label >Fazer bem feito</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(3, 17)} type="radio" name="pergunta18" />
                                <label >Fazer junto com o grupo</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(1, 17)} type="radio" name="pergunta18" />
                                <label >Simplesmente fazer</label>
                            </div>
                        </div>
                        <div className="q-perguntas">
                            <p>19. Eu gosto de...</p>
                            <div>
                                <input onChange={() => Registrar(2, 18)} type="radio" name="pergunta19" />
                                <label >Complexidade, mesmo se confuso</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(4, 18)} type="radio" name="pergunta19" />
                                <label >Ordem e sistematização</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(3, 18)} type="radio" name="pergunta19" />
                                <label >Calor humano e animação</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(1, 18)} type="radio" name="pergunta19" />
                                <label >Coisas claras e simples</label>
                            </div>
                        </div>
                        <div className="q-perguntas">
                            <p>20. Tempo para mim é...</p>
                            <div>
                                <input onChange={() => Registrar(1, 19)} type="radio" name="pergunta20" />
                                <label >Algo que detesto desperdiçar</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(3, 19)} type="radio" name="pergunta20" />
                                <label >Um grande ciclo</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(4, 19)} type="radio" name="pergunta20" />
                                <label >Uma flecha que leva ao inevitável </label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(2, 19)} type="radio" name="pergunta20" />
                                <label >Irrelevante</label>
                            </div>
                        </div>
                        <div className="q-perguntas">
                            <p>21. Se eu fosse bilionário...</p>
                            <div>
                                <input onChange={() => Registrar(3, 20)} type="radio" name="pergunta21" />
                                <label >Faria doações para entidades</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(4, 20)} type="radio" name="pergunta21" />
                                <label >Criaria uma poupança avantajada</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(2, 20)} type="radio" name="pergunta21" />
                                <label >Faria o que desse na cabeça</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(1, 20)} type="radio" name="pergunta21" />
                                <label >Exibiria bastante com algumas pessoas </label>
                            </div>
                        </div>
                        <div className="q-perguntas">
                            <p>22. Eu acredito que...</p>
                            <div>
                                <input onChange={() => Registrar(1, 21)} type="radio" name="pergunta22" />
                                <label >O destino é mais importante que a jornada</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(3, 21)} type="radio" name="pergunta22" />
                                <label >A jornada é mais importante que o destino</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(4, 21)} type="radio" name="pergunta22" />
                                <label >Um centavo economizado é um centavo ganho</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(2, 21)} type="radio" name="pergunta22" />
                                <label >Bastam um navio e uma estrela para navegar</label>
                            </div>
                        </div>
                        <div className="q-perguntas">
                            <p>23. Eu acredito também que...</p>
                            <div>
                                <input onChange={() => Registrar(1, 22)} type="radio" name="pergunta23" />
                                <label >Aquele que hesita está perdido</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(4, 22)} type="radio" name="pergunta23" />
                                <label >- De grão em grão a galinha enche o papo</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(3, 22)} type="radio" name="pergunta23" />
                                <label >O que vai, volta</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(2, 22)} type="radio" name="pergunta23" />
                                <label >- Um sorriso ou uma careta é o mesmo para quem é cego</label>
                            </div>
                        </div>
                        <div className="q-perguntas">
                            <p>24. Eu acredito ainda que...</p>
                            <div>
                                <input onChange={() => Registrar(4, 23)} type="radio" name="pergunta24" />
                                <label >É melhor prudência do que arrependimento</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(2, 23)} type="radio" name="pergunta24" />
                                <label >A autoridade deve ser desafiada</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(1, 23)} type="radio" name="pergunta24" />
                                <label >Ganhar é fundamental</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(3, 23)} type="radio" name="pergunta24" />
                                <label >O coletivo é mais importante do que o individual</label>
                            </div>
                        </div>
                        <div className="q-perguntas">
                            <p>25. Eu penso que...</p>
                            <div>
                                <input onChange={() => Registrar(2, 24)} type="radio" name="pergunta25" />
                                <label >Não é fácil ficar encurralado</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(4, 24)} type="radio" name="pergunta25" />
                                <label >É preferível olhar, antes de pular</label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(3, 24)} type="radio" name="pergunta25" />
                                <label >Duas cabeças pensam melhor que do que uma </label>
                            </div>
                            <div>
                                <input onChange={() => Registrar(1, 24)} type="radio" name="pergunta25" />
                                <label >Se você não tem condições de competir, não compita</label>
                            </div>
                        </div>

                    </div>
                    <input style={{ display: !show ? 'block' : 'none' }} type="submit" value="Finalizar teste" />
                </form>

                <div style={{ display: show ? 'block' : 'none' }} className="estatistica">
                    <Pie legend={legends} data={data} />
                    <div className="legends">{generate()}</div>
                </div>

            </div>

            <Footer />
        </div>
    )
}

export default TestePronto;