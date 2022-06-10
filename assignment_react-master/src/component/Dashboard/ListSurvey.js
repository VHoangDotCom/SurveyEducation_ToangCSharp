import React, { useState, useEffect } from "react";
// import "./styles.css";
import { Container, Card, Row, Col, Nav, Sonnet, Tab } from "react-bootstrap";
import { useHistory } from "react-router-dom";
import CardSurvey from './CardSurvey'

const Pagination = ({files}) => {

  // const [post, setPost] = useState([]);
  const [number, setNumber] = useState(1); // No of pages
  const [postPerPage] = useState(6);
  const history = useHistory();




  const lastPost = number * postPerPage;
  const firstPost = lastPost - postPerPage;
  const currentPost = files.slice(firstPost, lastPost);
  const pageNumber = [];

  for (let i = 1; i <= Math.ceil(files.length / postPerPage); i++) {
    pageNumber.push(i);
  }

  const ChangePage = (pageNumber) => {
    setNumber(pageNumber);
    console.log("number changed", pageNumber);
  };
 
  return (
    <>
      <Container>
        <Row>
          {currentPost.map((Val) => {
            return (
               <CardSurvey data={Val}/>
              
            );
          })}

          <div className="my-3 text-center">
            <button
              className="px-3 py-1 m-1 text-center btn-primary"
              onClick={() => setNumber(number - 1)}
            >
              Previous
            </button>

            {pageNumber.map((Elem) => {
              return (
                <>
                  <button
                    className="px-3 py-1 m-1 text-center btn-outline-dark"
                    onClick={() => ChangePage(Elem)}
                  >
                    {Elem}
                  </button>
                </>
              );
            })}
            <button
              className="px-3 py-1 m-1 text-center btn-primary"
              onClick={() => setNumber(number + 1)}
            >
              Next
            </button>
            {/* const asd = (second) => { third } */}
          </div>
        </Row>
      </Container>
    </>
  );
};

export default Pagination;
