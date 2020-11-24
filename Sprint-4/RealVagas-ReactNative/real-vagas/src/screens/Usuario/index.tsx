import React from 'react';
import { Text, View, StyleSheet } from 'react-native';
import Menu from '../../components/Menu';
import styles from './style';

export default function Usuario({navigation}: any) {
    return(
        <View style={styles.container}>
        <Menu navigation={navigation} /> 

        <View style={styles.align}>
            <Text style={styles.titles}>Tela do usuário</Text>
        </View>
    </View>
    )
}