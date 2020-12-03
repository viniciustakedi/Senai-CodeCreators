import React, { useEffect, useState } from 'react';
import { View, Image, Text, TextInput, FlatList, SafeAreaView } from 'react-native';
import AsyncStorage from '@react-native-community/async-storage';
import styles from './style';
import Menu from '../../components/Menu';
import { Entypo } from '@expo/vector-icons';

export default function Usuario({ navigation }: any) {

    const [data, setData] = useState([]);
    const [inscricaos, setInscricao] = useState([]);
    const [vaga, setVaga] = useState([]); //para buscar a vaga que está cadastrado
    const [vagaEscrita, setVagaEscrita] = useState('');  //  buscar uma vaga que ja esta o usuário está escrito
    const [idUsuario, setIdUsuario] = useState('');
    const [TokenUsuario, setTokenUsuario] = useState('');
    const [text, setText] = useState('')//Controla value do input

    useEffect(() => {
        InscricoesUsuario();

    }, [])



    const buscar = () => {
        if (text.length != 0) {
            var filtro = inscricaos.filter((vaga: any) => vaga.idVagaNavigation.cargo.toUpperCase().includes(text.toUpperCase()))
            return filtro

        }
        else {
            return inscricaos
        }

    }


    //Listar as inscrições do usuário
    const InscricoesUsuario = () => {
        AsyncStorage.getItem("Real-Vagas-Token").then((item: any) => {
            setTokenUsuario(item)

            AsyncStorage.getItem("Real-Vagas-Id-Usuario").then((item1: any) => {
                setIdUsuario(item1)
                console.log(item1)

                fetch("http://localhost:5000/api/Inscricao/ListarById/id?id=" + item1, {  // idUsuario
                    method: 'GET',
                    headers: {
                        authorization: 'Bearer ' + item,
                        'content-type': 'application/json',
                    }
                })
                    .then(response => response.json())
                    .then(dados => {
                        if(dados != 'Nenhuma incrição encontrada'){
                            setInscricao(dados)
                        } else {
                            setInscricao([])
                        }

                        // console.log (idUsuario)
                    })

                    .catch(Erro => console.error(Erro));
            })
        })
    }


    const formatter = new Intl.NumberFormat('pt-br', {
        style: 'currency',
        currency: 'BRL',
        minimumFractionDigits: 2
    })


    return (
        <View style={styles.container}>
            <Menu navigation={navigation} />

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
                        onChange={e => {
                            setText(e.target.value)
                            buscar()
                        }} />
                </View>
                {/* </form> */}
            </View>
            <View style={styles.container3}>

                <SafeAreaView >
                    <FlatList
                        data={buscar()}


                        // passa uma lista com os dados(referencia da lista)
                        renderItem={({ item }) => (
                            // função que retorna o componente para renderizar na lista 
                            <View style={styles.containerVagas}>
                                <View style={styles.Container}>
                                    <View style={styles.Vaga}>

                                        <Text style={styles.titulos}>Nome da empresa: {item.idVagaNavigation.idEmpresaNavigation.nome}</Text>
                                        <Text style={styles.titulos}>Cargo: {item.idVagaNavigation.cargo}</Text>
                                        <Text style={styles.titulos}>Local da vaga: {item.idVagaNavigation.localVaga}</Text>
                                        <Text style={styles.titulos}>Nome do recrutador: {item.idVagaNavigation.nomeRecrutador}</Text>
                                        <Text style={styles.titulos}>Salário:{(item.idVagaNavigation.salario != 0) ? formatter.format(item.idVagaNavigation.salario) : "A combinar"}</Text>
                                        <Text style={styles.titulos}>Tipo de contrato: {item.idVagaNavigation.tipoContrato}</Text>
                                    </View>
                                </View>
                            </View>
                        )}
                        keyExtractor={(item: any) => item.id}
                    //função que retorna uma chave para ser usada na indexação
                    // dos itens da lista
                    />
                </SafeAreaView>
            </View>
        </View>
    )
}