import Head from 'next/head'
import Login from './login'
import { useAuth } from "@/context/AuthUserContext"
import {useEffect} from "react"
import Router from "next/router"

export default function Home() {
  
  return (
    <>
      <Head>
        <title>Student Portal</title>
        <meta
          name="description"
          content="Most bookkeeping software is accurate, but hard to use. We make the opposite trade-off, and hope you don’t get audited."
        />
      </Head>
      <main>
        <Login />
      </main>
    </>
  )
}

