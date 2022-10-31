import type { AppProps } from 'next/app'
import '@/styles/index.css'
import 'focus-visible'
import { AuthUserProvider } from '@/context/AuthUserContext';

export default function MyApp({ Component, pageProps }: AppProps) {
  return (
    <AuthUserProvider>
      <Component {...pageProps} />
    </AuthUserProvider>
  )
}