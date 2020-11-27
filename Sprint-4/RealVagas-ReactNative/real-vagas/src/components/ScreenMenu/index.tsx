import * as React from 'react';
import { Text, View } from 'react-native';
import { createDrawerNavigator } from '@react-navigation/drawer';
import { Entypo } from '@expo/vector-icons';
import Empresa from '../../screens/Empresa';
import Home from '../../screens/Home/index';
import Aluno from '../../screens/Usuario/index';
import Login from '../../screens/Login/index';
import CustomSidebarMenu from './CustomSideBar';
import { parseJWT, SetToken } from '../../../services/auth';
import { NavigationContainer } from '@react-navigation/native';

const Drawer = createDrawerNavigator();

export default function ScreensMenu() {

    const token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImRhdmlAZ21haWwuY29tIiwianRpIjoiOSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IjMiLCJleHAiOjE2MDY0MTQ5MjcsImlzcyI6IlJlYWxWYWdhcy5XZWJBcGkuQyMiLCJhdWQiOiJSZWFsVmFnYXMuV2ViQXBpLkMjIn0.J-h-EHJ0a1hRy4-rGzc3h8-d7EkZteh5YNgMP9jSaxA";
    SetToken(token);

    const Menu = () => {
        if (parseJWT() == undefined || parseJWT() == null) {
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
                </Drawer.Navigator>
            )
        }
        else if (parseJWT() == 2) {
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
                                    }}>Empresa</Text>),

                                drawerIcon: (({ focused }) => <Entypo name='clipboard' size={24} color={focused ? '#FFFFFF' : '#000000'} />)
                            }
                        }
                    />
                </Drawer.Navigator>
            )
        }
        else if (parseJWT() == 3 || parseJWT() == 4) {
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
                                    }}>Aluno</Text>),

                                drawerIcon: (({ focused }) => <Entypo name='user' size={24} color={focused ? '#FFFFFF' : '#000000'} />)

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