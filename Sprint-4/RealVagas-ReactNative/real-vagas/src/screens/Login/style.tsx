import { StyleSheet } from "react-native";

export default StyleSheet.create({
    container: {
        flex: 1,
        justifyContent: 'center',
        flexDirection: 'column',
        alignItems: 'center',

    },

    containerBotao: {
        flex: 1,
        justifyContent: 'center',
        alignItems: 'center',
    },

    containerSenha: {
        flex: 1,
        justifyContent: 'flex-start',
        alignItems: 'center',
    },

    input: {
        borderBottomWidth: 2,
        borderBottomColor: '#FE0000',
        width: 270,
        marginTop: 10,
        borderWidth: 0,
    },

    logo: {
        width: 150,
        height: 150,
    },

    email: {
        fontWeight: '400',
        fontSize: 14,
    },

    senha: {
        fontWeight: '400',
        fontSize: 14,
        marginTop: 15,
    },
    logTexto: {
        fontSize: 36,
        paddingBottom: 30,
        fontWeight: 'bold',
    },

    touch: {
        flex: 1,
        justifyContent: 'center',
        marginTop: 100,
        width: 40,
        height: 40,
        backgroundColor: 'Red',
        borderRadius: 4,
        alignItems: 'center',

    },
    tudo: {
        flex: 1,
        height: '100%',
    },
});