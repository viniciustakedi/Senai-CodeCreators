import React, { useState} from 'react';
import Header from '../../components/Header';
import Footer from '../../components/Footer';
import '../../assets/style/global.css';
import Input from '../../components/Input';
import imgcadastro from '../../assets/image/imgcadastro.png';
import './style.css';
import Button  from "../../components/Button";
import { useHistory } from 'react-router-dom';
import InputPerson from '../../components/InputCurrency/InputMoney';



function Cadastro() {

    const [usuario, setUsuario] = useState('');
    const [DataNascimento, setDataNascimento] = useState('');
    const [cpf, setCpf] = useState('');
    const [sexo, setSexo] = useState('');
    const [matricula, setMatricula] = useState('');
    const [escola, setEscola] = useState('');
    const [email, setEmail] = useState('');
    const [senha, setSenha] = useState('');
    const [telefone, setTelefone] = useState('')
    const [EstadoCivil, setEstadoCivil] = useState('');
    const [nivel, setNivel] = useState('');
    const [TipoCurso, setTipoCurso] = useState('');
    const [curso, setCurso] = useState('');
    const [turma, setTurma] = useState('');
    const [turno, setTurno] = useState('');
    const [termo, setTermo] = useState('');
    const [url, setUrl] = useState('');


    var history = useHistory();

    const salvar = () => {

        const Tbdados ={
            cpf : cpf,
            NumMatricula: matricula,
            senha: senha
        }

        const urlDados = 'http://localhost:5000/api/Dados/';
        var idUsuario = 0;
        const urlRequest ='http://localhost:5000/api/Usuarios/';

        fetch(urlDados , {
            method: "POST",
            body: JSON.stringify(Tbdados),
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(Response => Response.json())
        .then(dados => {
            idUsuario = dados;
        })
        .then(() =>{

            const form = {
                nome: usuario,
                dataNascimento: DataNascimento,
                sexo: sexo,
                escola: escola,
                email: email,
                telefone: telefone,
                estadoCivil: EstadoCivil,
                UrlCurriculo: url,
                nivel: nivel,
                tipoCurso: TipoCurso,
                curso: curso,
                turma: turma,
                turno: turno,
                termo: parseInt(termo),
                idTipoUsuario: 3,
                idDados: idUsuario
            };

            console.log(form);
                fetch(urlRequest , {
                method: "POST",
                body: JSON.stringify(form),
                headers: {
                    'Content-Type': 'application/json',
                }
            }).then(()=>{
                history.push('/Login');
                console.log("Usuário cadastrado");
            })
        })
        .catch(err => console.error(err));
    }

    return (
        
        <div className="imgcadastro">
            <Header />
            
            <div className="cadastro-centralizado">

            
           
            <div className="centralizado">
            
                
            <div className="formulario">          
                
                <form onSubmit={event => {
                    event.preventDefault();
                    salvar();
                }}>

                <div id="titulo">
                  <h3>Cadastro</h3>
                </div>
                
                <div className="informaçao">
                    <Input  type="text" name="nome" label="Nome completo:" 
                    onChange={e => setUsuario(e.target.value)} />
                </div>

                <div className="informaçao">
                    <Input type="date" name="DataNascimento" label="Data de Nascimento:" 
                    onChange={e => setDataNascimento(e.target.value)}/>
                </div>

                
                <div className="genero">
            
                Sexo:
                
                <label className="masculino">
                    
                    <input  type="radio" value="Masculino"  name="genero"
                      onChange={e => setSexo(e.target.value)} />
                          Masculino
                </label>

               
                <label className="feminino" >
                    <input  type="radio" value="Feminino"  name="genero"
                    onChange={e => setSexo(e.target.value)}/>
                      Feminino
                </label>
                           
                </div>

               <div className='sexo'>

               <label>
                <input  type="radio" value="Prefiro não me indentificar"  name="genero"
                    onChange={e => setSexo(e.target.value)}/>
                      Prefiro não me indentificar
                </label>

               </div>
                
                <div className="estadoCivil">
                    <label>
                        Estado civil:
                        <select required
                            onChange={e => setEstadoCivil(e.target.value)}>
                            <option value="" selected disabled hidden>Selecione seu Estado Civil</option>
                            <option  value='solteiro'>Solteiro(a)</option>
                            <option  value='casado'>Casado(a)</option>
                            <option  value='divorciado'>Divorciado(a)</option>
                            <option  value='viuvo'>Viúvo(a)</option>
                            <option  value='separado'>Separado(a)</option>
                            <option  value='outro'>Outro</option>
                        </select>
                    </label>
                </div>

                <div className="informaçao">
                    <Input type="text" name="url" label="Url Currículo:"
                    onChange={e => setUrl(e.target.value)}/>
                </div>

                <div className="informaçao">
                    <InputPerson mask='cpf' type="text" name="CPF" label="CPF:"
                    onChange={e => setCpf(e.target.value)}/>
                </div>

                <div className="informaçao">
                    <Input type="text" name="Telefone" label="Telefone:" 
                    onChange={e => setTelefone(e.target.value)} />
                </div>

                <div className="informaçao">
                    <Input type="text" name="RM" label="RM:" 
                    onChange={e => setMatricula(e.target.value)}/>
                </div>

                <div className="informaçao">
                    <Input type="text" name="Escola" label="Escola:" 
                    onChange={e => setEscola(e.target.value)}/>
                </div>

                <div className="informaçao">
                    <Input type="text" name="Curso" label="Curso:" 
                    onChange={e => setCurso(e.target.value)}/>
                </div>

                <div className="informaçao">
                    <Input type="text" name="Turma" label="Turma:" 
                    onChange={e => setTurma(e.target.value)}/>
                </div>

                <div className="informaçao">
                    <Input type="text" name="Termo" label="Termo:" 
                    onChange={e => setTermo(e.target.value)} />
                </div>


            <div className="periodo">
                <label>
                        Periodo:
                        <select required
                            onChange={e => setTurno(e.target.value)}>
                            <option value="" selected disabled hidden>Selecione seu turno</option>
                            <option  value='Manhã'>Manhã</option>
                            <option  value='Tarde'>Tarde</option>
                            <option  value='Noite'>Noite</option>
                        </select>
                </label>
                </div>


                <div className="informaçao">
                    <Input type="text" name="TipoCurso" label="Tipo de Curso:"
                    onChange={e => setTipoCurso(e.target.value)} />
                </div>

                <div className="informaçao">
                    <Input type="text" name="nivel" label="Nivel:" 
                    onChange={e => setNivel(e.target.value)}/>
                </div>


                <div className="informaçao">
                    <Input type="email" name="Email" label="E-mail:" 
                    onChange={e => setEmail(e.target.value)}/>
                </div>


                <div className="informaçao">
                    <Input type="password" name="senha" label="Senha"
                    onChange={e => setSenha(e.target.value)} />
                </div>

                <div>
                    <Button className="button-Usuario" name="Cadastrar-se" />
                </div>

                </form>
                </div>

             </div>

             </div>
            
            <Footer/>
        </div>
        
    )
}

export default Cadastro;

