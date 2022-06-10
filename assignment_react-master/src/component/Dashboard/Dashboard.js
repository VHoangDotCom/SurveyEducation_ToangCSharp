import React, { useState, useEffect } from "react";
import "./Dashboard.css";
import "./Boostrap.css";
import "bootstrap/dist/css/bootstrap.min.css";
import { Container, Navbar, Row, Col, Nav, Sonnet, Tab } from "react-bootstrap";
import Header from "../SurveyList/Header";
import Mainbody from "../SurveyList/Mainbody";
import Card from "../Survey/Card";
import ListSurvey from "./ListSurvey";
import Pagination from "./ListSurvey";
import Templates from "../SurveyList/Templates";
import ChartSurvey from "./ChartSurvey";
import axios from "axios";

export default function Dashboard() {
  const [files, setFiles] = useState([]);
  const [answer, setAnswer] = useState([]);
  let listItems = 0;
  let listAnswer = 0;
  let dateYear = [];
  let answerYear = [];
  useEffect(() => {
    async function filenames() {
      // var request = await axios.get("https://localhost:44334/api/surveys")
      var requestSurvey = await axios.get("http://localhost:3000/survey/");
      var requestAnswer = await axios.get(
        "http://localhost:3000/answer_request"
      );

      let fileSurvey = requestSurvey.data;
      let fileAnswer = requestAnswer.data;
      setFiles(fileSurvey);
      setAnswer(fileAnswer);
    }
    filenames();
  }, []);
  files.map((file) => {
    dateYear.push(new Date(file.endDate).getFullYear());
  });

  answer.map((file) => {
    answerYear.push(new Date(file.dateSubmit).getFullYear());
  });
  console.log("files", answerYear);

  /*Tạo hàm đếm số lần xuất hiện của một phần tử trong mảng JavaScript*/
  let arrDate = [];
  let arrSurvey = [];
  let arrNews = ["Year", "Survey"];
  function count_element_in_array(dateYear, x) {
    let count = 0;
    for (let i = 0; i < dateYear.length; i++) {
      if (dateYear[i] == x)
        //Tìm thấy phần tử giống x trong mảng thì cộng biến đếm
        count++;
    }
    // console.log( "Phan tu " +  x  + " xuat hien " + count +  " lan");
    arrDate.push(x, count);
  }

  /*Xóa phần tử trùng nhau và lấy các phần tử duy nhất*/
  let arrayWithNoDuplicates = dateYear.reduce(function (accumulator, element) {
    if (accumulator.indexOf(element) === -1) {
      accumulator.push(element);
    }
    return accumulator;
  }, []);
  /*đếm số lần xuất hiện của các phần tử duy nhất*/
  for (let i = 0; i < arrayWithNoDuplicates.length; i++)
    count_element_in_array(dateYear, arrayWithNoDuplicates[i]);

  for (let i = 0; i < arrDate.length; i++) {
    if (i % 2 == 0) {
      arrSurvey.push([arrDate[i], arrDate[i + 1]]);
    }
  }
  let listData = [];
  arrSurvey.map((ele, i) => {
    const arrEle = Object.values(ele);
    const strEle = arrEle[0].toString();
    listData.push([`${strEle}`, arrEle[1]]);
  });
  listData = [arrNews].concat(listData);

  listItems = files.length;
  listAnswer = answer.length;

  return (
    <>
      <Header />
      <div
        className="wrapper"
        style={{
          marginTop: "30px",
          backgroundColor: "#F4F4F9",
          minHeight: "100vh",
        }}
      >
        <Tab.Container id="left-tabs-example" defaultActiveKey="second">
          <Row>
            <Col
              sm={3}
              style={{ backgroundColor: "#efe9e9", minHeight: "100vh" }}
            >
              <Nav variant="pills" className="flex-column">
                <Nav.Item>
                  <Nav.Link eventKey="create_survey">Create Survey</Nav.Link>
                </Nav.Item>
                <Nav.Item>
                  <Nav.Link eventKey="first">Survey Report</Nav.Link>
                </Nav.Item>
                <Nav.Item>
                  <Nav.Link eventKey="second">List Survey</Nav.Link>
                </Nav.Item>
              </Nav>
            </Col>
            <Col sm={9}>
              <Tab.Content>
                <Tab.Pane eventKey="create_survey">
                  <Templates />
                </Tab.Pane>
                <Tab.Pane eventKey="first">
                  {" "}
                  <ChartSurvey
                    listAnswer={listAnswer}
                    listItems={listItems}
                    listData={listData}
                  />
                </Tab.Pane>
                <Tab.Pane eventKey="second">
                  {/* <Card/> */}
                  <Pagination files={files} />
                </Tab.Pane>
              </Tab.Content>
            </Col>
          </Row>
        </Tab.Container>
      </div>
    </>
  );
}
