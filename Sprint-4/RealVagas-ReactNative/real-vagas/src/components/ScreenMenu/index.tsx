import * as React from 'react';
import { Text } from 'react-native';
import { createDrawerNavigator } from '@react-navigation/drawer';
import { Entypo } from '@expo/vector-icons';
import Empresa from '../../screens/Empresa';
import Home from '../../screens/Home/index';
import Aluno from '../../screens/Usuario/index';
import Login from '../../screens/Login/index';
import Inscricoes from '../../screens/Empresa/pag-inscricoes';
import CustomSidebarMenu from './CustomSideBar';
import { parseJWT } from '../../../services/auth';
import { NavigationContainer } from '@react-navigation/native';
import AsyncStorage from '@react-native-community/async-storage';

import { createStackNavigator } from '@react-navigation/stack';
import curriculos from '../../screens/Empresa/pag-inscricoes';


const Drawer = createDrawerNavigator();
const Stack = createStackNavigator();

export default function ScreensMenu(props: any) {

    const Sair = () => {
        AsyncStorage.removeItem('Real-Vagas-Token')
        AsyncStorage.removeItem("Real-Vagas-Id-Usuario")
        props.navigation.navigate('Logout', {
            screen: 'Home',
        })
    }

    const Menu = () => {
        var parseJWTResponse = parseJWT()

        if (parseJWTResponse == undefined || parseJWTResponse == null) {
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
                </Drawer.Navigator>
            )
        }
        else if (parseJWTResponse == 2) {
            return (
                <Drawer.Navigator
                    initialRouteName="Home"
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
                                    }}>Minhas Vagas</Text>),

                                drawerIcon: (({ focused }) => <Entypo name='clipboard' size={24} color={focused ? '#FFFFFF' : '#000000'} />)
                            }
                        }
                    />
                    {/* <Drawer.Screen
                        name="Inscricoes"
                        component={Inscricoes}
                        options={
                            {
                                //focused é una prop em boleano para indicar ser o menu é selecionado ou não
                                drawerLabel: (({ focused }) => <Text style={
                                    {
                                        color: focused ? '#FFF' : '#000000',
                                        fontSize: 18,
                                    }}>Inscritos as vagas</Text>),

                                drawerIcon: (({ focused }) => <Entypo name='users' size={24} color={focused ? '#FFFFFF' : '#000000'} />)
                            }
                        }
                    /> */}
                    <Drawer.Screen
                        name="Logout"
                        component={Login}
                        options={
                            {
                                //focused é una prop em boleano para indicar ser o menu é selecionado ou não
                                drawerLabel: (({ focused }) => <Text
                                    onPress={() => Sair()}
                                    style={
                                        {
                                            color: focused ? '#FFF' : '#000000',
                                            fontSize: 18,
                                        }}>Sair</Text>),

                                drawerIcon: (({ focused }) => <Entypo onPress={Sair} name='log-out' size={23} color={focused ? '#FFFFFF' : '#000000'} />)
                            }
                        }
                    />
                </Drawer.Navigator>
            )
        }
        else if (parseJWTResponse == 3 || parseJWTResponse == 4) {
            return (
                <Drawer.Navigator
                    initialRouteName="Home"

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
                        name="Aluno"
                        component={Aluno}
                        options={
                            {
                                //focused é una prop em boleano para indicar ser o menu é selecionado ou não
                                drawerLabel: (({ focused }) => <Text style={
                                    {
                                        color: focused ? '#FFF' : '#000000',
                                        fontSize: 18,
                                    }}>Minhas Inscrições</Text>),

                                drawerIcon: (({ focused }) => <Entypo name='list' size={25} color={focused ? '#FFFFFF' : '#000000'} />)

                            }
                        }
                    />
                    <Drawer.Screen
                        name="Logout"
                        component={Login}
                        options={
                            {
                                //focused é una prop em boleano para indicar ser o menu é selecionado ou não
                                drawerLabel: (({ focused }) => <Text
                                    onPress={() => Sair()}
                                    style={
                                        {
                                            color: focused ? '#FFF' : '#000000',
                                            fontSize: 18,
                                        }}>Sair</Text>),
                                drawerIcon: (({ focused }) => <Entypo onPress={Sair} name='log-out' size={24} color={focused ? '#FFFFFF' : '#000000'} />),
                            }
                        }
                    />
                </Drawer.Navigator>


            )
        }
    }


    return (
        <NavigationContainer>
            {Menu()}
        </NavigationContainer>
    );
}