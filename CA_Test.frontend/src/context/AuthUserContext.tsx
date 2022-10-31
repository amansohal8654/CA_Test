import { createContext, useContext, Dispatch } from 'react'
import userAuth from '@/auth'

const authUserContext = createContext<{
  authUser: {};
  setAuthUser: Dispatch<any>;
  loading: boolean;
}>({
  authUser: null,
  loading: true,
  setAuthUser: () => {},
});

export function AuthUserProvider({ children }) {
  const auth = userAuth();
  return <authUserContext.Provider value ={auth}>{children}</authUserContext.Provider>;
}
export const useAuth = () => useContext(authUserContext);