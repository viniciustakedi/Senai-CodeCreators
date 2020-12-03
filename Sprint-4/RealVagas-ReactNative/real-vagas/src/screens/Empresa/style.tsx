import { StyleSheet } from "react-native";

export default StyleSheet.create({
    container1: {
        flex: 2,
        paddingTop: 40,
    },
    containerTotal: {
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
        justifyContent: 'space-between',
        alignSelf: 'stretch',
    },
    alignContain: {
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
        justifyContent: 'center'
    },
    logo: {
        width: 100,
        height: 100
    },
    title: {
        fontSize: 18,
        color: '#EF0000'
    },
    container: {
        display: 'flex',
        flexDirection: 'row',
        justifyContent: 'space-between',
        alignItems: 'center',
        marginBottom: 3,
        backgroundColor: '#FFFFFF',
        paddingLeft: 10,
        paddingRight: 10,
        paddingTop: 2,
        paddingBottom: 3,
    },
    cont: {
        marginTop: 30,
        marginBottom: '60%',
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
        justifyContent: 'center',
        padding: 20,
        shadowOpacity: 1,
        elevation: 8,
    },
    cont_title: {
        fontSize: 15,
        color: '#ffffff'
    },
    btnInscricao: {
        color: '#FFFFFF',
        padding: 3,
        fontSize: 11,
        borderRadius: 3,
        backgroundColor: '#EF0000'
    },
    btnDelete: {
        color: '#8a2be2',
        paddingTop: 5,
        fontSize: 12,
        paddingLeft: 3
    },
    ListItens: {
        fontSize: 14,
        paddingRight: 5
    },
    especial: {
        fontSize: 14,
        paddingRight: 5,
        color: '#EF0000'
    },
    tabela_Title: {
        height: 25,
        alignSelf: 'stretch',
        backgroundColor: '#Ef0000',
        display: 'flex',
        justifyContent: 'center',
        alignItems: 'center',
        borderTopRightRadius: 5,
        borderTopLeftRadius: 5
    },
    itens_flex: {
        display: 'flex',
        flexDirection: 'row',
        width: 220
    },
    itens_column: {
        display: 'flex',
        flexDirection: 'column'
    },
    titles: {
        marginRight: '2%',
        width: 220
    },
    footerDash: {
        paddingTop:2,
        alignItems: "center",
        paddingRight: 20,
        paddingLeft: 20,
        borderTopColor: '#11111',
        borderTopWidth: StyleSheet.hairlineWidth
    },
    curriculos: {
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'space-between',
        height: '100%',
        alignSelf: 'stretch'
    },
    titleInscricoes: {
        padding: 20,
        paddingBottom: 0
    },
    contInscricoes: {
        marginRight: '2%',
        width: 220,
    },
    contItens: {
        fontSize: 12
    }
});