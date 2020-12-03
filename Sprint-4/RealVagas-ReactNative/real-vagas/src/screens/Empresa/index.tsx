import AsyncStorage from '@react-native-community/async-storage';
import React, { useEffect, useState } from 'react';
import { FlatList, SafeAreaView, View, Text, Image } from 'react-native';
import Menu from '../../components/Menu';
import curriculos from './pag-inscricoes';
import styles from './style';

export default function Empresa({ navigation }: any) {
    const [modalVisible, setModalVisible] = useState(false);
    const [vagas, setVagas] = useState([]);
    const [resposta, setReposta] = useState("");

    const [idEmpresa, setIdEmpresa] = useState('');
    const [TokenUsuario, setTokenUsuario] = useState('');

    useEffect(() => {
        Listar();
    }, []);

    const Listar = () => {
        AsyncStorage.getItem("Real-Vagas-Token").then((item1: any) => {
            setTokenUsuario(item1)

            AsyncStorage.getItem("Real-Vagas-Id-Usuario").then((item: any) => {
                setIdEmpresa(item)
                console.log(item)

                const url = "http://localhost:5000/api/Vagas/VagaByIdEmpresa/id?Id=" + item;
                console.log(url);
                fetch(url, {
                    headers: {
                        authorization: 'Bearer ' + item1
                    },
                    method: "GET"
                }).then(Response => Response.json())
                    .then(Respost => {
                        setVagas(Respost);
                        console.log(Respost);
                    })
                    .catch(err => {
                        console.log("Deu erro!!!")
                        console.error(err); //retornar um erro 
                    })
            })
        })




    }

    const Deleta = (Id: any) => {
        setModalVisible(false);
        let resposta = window.prompt("Digite 'excluir vaga' para excluir essa vaga:")?.toLowerCase();


        console.log(resposta);
        if (resposta == "excluir vaga") {
            const form = {
                StatusVaga: false
            }
            const url = "http://localhost:5000/api/Vagas/" + Id;
            fetch(url, {
                headers: {
                    authorization: 'Bearer ' + AsyncStorage.getItem('Real-Vagas-Token'),
                    'Content-Type': 'application/json'
                },
                method: "PUT",
                body: JSON.stringify(form)
            }).then(() => {
                Listar();
            })
                .catch(err => {
                    console.log("Deu erro!!!")
                    console.error(err); //retornar um erro 
                })
        }
    }

    const formatter = new Intl.NumberFormat('pt-br', {
        style: 'currency',
        currency: 'BRL',
        minimumFractionDigits: 2
    })

    return (
        <View style={styles.container1}>
            <Menu navigation={navigation} />
            <View style={styles.containerTotal}>
                <View>
                    <View style={styles.alignContain}>
                        <Image style={styles.logo} source={require('../../assets/images/LogoNovapng.png')} />
                        <Text style={styles.title} >Dashboard empresa</Text>
                    </View>
                    <SafeAreaView style={styles.cont}>
                        <View style={styles.tabela_Title}>
                            <Text style={styles.cont_title}>Vagas cadastradas</Text>
                        </View>
                        <FlatList
                            data={vagas}
                            renderItem={({ item }) => (
                                <View style={styles.container}>
                                    <View style={styles.titles}>
                                        <Text style={styles.ListItens} >{item.cargo}</Text>
                                        <Text style={styles.ListItens}>{formatter.format(item.salario)}</Text>

                                        <View style={styles.itens_flex}>
                                            <Text style={styles.ListItens}>{item.nomeRecrutador},</Text>
                                            <Text style={styles.especial}>{item.localVaga}</Text>
                                        </View>
                                    </View>

                                    <View>
                                        <Text style={styles.btnInscricao} onPress={() => navigation.navigate('Curriculos', { id: item.id, vaga: item.cargo })}>ver inscrições</Text>
                                        <Text style={styles.btnDelete} onPress={() => Deleta(item.id)}>Deleta</Text>
                                    </View>
                                </View>
                            )}
                            keyExtractor={(item: any) => item.id}
                        />
                    </SafeAreaView>
                </View>
                <View style={styles.footerDash}>
                    <Text>Real vagas & Senai</Text>
                </View>
            </View>
        </View>
    )
}
