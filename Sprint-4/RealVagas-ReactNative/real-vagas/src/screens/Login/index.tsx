
import AsyncStorage from '@react-native-community/async-storage';
import React, { useState } from 'react';

import { TextInput, View, StyleSheet, Text, Image, Button, Alert, TouchableOpacity, } from 'react-native';
import styles from './style';


export default function Login() {

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
                    var Dados = dados.token + ""

                        AsyncStorage.setItem('Real-Vagas-Token', Dados)
                        console.log(AsyncStorage.getItem('Real-Vagas-Token'));

                    console.log(dados);

                } else alert("Email ou senha inválidos"); //Alerta caso o email ou senha estejam errados
            })

            .catch((error) => console.error(error)); // Como usando o fetch colocamos um catch caso algo de errado.
    };


    return (
        <View>
            <View style={styles.container}>
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

                    <Text style={styles.senha}>
                        Senha
                </Text>

                    <TextInput
                        style={styles.input}
                        onChangeText={(Value) => setSenha(Value)}


                    />

                    <input type='submit'
                        title='Entrar'
                        value="Entrar"

                    />
                </form>
            </View>
        </View>
    )
}
