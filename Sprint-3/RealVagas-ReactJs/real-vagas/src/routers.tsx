import React from 'react';
import {BrowserRouter, Route, Switch} from 'react-router-dom';
import {Button, ModalBody} from 'react-bootstrap';
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

function Routers(){

    return(
    <BrowserRouter>
            <Switch>
                <Route path="/" exact component={Home}/>
                <Route path="/Login" component={Login}/>
                <Route path="/Cadastro" component={Cadastro}/>
                <Route path="/Sobre" component={Sobre}/>
                <Route path="/Dicas" component={Dicas}/>
                <Route path="/Perfil" component={Perfil}/>
                <Route path="/Dashboard" component={DashEmpresa}/>
                <Route path="/Administrador" component={DashAdm}/>
                <Route path="/Dashboard" component={Teste}/>
                <Route path="/Vagas" component={Vagas}/>
                <Route path="/Chat" component={Chat}/>
                <Route path="/Curriculos" component={PagCurriculos}/>
            </Switch>
    </BrowserRouter>
)
}

export default Routers;