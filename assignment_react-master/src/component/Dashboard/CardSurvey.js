import React,{useRef} from "react";
// import "./Card.css"
import StorageIcon from "@material-ui/icons/Storage";
import MoreVertIcon from "@material-ui/icons/MoreVert";
import doc_image from "./../../image/t-shirt.png";
import { useHistory } from "react-router-dom";
import { CardGroup, Card, Row, Col, Nav, Sonnet, Tab } from "react-bootstrap";
import moment from 'moment';
import { MDBCard, MDBCardBody, MDBCardTitle, MDBCardText, MDBCardImage, MDBBtn,MDBCardFooter } from 'mdb-react-ui-kit';


export default function CardSurvey({ data }) {
function timeCalc(date) {
  return moment(date).fromNow()
}
function TimeCalc({date}) {
  return <p style={{fontSize: '16px', textAlign:'center'}}>{timeCalc(date)}</p>
}

  const history = useHistory();
  function navigate_to(data) {
    history.push("/survey/" + data);
  }
  return (
        <MDBCard style={{ maxWidth: '22rem', marginBottom:'20px' }}  md={3} sx={4}   >
        <MDBCardImage src='https://thuthuatoffice.net/wp-content/uploads/2021/08/googledocs.webp' 
        position='top' alt='...' style={{paddingTop: '4px', height:'280px'}}/>
        <MDBCardBody>
          <MDBCardTitle>{data ? data.document_name : " Tài liệu không có tiêu đề" }</MDBCardTitle>
          <MDBCardText>
          {data ? data.doc_desc : " Tài liệu không có tiêu đề" }.
          </MDBCardText>
          <MDBBtn onClick={(e)=>{navigate_to(data.id)}}>Click</MDBBtn>
        </MDBCardBody>
        <MDBCardFooter className='text-muted'><TimeCalc date={data.endDate}/></MDBCardFooter>
      </MDBCard>
       
    // </div>
  );
}
