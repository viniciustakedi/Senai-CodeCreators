import jwtDecode, { JwtPayload } from "jwt-decode";

var token = "";

export function SetToken(item: any) {
    token = item
}

export function RemoveToken() {
    token = ""
}

export const parseJWT = () => {

    // const AsyncToken = "";
    // const token = AsyncToken + "";

    if (token === undefined || token === null || token === "") {
        return undefined
    }
    else {
        const decoded = jwtDecode<JwtPayload>(token); // Returns with the JwtPayload type
        const TakeRole = 2 //role user
        // Object.values(decoded)[2] as any;
        const idUser = Object.values(decoded)[1] as any; //jti

        console.log(decoded);
        console.log(TakeRole);
        console.log(idUser);

        return TakeRole
    }
}

