import React from 'react';
import { BrowserRouter, Redirect, Route, Router, Switch } from 'react-router-dom';
import Home from './pages/Home';
import Login from './pages/Login';
import Cadastro from './pages/CadastroUsuario';
import CadastroEmpresa from './pages/CadastroEmpresa';
import Perfil from './pages/Dashboard-Aluno';
import DashEmpresa from './pages/Dashboard-Empresa';
import DashAdm from './pages/Dashboard-Administrador';
import Sobre from './pages/Sobre';
import Vagas from './pages/Vagas';
import TesteComp from './pages/Teste-Comportamental';
import Dicas from './pages/Dicas';
import Chat from './pages/Chat';
import PagCurriculos from './pages/Dashboard-Empresa/Página-do-currícúlo';
import { parseJWT } from './services/auth';
import Oportunidade from './pages/CadastrarVagas';
import TestePronto from './pages/TestePronto';

function Routers() {

    interface RouteProps {
        component: any;
        path: any;
    }

    const RotaComum: React.FC<RouteProps> = ({ component: Component, path, ...rest }) => {
        var token = localStorage.getItem("Real-Vagas-Token");
        return (
            <Route
                render={props => (token == undefined || token == null) ?
                    (
                        <Component path={path}  {...rest} {...props} />
                    ) : (
                        <Redirect to={{ pathname: '/', state: { from: props.location } }} />
                    )
                } />
        )
    }

    const RotaAdm: React.FC<RouteProps> = ({ component: Component, path, ...rest }) => {
        var token = localStorage.getItem("Real-Vagas-Token");
        return (
            <Route
                render={props => ((token !== undefined || token !== null) && parseJWT() == 1) ?
                    (
                        <Component path={path}  {...rest} {...props} />
                    ) : (
                        <Redirect to={{ pathname: '/', state: { from: props.location } }} />
                    )
                } />
        )
    }

    const RotaEmpresa: React.FC<RouteProps> = ({ component: Component, path, ...rest }) => {
        var token = localStorage.getItem("Real-Vagas-Token");
        return (
            <Route
                render={props => ((token !== undefined || token !== null) && parseJWT() == 2) ?
                    (
                        <Component path={path}  {...rest} {...props} />
                    ) : (
                        <Redirect to={{ pathname: '/', state: { from: props.location } }} />
                    )
                } />
        )
    }

    const RotaAluno: React.FC<RouteProps> = ({ component: Component, path, ...rest }) => {
        var token = localStorage.getItem("Real-Vagas-Token");
        return (
            <Route
                render={props => ((token !== undefined || token !== null) && (parseJWT() == 3 || parseJWT() == 4)) ?
                    (
                        <Component path={path}  {...rest} {...props} />
                    ) : (
                        <Redirect to={{ pathname: '/', state: { from: props.location } }} />
                    )
                } />
        )
    }

    const RotaPrivada: React.FC<RouteProps> = ({ component: Component, path, ...rest }) => {
        var token = localStorage.getItem("Real-Vagas-Token");
        return (
            <Route
                render={props => ((token !== undefined || token !== null)) ?
                    (
                        <Component path={path}  {...rest} {...props} />
                    ) : (
                        <Redirect to={{ pathname: '/', state: { from: props.location } }} />
                    )
                } />
        )
    }

    return (
        <BrowserRouter>
            <Switch>
                <Route path="/" exact component={Home} />
                <RotaComum path="/Login" component={Login} />
                <RotaComum path="/Cadastro" component={Cadastro} />
                <RotaComum path="/CadastroEmpresa" component={CadastroEmpresa}/>

                <Route path="/Sobre" component={Sobre} />
                <Route path="/Dicas" component={Dicas} />
                <Route path="/Teste" component={TesteComp} />
                <Route path="/TesteComportamental" component={TestePronto} />

                <Route path='/Personalidade' component={() => { 
                window.location.href = 'https://www.personalidades.mobi/Perfil_Comportamental/'; 
                return null;
                }}/>


                {/* Rota Adm */}
                <RotaAdm path="/Administrador" component={DashAdm} /> 
                <RotaEmpresa path="/CadastroVaga" component={Oportunidade}/>
                <RotaEmpresa path="/Dashboard" component={DashEmpresa} />
                <RotaAluno path="/Perfil" component={Perfil} />

                <RotaPrivada path="/Vagas" component={Vagas} />
                <RotaAdm path="/Chat" component={Chat} />
                <RotaEmpresa path="/Curriculos" component={PagCurriculos} />
            </Switch>
        </BrowserRouter>
    )
}

export default Routers;