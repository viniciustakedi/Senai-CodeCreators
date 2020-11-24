import React from 'react';
import { TouchableOpacity, View } from 'react-native';
import { Entypo } from '@expo/vector-icons';
import styles from './style';


export default function Menu({navigation}: any){
    return (
        <View style={styles.menu}>
            <TouchableOpacity onPress={() => navigation.openDrawer()}>
                <Entypo name="menu" size={46} color='black' /> 
            </TouchableOpacity>
        </View>
    );
}
