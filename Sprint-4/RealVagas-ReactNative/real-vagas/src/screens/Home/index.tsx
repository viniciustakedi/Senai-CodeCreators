import React from 'react';
import { Text, TouchableOpacity, View, Image, Button } from 'react-native';
import Menu from '../../components/Menu';
import styles from './style';
import Login from '../Login/index';

export default function Home({navigation}: any) {
    return (
        <View style={styles.container}>
            <Menu navigation={navigation} /> 

            <View style={styles.align}>
                <Text style={styles.titles}>Tela Home</Text>
            </View>
        </View>
    )
}