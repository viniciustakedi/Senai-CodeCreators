import React, { Component } from 'react';
import {
    SafeAreaView,
    View,
    StyleSheet,
    Image,
    Text,
    Linking,
    TouchableOpacity,
} from 'react-native';

import { Entypo } from '@expo/vector-icons';

import {
    DrawerContentScrollView,
    DrawerItemList,
    DrawerItem,
    createDrawerNavigator,
} from '@react-navigation/drawer';

import AsyncStorage from '@react-native-community/async-storage';

const Drawer = createDrawerNavigator();

const CustomSidebarMenu = (props: any) => {

    return (
        <SafeAreaView style={{ flex: 1 }}>

            {/* Para dar espaçamento */}
            <Text></Text>

            {/*Top Large Image */}
            <Image
                source={require('../../assets/images/Coroa.png')}
                style={styles.sideMenuProfileIcon}
            />

            <DrawerContentScrollView {...props}>
                <DrawerItemList {...props} />
                <DrawerItem
                    label="Repositório CodeCreators"
                    onPress={() => Linking.openURL('https://github.com/viniciustakedi/Senai-CodeCreators')}
                />
            </DrawerContentScrollView>

            <View style={{
                justifyContent: "center",
                alignItems: "center",
            }}>
                <Text
                    style={{
                        fontSize: 16,
                        fontWeight: 'bold',
                    }}
                >Real Vagas & SENAI</Text>
            </View>

        </SafeAreaView>
    );
};


const styles = StyleSheet.create({
    sideMenuProfileIcon: {
        width: 90,
        height: 90,
        alignSelf: 'center',
    },
    logout: {
        flexDirection: 'row',
        alignItems: 'center',
        margin: 10,
        height: 30,
    },
});

export default CustomSidebarMenu;