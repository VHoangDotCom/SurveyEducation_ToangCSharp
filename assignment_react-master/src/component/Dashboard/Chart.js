import {Line} from 'react-chartjs-2';
import React, { useState, useEffect } from "react";
import axios from "axios";
import ChartSurvey from './CardSurvey'


function Chart() {
  const [files, setFiles] = useState([]);
  const arrMonth = []
  useEffect(() => {
       async function filenames() {
         // var request = await axios.get("https://localhost:44334/api/surveys")
         var request = await axios.get("http://localhost:3000/survey/");
   
         let files = request.data;
         setFiles(files);
       }
       filenames();
     }, []);
     console.log("files", files)
  
  
     files.map((file,index)=>{
       arrMonth.push(file.endDate)
     })
    
    return (
      <>
      {/* <ChartSurvey arrMonth={arrMonth}/> */}
      </>
    );
  }

export default Chart();