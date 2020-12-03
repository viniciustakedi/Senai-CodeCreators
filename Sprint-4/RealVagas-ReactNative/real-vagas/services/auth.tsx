import AsyncStorage from "@react-native-community/async-storage";
import jwtDecode, { JwtPayload } from "jwt-decode";
import { useState } from "react";

export const BuscarId = () => {
    const [idUsuario, setIdUsuario] = useState("")

    parseJWT()
    AsyncStorage.getItem('Real-Vagas-Id-Usuario').then((item: any) => {
        setIdUsuario(item)
    })

    console.log(idUsuario);
    return idUsuario
}

export const parseJWT = () => {

    const [token, setToken] = useState("")

    AsyncStorage.getItem('Real-Vagas-Token').then(
        (token1: any) => {
            const GetToken = token1;
            setToken(GetToken)
        })

    
    console.log(token)

    if (token === undefined || token === null || token === "") {
        return undefined
    }
    else {
        const decoded = jwtDecode<JwtPayload>(token); // Returns with the JwtPayload type
        const TakeRole = Object.values(decoded)[2] as any; //role user
        // Object.values(decoded)[2] as any;
        const idUser = Object.values(decoded)[1] as any; //jti 

        AsyncStorage.setItem("Real-Vagas-Id-Usuario", idUser)
        
        console.log(decoded);
        console.log(TakeRole);
        console.log(idUser);
        return TakeRole
    }
}




    // useEffect(() => {
    //     teste()
    // }, [])


    // function DecodeToken(token: any) {
    //     const decoded = jwtDecode<JwtPayload>(token); // Returns with the JwtPayload type
    //     const TakeRole = Object.values(decoded)[2] as any; //role user
    //     // Object.values(decoded)[2] as any;
    //     const idUser = Object.values(decoded)[1] as any; //jti

    //     console.log(decoded);
    //     console.log(TakeRole);
    //     console.log(idUser);

    //     return TakeRole
    // }

    // const teste = async () => {
    //     const response = await AsyncStorage.getItem('Real-Vagas-Token')
    //     if(response === null || response === undefined){
    //         return undefined
    //     } else {
    //         DecodeToken(response)
    //         return response
    //     }
    // }

    // return DecodeToken(teste())