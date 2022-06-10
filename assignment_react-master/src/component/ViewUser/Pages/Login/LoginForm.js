import React from 'react'
import { useAuth0 } from '@auth0/auth0-react'
import './style.css'

const LoginForm = () => {
  const {loginWithRedirect,isAuthenticated} = useAuth0();
  return (
    !isAuthenticated && (<button className='btn-click' onClick={()=> loginWithRedirect()}>Login</button>)
  
  )
}

export default LoginForm