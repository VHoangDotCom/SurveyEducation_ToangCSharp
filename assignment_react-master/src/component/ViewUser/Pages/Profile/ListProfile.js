// import React from 'react'
import React, { useEffect, useState } from "react";
import { useParams } from "react-router";
import axios from "axios";
import Profile from "./Profile";
import { useAuth0 } from "@auth0/auth0-react";

function ListProfile() {
     const { user, isAuthenticated, isLoading } = useAuth0();
     const [answer, setAnswer] = useState([])
     useEffect(() => {
          async function data_adding() {
            var request = await axios.get(`http://localhost:3000/answer_request/`);
            var question_data = request.data;
            setAnswer(question_data)

          }
          data_adding();
        }, []);
        if (isLoading) {
          return <div>Loading ...</div>;
        }
        // console.log('hehe',answer) 
  return (
    <div>
         <Profile answer={answer} user={user}/>
    </div>
  )
}

export default ListProfile