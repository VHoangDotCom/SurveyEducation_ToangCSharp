import React,{useState,useEffect} from 'react'
import "./Mainbody.css"
import StorageIcon from '@material-ui/icons/Storage';
import ArrowDropDownIcon from '@material-ui/icons/ArrowDropDown';
import FolderOpenIcon from '@material-ui/icons/FolderOpen';
import { IconButton } from '@material-ui/core';
import Card from "../Survey/Card" 
import Card_User from '../View/Card_User'
import axios from "axios";

function Mainbody() {
    const [files,setFiles]=useState([]);
  
    useEffect(() => {
        async function filenames(){
            
            // var request = await axios.get("https://localhost:44334/api/surveys")
            var request = await axios.get("http://localhost:3000/survey/")
            
            let files = request.data;
            setFiles(files)
        }
        filenames()
        
    },[])

    
    return (
        <div className="mainbody">
            <div className="main_top">
              <div className="main_top_left" style={{fontSize:"16px",fontWeight:"500"}}>Recent forms</div>
             

                <div className="main_top_right">
                <div className="main_top_center" style={{fontSize:"14px",marginRight:"125px"}}>Owned by anyone <ArrowDropDownIcon/></div>
                    <IconButton >
                       <StorageIcon style={{    fontSize: '16px',color:"black"}}/>
                    </ IconButton>
                    <IconButton >
                      <FolderOpenIcon style={{    fontSize: '16px',color:"black"}}/>
                    </ IconButton>
                </div>
            </div>
            <h2 className='text-divider'>List Servey</h2>
            <div className="main_docs">
                    
                 {
                    files.map((ele,index)=>{
                        return (
                            <>
                            <div className="docs-content">
                                <div className="docs-survey">
                                    <Card  key={index} name={ele}/>
                                </div>
                               
                            </div>
                            </>
                        )
                    })            
                 }
                 {/* <Card />    */}
            </div>
            <h2 className='text-divider' style={{marginTop:"30px"}}>List Report</h2>
            <div className="main_docs">
                 {
                    files.map((ele,index)=>{
                        return (
                            <>
                            <div className="docs-content">
                               
                                <div className="docs-report">
                                    <Card_User key={index} name={ele}/>
                                </div>
                            </div>
                            </>
                        )
                    })            
                 }
                 {/* <Card />    */}
            </div>
        </div>
    )
}

export default Mainbody
