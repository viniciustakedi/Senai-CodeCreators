import React from 'react';
import { View, Text } from 'react-native';
import Menu from '../../components/Menu';
import styles from './style';

export default function Empresa({navigation}: any) {
    return(
        <View style={styles.container}>
            <Menu navigation={navigation} /> 

            <View style={styles.align}>
                <Text style={styles.titles}>Tela da empresa</Text>
            </View>
        </View>
    )
}