import { StyleSheet } from "react-native";

export default StyleSheet.create({
    container: {
        flex: 1,
        justifyContent: 'center',
        alignItems: 'center',
        backgroundColor: '#DBD7D7',
    },

    input: {
        borderBottomWidth: 2,
        borderBottomColor: '#FE0000',
        width: 300,
        
    },

    logo: {
        width: 150,
        height: 150,
    },

    email: {
        
        fontSize: 14,
    },
    
    senha: {
        fontSize: 14,
        paddingTop: 10,

    },
    logTexto: {
        fontSize: 36,
        paddingBottom: 30,
        fontWeight: 'bold',
    },
    linha: {
        flex: 1,
        height: 1,
        backgroundColor: 'black',
    },
    botao: {
        width: 300,
        height: 40,
        backgroundcolor: 'black',
        marginTop: 10,
        borderRadius: 4,
        alignItems: 'center',
        justifyContent: 'center',
    },
});