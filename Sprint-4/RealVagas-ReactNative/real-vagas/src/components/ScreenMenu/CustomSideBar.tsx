import React from 'react';
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

const Drawer = createDrawerNavigator();

const CustomSidebarMenu = (props: any, navigation: any) => {

    const Sair = (navigation: any) => {
        navigation.navigate('Login')
        // RemoveToken()
    }

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
                marginLeft: 10,
                marginRight: 10,
                borderRadius: 3,
                backgroundColor: '#DCDCDC',
            }}>
                <TouchableOpacity
                    style={styles.logout}
                    // onPress={() => Sair(navigation)}
                >
                    <Entypo name='log-out' size={24} color='#000000' />
                    <Text
                        style={{
                            fontSize: 18,
                            marginLeft: 25,
                            color: '#000000',
                        }}
                    >Sair</Text>
                </TouchableOpacity>
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