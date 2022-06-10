import React,{ useState} from 'react';
import {
  MDBContainer,
  MDBNavbar,
  MDBNavbarBrand,
  MDBNavbarToggler,
  MDBIcon,
  MDBNavbarNav,
  MDBNavbarItem,
  MDBNavbarLink,
  MDBBtn,
  MDBDropdown,
  MDBDropdownToggle,
  MDBDropdownMenu,
  MDBDropdownItem,
  MDBDropdownLink,
  MDBCollapse,
  
} from 'mdb-react-ui-kit';
import 'mdb-react-ui-kit/dist/css/mdb.min.css'
import { useHistory } from "react-router-dom";
import LoginForm from '../../../Pages/Login/LoginForm';
import LogoutForm from '../../../Pages/Login/LogoutForm';
import ProfileUser from '../../../Pages/Login/ProfileUser';
import { useAuth0 } from '@auth0/auth0-react'

export default function Header() {
  const history = useHistory();
  const [showBasic, setShowBasic] = useState(false);
  const {loginWithRedirect,isAuthenticated} = useAuth0();
  const location = {
    pathprofile: '/profile',
    pathhome: '/',
    // state: { fromDashboard: true }
  }
  const navigate_to = () =>{
   
    history.push('/profile')
  }
  const navigate_to_home = () =>{
    history.push('/')
  }
 
  return (
   
     <>
     <MDBNavbar expand='lg' light bgColor='light'>
      <MDBContainer fluid>
        <MDBNavbarBrand onClick={(e)=>{
                  navigate_to_home()
                 }}>Toang C#</MDBNavbarBrand>

        <MDBNavbarToggler
          aria-controls='navbarSupportedContent'
          aria-expanded='false'
          aria-label='Toggle navigation'
          onClick={() => setShowBasic(!showBasic)}
        >
          <MDBIcon icon='bars' fas />
        </MDBNavbarToggler>

        <MDBCollapse navbar show={showBasic}>
          <MDBNavbarNav className='mr-auto mb-2 mb-lg-0'>
            <MDBNavbarItem>
              <MDBNavbarLink active aria-current='page'  onClick={(e)=>{
                  navigate_to_home()
                 }}>
                Home
              </MDBNavbarLink>
            </MDBNavbarItem>
            <MDBNavbarItem>
              <MDBNavbarLink >Link</MDBNavbarLink>
            </MDBNavbarItem>

            <MDBNavbarItem>
              
            </MDBNavbarItem>

            <MDBNavbarItem>
              {isAuthenticated && (<MDBNavbarLink style={{cursor: 'pointer'}} aria-current='page' onClick={(e)=>{
                  navigate_to()
                 }}>
                Profile
              </MDBNavbarLink>)}
            </MDBNavbarItem>
          </MDBNavbarNav>

          <LoginForm/>
          <LogoutForm/>
          {/* <ProfileUser/> */}
        </MDBCollapse>
      </MDBContainer>
    </MDBNavbar>
      </>
    
  );
}