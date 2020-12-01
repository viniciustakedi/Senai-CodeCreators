import { parse } from "@babel/core";
import AsyncStorage from "@react-native-community/async-storage";
import jwtDecode, { JwtPayload } from "jwt-decode";
import { useState } from "react";



export const parseJWT = () => {
    AsyncStorage.getItem('Real-Vagas-Token').then(
        (token1: any) => {
            console.log(token1)
            const token = '"' + token1 + '"'
            console.log(token)

            if (token === undefined || token === null || token === "") {
                return undefined
            }
            else {
                const decoded = jwtDecode<JwtPayload>(token); // Returns with the JwtPayload type
                const TakeRole = Object.values(decoded)[2] as any; //role user
                // Object.values(decoded)[2] as any;
                const idUser = Object.values(decoded)[1] as any; //jti

                console.log(decoded);
                console.log(TakeRole);
                console.log(idUser);

                return TakeRole
            }
        })
}


