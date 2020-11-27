import React from 'react';
import { Text, View, Image } from 'react-native';
import Menu from '../../components/Menu';
import styles from './style';

export default function Home({ navigation }: any) {
    return (
        <View style={styles.container}>
            <Menu navigation={navigation} />

            <View style={styles.align}>
                <Image
                    style={styles.logo}
                    source={require('../../assets/images/LogoNovapng.png')}
                />

                <View style={styles.conteudo}>
                    <Text style={styles.infos}>Real Vagas & SENAI</Text>
                    <Text style={styles.infos3}>Bem vindo(a) ao nosso aplicativo mobile.</Text>

                    <View style={styles.footer}>
                        <Text style={styles.infos2}>Real Vagas & SENAI todos os direitos reservados®</Text>
                    </View>
                </View>
            </View>
        </View>
    );
}
