import { StyleSheet } from "react-native";

export default StyleSheet.create({
    container: {
        flex: 2,
        paddingTop: 40,
    },
    align: {
        flex: 1,
        backgroundColor: '#F3F3F3',
        alignItems: 'center',
        justifyContent: 'center',
    },
    logo: {
        width: 170,
        height: 190,
        marginTop: 180,
        resizeMode: 'stretch',
    },
    conteudo: {
        width: '100%',
        height: '100%',
        backgroundColor: '#D8002D',
    },
    infos: {
        justifyContent: 'center',
        alignItems: 'center',
        textAlign: 'center',
        color: '#fff',
        fontSize: 30,
        marginTop: 30
    },
    infos3: {
        justifyContent: 'center',
        alignItems: 'center',
        textAlign: 'center',
        color: '#fff',
        fontSize: 19,
        marginTop: 2,
        marginLeft: 2,
        marginRight: 2,
    },
    infos2: {
        justifyContent: 'center',
        alignItems: 'center',
        textAlign: 'center',
        color: '#fff',
        fontSize: 13,
    },
    footer: {
        margin: 10,
    },
});