import React from 'react';
import {
    SafeAreaView,
    View,
    StyleSheet,
    Image,
    Text,
    Linking,
} from 'react-native';

import {
    DrawerContentScrollView,
    DrawerItemList,
    DrawerItem,
} from '@react-navigation/drawer';

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

                <Text
                    style={{
                        fontSize: 14,
                        textAlign: 'center',
                        justifyContent: 'center',
                        color: '#000000',
                    }}>
                    Real Vagas & SENAI
                </Text>

        </SafeAreaView>
    );
};

const styles = StyleSheet.create({
    sideMenuProfileIcon: {
        width: 90,
        height: 90,
        alignSelf: 'center',
    },
});

export default CustomSidebarMenu;