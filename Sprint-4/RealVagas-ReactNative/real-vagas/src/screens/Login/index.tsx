import React from 'react';
import { Text, View } from 'react-native';
import Menu from '../../components/Menu';
import styles from './style';

export default function Login() {
    return (
        <View style={styles.container}>
            <View style={styles.align}>
                <Text style={styles.titles}>Tela de Login</Text>
            </View>
        </View>
    )
}