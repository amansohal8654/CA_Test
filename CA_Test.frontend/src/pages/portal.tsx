import Layout from "@/components/Layout"
import { useAuth } from "@/context/AuthUserContext"
import {useEffect} from "react"
import Router from "next/router"
import Courses from "@/components/Courses"
import Students from "@/components/Students"

export default function Portal() {
  const { authUser } : {authUser : any} = useAuth()
  useEffect(() => {
    if(authUser === null) {
      Router.push("/login")
    }
  }, [])

  return (
    <>
      <Layout />
      {authUser !== null && <main className = "p-8">
        {
           authUser?.role === "Admin" ? <Students/> : <Courses />
        }
      </main>}
    </>
  )
}
