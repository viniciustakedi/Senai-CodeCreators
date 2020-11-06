import React, { useState } from 'react';
import Header from '../../components/Header';
import Footer from '../../components/Footer';
import Button from "../../components/Button";
import Input from '../../components/Input';
import '../../assets/style/global.css';
import './style.css';
import { useHistory } from 'react-router-dom';


function CadastroEmpresa() {

    const [empresa, setEmpresa] = useState('');
    const [empresas, setEmpresas] = useState('');
    const [responsavel, setResponsavel] = useState('');
    const [RazaoSocial, setRazaoSocial] = useState('')
    const [CNPJ, setCNPJ] = useState('');
    const [email, setEmail] = useState('');
    const [senha, setSenha] = useState('');
    const [telefone, setTelefone] = useState('')
    let history = useHistory();

    const salvar = () => {
        const form = {
            nome: empresa,
            email: email,
            telefone: telefone,
            cnpj: CNPJ,
            razaoSocial: RazaoSocial,
            nomeResponsavel: responsavel,
            senha: senha,
            idTipoUsuario: 2


        };



        const urlRequest = "http://localhost:5000/api/Empresas ";

        console.log(JSON.stringify(form))

        fetch(urlRequest, {
            method: "POST",
            body: JSON.stringify(form),
            headers: {
                'Content-Type': 'application/json;charset=utf-8',
            }
        })

            .then(() => {
                history.push('/Login');
            })
            .catch(err => console.error(err));
    }

    return (
        <div>
            <Header />

            <div className="cadastroEmpresa-centralizado">



                <div className="centralizado-empresa">


                    <div className="formularioEmpresa">

                        <form onSubmit={event => {
                            event.preventDefault();
                            salvar();
                        }}>

                            <div className="tituloEmpresa">
                                <h3>Cadastro de Empresa</h3>
                            </div>

                            <div className="informaçaoEmpresa">
                                <Input id="empresa" type="text" name="nome" label="Nome da empresa:" value={empresa}
                                    onChange={e => setEmpresa(e.target.value)} />
                            </div>


                            <div className="informaçaoEmpresa">
                                <Input id="empresa" type="text" name="CNPJ" label="CNPJ" value={CNPJ}
                                    onChange={e => setCNPJ(e.target.value)} />
                            </div>

                            <div className="informaçaoEmpresa">
                                <Input id="empresa" type="text" name="nomeResponsavel" label="Nome do responsavel:"
                                    onChange={e => setResponsavel(e.target.value)} />
                            </div>




                            <div className="informaçaoEmpresa">
                                <Input id="empresa" type="email" name="Email" label="E-mail:" value={email}
                                    onChange={e => setEmail(e.target.value)} />
                            </div>


                            <div className="informaçaoEmpresa">
                                <Input id="empresa" type="password" name="senha" label="Senha" value={senha}
                                    onChange={e => setSenha(e.target.value)} />
                            </div>


                            <div className="informaçaoEmpresa">
                                <Input id="empresa" type="text" name="Telefone" label="Telefone:" value={telefone}
                                    onChange={e => setTelefone(e.target.value)} />
                            </div>

                            <div className="informaçaoEmpresa">
                                <Input id="empresa" type="text" name="nome" label="Razão social:" value={RazaoSocial}
                                    onChange={e => setRazaoSocial(e.target.value)} />
                            </div>



                            <div className="Button-empresa">
                                <Button id="Button-empresa" name="Cadastrar-se"/>
                            </div>

                        </form>
                    </div>

                </div>

            </div>

            <Footer />

        </div>
    )
}

export default CadastroEmpresa; 