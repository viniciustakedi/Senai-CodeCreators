import React from 'react';
import { Text, View } from 'react-native';
import Menu from '../../components/Menu';
import styles from './style';

export default function Login({navigation}: any) {
    return (
        <View style={styles.container}>
            <Menu navigation={navigation} /> 

            <View style={styles.align}>
                <Text style={styles.titles}>Tela de Login</Text>
            </View>
        </View>
    )
}