import React, { useEffect, useState } from 'react';
import { FlatList, SafeAreaView, View, Text, Button } from 'react-native';
import styles from './style';

export default function curriculos({ route }: any) {

    const [inscricoes, setInscricoes] = useState([]);

    useEffect(() => {
        ListarInscricoes(route.params.id);
    }, [])

    const ListarInscricoes = (id: any) => {
        const url = "http://10.0.2.2:5000/api/Inscricao/ListarByIdVaga/id?Id=" + id;
        fetch(url, {
            method: "GET"
        }).then(Response => Response.json())
            .then(Respost => {
                setInscricoes(Respost);
                console.log(Respost)
            })
            .catch(err => {
                console.error(err); //retornar um erro 
            })
    }
    return (
        <View style={styles.curriculos}>
            <View>
                <View style={styles.titleInscricoes}>
                    <Text style={styles.title}>Inscrições de {route.params.vaga}</Text>
                </View>
                <SafeAreaView style={styles.cont}>
                    <View style={styles.tabela_Title}>
                        <Text style={styles.cont_title}>Currículos recebidos</Text>
                    </View>
                    <FlatList
                        data={inscricoes}
                        renderItem={({ item }) => (
                            <View style={styles.container}>
                                <View style={styles.contInscricoes}>
                                    <Text style={styles.contItens}>{item.idUsuarioNavigation.nome}</Text>
                                    <Text style={styles.contItens}>{item.idUsuarioNavigation.curso}</Text>

                                    <View style={styles.itens_flex}>
                                        <Text style={styles.contItens}>{item.idUsuarioNavigation.turno}</Text>
                                        <Text style={styles.contItens}></Text>
                                    </View>
                                </View>

                                <View>
                                    <Text style={styles.btnInscricao} onPress={() => { }}>ver currículo</Text>
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
    )
}
