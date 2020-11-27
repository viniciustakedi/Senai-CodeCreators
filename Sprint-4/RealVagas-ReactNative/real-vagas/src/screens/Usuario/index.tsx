import React, { useEffect, useState } from 'react';
import { View, Image, Text, TextInput } from 'react-native';
import AsyncStorage from '@react-native-community/async-storage';
import styles from './style';
import Menu from '../../components/Menu';
import { Entypo } from '@expo/vector-icons';

export default function Usuario({navigation}: any) {
    const [idInscricao, setIdInscricao] = useState(0);
    const [statusInscricao, setStatusInscricao] = useState([]);
    const [data, setData] = useState([]);
    const [inscricao, setInscricao] = useState([]);
    const [vaga, setVaga] = useState([]); //para buscar a vaga que está cadastrado
    const [vagaEscrita, setVagaEscrita] = useState('');  //  buscar uma vaga que ja esta o usuário está escrito

    useEffect(() => {
        InscricoesUsuario();

    }, [])



    var idUsuarioInsc = AsyncStorage.getItem("Real-Vagas-Id-Usuario") as any;

    //Listar as inscrições do usuário
    const InscricoesUsuario = () => {
        fetch("http://localhost:5000/api/Inscricao/ListarById/id?id=" + idUsuarioInsc, {
            method: 'GET',
            headers: {
                authorization: 'Bearer ' + AsyncStorage.getItem('Real-Vagas-Token'),
                'content-type': 'application/json',
            }
        })
            .then(response => response.json())
            .then(dados => {
                setInscricao(dados)
            })

            .catch(Erro => console.error(Erro));
    }

    function buscarVaga(vagasCadastradas: string) {
        if (vaga.length != 0) {
            var filtrados = vaga.filter((vagas: any) => vagas.vagasCadastradas.toUpperCase().includes(vagasCadastradas.toUpperCase()));
            console.log(filtrados)

            if (filtrados != undefined)
                return filtrados;
        }
        return vaga;
    }


    return (
        <View style={styles.container}>
            <Menu navigation={navigation}/>

            <View style={styles.logo}>
                < Image
                    style={styles.img}
                    source={
                        require('../../assets/images/LogoNovapng.png')
                    } />
            </View>


            <View style={styles.titulo}>
                <Text style={styles.titulo}>Vagas que estou cadastrado(a) </Text>
            </View>


            <View style={styles.pesquisaCentro}>
                {/* <form onSubmit={event => {
                    event.preventDefault();
                    buscarVaga(vagaEscrita);
                }}> */}
                    <View style={styles.pesquisa}>
                    <Entypo name="magnifying-glass" size={32} color="black" />


                        <TextInput
                            style={styles.input}
                            placeholder="Listar vaga"
                            onChangeText={(value) => setVagaEscrita(value)} />
                    </View>
                {/* </form> */}
            </View>
            {

                buscarVaga(vagaEscrita).map((item: any) => {

                    return (

                        <View style={styles.vagasCentro}>

                            <View style={styles.vagas}>

                                <Text>Vagas</Text>

                                <View>
                                    <img src={atob(item.foto)} alt="imagem da vaga" />
                                </View>

                                <View //style={styles.informacao}

                                >

                                    <Text
                                    //style={styles.CargoDaVaga}
                                    >{item.cargo}</Text>

                                    <Text
                                    //style={styles.LocalDaVaga}
                                    >{item.localVaga}</Text>
                                </View>
                            </View>
                        </View>
                    )
                })
            }
        </View>
    )
}