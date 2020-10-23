import React from 'react';
import { BrowserRouter, Redirect, Route, Router, Switch } from 'react-router-dom';
import Home from './pages/Home';
import Login from './pages/Login';
import Cadastro from './pages/Cadastro';
import Perfil from './pages/Dashboard-Aluno';
import DashEmpresa from './pages/Dashboard-Empresa';
import DashAdm from './pages/Dashboard-Administrador';
import Sobre from './pages/Sobre';
import Vagas from './pages/Vagas';
import Teste from './pages/Teste-Comportamental';
import Dicas from './pages/Teste-Comportamental/indexDicas';
import Chat from './pages/Chat';
import PagCurriculos from './pages/Dashboard-Empresa/Página-do-currícúlo';
import { parseJWT } from './services/auth';
import Documentos from './pages/Dashboard-Empresa/Documentos-pendente';

function Routers() {

    interface RouteProps {
        component: any;
        path: any;
    }

    const RotaComum: React.FC<RouteProps> = ({ component: Component, path, ...rest }) => {
        var token = localStorage.getItem("Real-Vagas-Token");
        return (
            <Route
                render={props => (token === undefined || token === null) ?
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
                render={props => ((token !== undefined || token !== null) && parseJWT() === 1) ?
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
                render={props => ((token !== undefined || token !== null) && parseJWT() === 2) ?
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
                render={props => ((token !== undefined || token !== null) && (parseJWT() === 3 || parseJWT() === 4)) ?
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

                <Route path="/Sobre" component={Sobre} />
                <Route path="/Dicas" component={Dicas} />
                <Route path="/Teste" component={Teste} />

                <RotaAdm path="/Administrador" component={DashAdm} />
                <Route path="/Dashboard" component={DashEmpresa} />
                <Route path="/Perfil" component={Perfil} />

                <RotaPrivada path="/Vagas" component={Vagas} />
                <RotaAdm path="/Chat" component={Chat} />
                <RotaEmpresa path="/Curriculos" component={PagCurriculos} />
                <RotaEmpresa path="/Documentos" component={Documentos} />
            </Switch>
        </BrowserRouter>
    )
}

export default Routers;