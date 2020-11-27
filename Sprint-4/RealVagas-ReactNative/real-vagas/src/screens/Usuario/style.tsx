import { StyleSheet } from "react-native";

export default StyleSheet.create({
    container: {
        flex: 2,
        paddingTop: 40,
    },
    img: {
        width: 170,
        height: 190,
        resizeMode: 'stretch',
    },
    logo: {
        display: 'flex',
        alignItems: 'center',
    },
    titulo: {
        display: 'flex',
        alignItems: 'center',
        color: "#FE0000",
        fontSize: 20,

    },
    imgLupa: {
        width: 20,
        height: 20,
        marginTop: -0,
        margin: 5,
        marginLeft: 2,
    },
    input: {
        borderBottomWidth: 1,
        borderBottomColor: 'black',
        width: 165,

    },

    pesquisa: {
        display: 'flex',
        paddingBottom: 1,
        flexDirection: 'row',
        height: 30,
        marginVertical: 30,

    },
    pesquisaCentro: {
        display: 'flex',
        alignItems: 'center',


    },
    vagas: {
        borderRadius: 15,
        borderColor: '#EF0000',
        borderWidth: 2,
        width: 300,
        height: 300

    },
    vagasCentro: {
        display: 'flex',
        alignItems: 'center',
    }
});