//content.js
import React from "react";
import { useParams } from "react-router";
import axios from "axios";
// import { toast } from "react-toastify";
import { useHistory } from "react-router-dom";
import 'react-toastify/dist/ReactToastify.css';
import { ToastContainer, toast } from 'react-toastify';
// toast.configure()

function Content ({ close,id }) {
    const history = useHistory();
    const deletetoDB = async () => {
        await axios.delete(`http://localhost:3000/survey/${id}`);
        // axios.get(`http://localhost:3000/survey/`)
        //  setTimeout((history.push("/")),2500)
       
    };
        return (
    
            <div className="modal">
              <a className="close" onClick={close}>
                ×
              </a>
              <div className="header">Xoá bài đánh giá</div>
              <div className="content">
                <span>Bạn có muốn xoá bài đánh giá này không? </span>
               
              </div>
             <div className="modal-button">
             <button className="button" onClick={close}>OUT</button>
              <button className="button button-delete" onClick={deletetoDB}> DELETE</button>
             </div>
              
            </div>
          );
     }
export default Content;