import React from 'react'
import { useAuth0 } from '@auth0/auth0-react'
import './style.css'


const LogoutForm = () => {
    const {logout,isAuthenticated} = useAuth0()
  return (
    
       isAuthenticated && ( <button className='btn-click' onClick={() => logout({ returnTo: window.location.origin })}>
      Log Out
    </button>)
    
  )
}

export default LogoutForm