import { StyleSheet } from "react-native";

export default StyleSheet.create({
    container: {
        flex: 2,
        paddingTop: 40,
        
        
    },
    containerVagas:{
        flex: 1,
        backgroundColor: "#fafafa",
        
        
    },

    Container:{
        padding: 20
    },
    Vaga:{
        backgroundColor: "#fff",
        borderWidth: 1,
        borderColor: "#ddd",
        borderRadius: 5,
        padding: 10,
        marginBottom: 10
    },
    container3:{
        display: 'flex',
        alignItems: 'center',
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
    titulos:{
        color: 'black',
        fontSize: 17,
        margin: 3,
        marginLeft: 14,
       
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
    inscrições: {
        borderBottomWidth: 2,
        borderBottomColor:"#FE0000",
        marginBottom: 2,
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