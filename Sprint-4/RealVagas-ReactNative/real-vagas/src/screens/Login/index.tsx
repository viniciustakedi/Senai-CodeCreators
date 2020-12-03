import AsyncStorage from '@react-native-community/async-storage';
import React, { useState } from 'react';
import { TextInput, View, StyleSheet, Text, Image, Button, Alert, TouchableOpacity, TouchableWithoutFeedback, } from 'react-native';
import Menu from '../../components/Menu';
import styles from './style'

export default function Login(props: any) {

    const [email, setEmail] = useState("");
    const [senha, setSenha] = useState("");

    const login = () => {

        const login = {
            //váriavel login para armazenar um array {}
            email: email,
            senha: senha, //Acessando e alterando (modelo) os dados como se fosse no postman
        };

        fetch("http://localhost:5000/api/Login", {
            //Fetch passando a url da API
            method: "POST", //Como é um login o método é o Post
            body: JSON.stringify(login), //Seleciona o tipo do corpo, no caso é json (Postman: Raw/Json)
            headers: {
                "content-type": "application/json", //Tipo do conteudo é uma aplicação Json
            },
        })
            .then((response) => response.json())
            .then((dados) => {
                if (dados.token != undefined) {
                    console.log(dados.token);
                    AsyncStorage.setItem('Real-Vagas-Token', dados.token)

                } else alert("Email ou senha inválidos"); //Alerta caso o email ou senha estejam errados
            })

            .catch((error) => console.error(error)); // Como usando o fetch colocamos um catch caso algo de errado.
    };

    return (
        <View style={{
            paddingTop: 40,
        }}>
            <View style={{
                flex: 2,
                backgroundColor: '#F3F3F3',
                justifyContent: 'center',
                flexDirection: 'column',
                alignItems: 'center',
                height: '100%',
            }}
            >
                <Image source={require('../../assets/images/LogoNovapng.png')}
                    style={styles.logo}
                />

                <Text style={styles.logTexto}>
                    Login
            </Text>

                <Text style={styles.email}>
                    Email
            </Text>
                <form
                    onSubmit={(event) => {
                        event.preventDefault();
                        login();
                    }}
                >
                    <TextInput
                        style={styles.input}
                        onChangeText={(Value) => setEmail(Value)}
                    />
                    <View style={styles.containerSenha}>
                        <Text style={styles.senha}>
                            Senha
                    </Text>
                    </View>

                    <TextInput
                        style={styles.input}
                        onChangeText={(Value) => setSenha(Value)}
                    />
                    <View style={styles.containerBotao}>
                        <TouchableOpacity
                            onPress={login}
                            style={{
                                flex: 1,
                                justifyContent: 'center',
                                alignItems: 'center',
                                marginTop: 18,
                                width: 110,
                                backgroundColor: '#FE0000',
                                borderRadius: 34,
                            }}
                        >
                            <Text 
                            style={{
                                color: 'white',
                                alignSelf: "center",
                                height: 25,
                            }}>
                                Entrar</Text>
                        </TouchableOpacity>
                    </View>
                </form>
            </View>
        </View>

    )
}