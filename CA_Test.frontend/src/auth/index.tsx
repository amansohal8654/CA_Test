import { useState } from 'react'
import nookies from "nookies";


export default function userAuth() {
    const [authUser, setAuthUser] = useState(null);
    const [loading, setLoading] = useState(true);
    
    const clear = () => {
        setAuthUser(null);
        setLoading(true);
        nookies.destroy(null, "token");
        nookies.set(null, "token", "", { path: '/' });
    };
    return {
        authUser,
        setAuthUser,
        loading,
        clear,
    };
}