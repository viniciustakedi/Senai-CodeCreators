import * as React from 'react';
import { Text, View } from 'react-native';
import { createDrawerNavigator, DrawerContent, DrawerContentScrollView, DrawerItem } from '@react-navigation/drawer';
import { Icon } from 'expo';
import { Entypo } from '@expo/vector-icons';
import Empresa from '../../screens/Empresa';
import Home from '../../screens/Home/index';
import Aluno from '../../screens/Usuario/index';
import Login from '../../screens/Login/index';
import CustomSidebarMenu from './CustomSideBar';


const Drawer = createDrawerNavigator();

export default function ScreensMenu() {
    return (
        <Drawer.Navigator
            initialRouteName="Login"

            drawerStyle={{
                backgroundColor: '#F1F1F1',
                paddingVertical: 15,

            }}
            drawerContentOptions={{
                activeTintColor: '#FFFFFFF',
                activeBackgroundColor: '#ef1313',
            }}
            drawerContent={(props) => <CustomSidebarMenu {...props} />}
        >
            <Drawer.Screen
                name="Home"
                component={Home}
                options={
                    {
                        //focused é una prop em boleano para indicar ser o menu é selecionado ou não
                        drawerLabel: (({ focused }) => <Text style={
                            {
                                color: focused ? '#FFF' : '#000000',
                                fontSize: 18,
                            }}>Home</Text>),

                        drawerIcon: (({ focused }) => <Entypo name='home' size={24} color={focused ? '#FFFFFF' : '#000000'} />)
                    }
                }
            />
            <Drawer.Screen
                name="Empresa"
                component={Empresa}
                options={
                    {
                        //focused é una prop em boleano para indicar ser o menu é selecionado ou não
                        drawerLabel: (({ focused }) => <Text style={
                            {
                                color: focused ? '#FFF' : '#000000',
                                fontSize: 18,
                            }}>Empresa</Text>),

                        drawerIcon: (({ focused }) => <Entypo name='clipboard' size={24} color={focused ? '#FFFFFF' : '#000000'} />)
                    }
                }
            />

            <Drawer.Screen
                name="Aluno"
                component={Aluno}
                options={
                    {
                        //focused é una prop em boleano para indicar ser o menu é selecionado ou não
                        drawerLabel: (({ focused }) => <Text style={
                            {
                                color: focused ? '#FFF' : '#000000',
                                fontSize: 18,
                            }}>Aluno</Text>),

                        drawerIcon: (({ focused }) => <Entypo name='user' size={24} color={focused ? '#FFFFFF' : '#000000'} />)

                    }
                }
            />

            <Drawer.Screen
                name="Login"
                component={Login}
                options={
                    {
                        //focused é una prop em boleano para indicar ser o menu é selecionado ou não
                        drawerLabel: (({ focused }) => <Text style={
                            {
                                color: focused ? '#FFF' : '#000000',
                                fontSize: 18,
                            }}>Login</Text>),
                        drawerIcon: (({ focused }) => <Entypo name='login' size={24} color={focused ? '#FFFFFF' : '#000000'} />)

                    }
                }
            />
        </Drawer.Navigator>
    );
}