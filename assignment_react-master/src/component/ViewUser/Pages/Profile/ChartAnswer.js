// import React from 'react'
import React, { useEffect, useState } from "react";

function ChartAnswer({listData}) {
  const [dataArr,setDataa] = useState([])
    useEffect(() => {
      setDataa(listData)
    },listData)

  return (
    <div className="row">
          {dataArr && dataArr.map((data)=>{
            return (
              <div className="col-sm-6 mb-3">
                            <div className="card h-100">
                              <div className="card-body">
                                <h6 className="d-flex align-items-center mb-3">
                                  <i className="material-icons text-info mr-2 pd-2">
                                    survey: 
                                  </i>
                                  {data.doc_name ? data.doc_name : `Chưa có tiêu đề`}
                                </h6>
                                {(data.list_answer).map((ques) => {
                                 return (
                                  <>
                                  <h5 style={{color: 'green'}}>{ques.question}</h5>
                                  <p>{ques.answer}</p>
                                  {/* <div
                                    className="progress mb-3"
                                    style={{ height: " 5px" }}
                                  >
                                    <div
                                      className="progress-bar bg-primary"
                                      role="progressbar"
                                      style={{ width: "80%" }}
                                      aria-valuenow="80"
                                      aria-valuemin="0"
                                      aria-valuemax="100"
                                    ></div>
                                  </div> */}
                                  </>
                                 )
                                })}
                                
                                {/* <small>Website Markup</small>
                                <div
                                  className="progress mb-3"
                                  style={{ height: " 5px" }}
                                >
                                  <div
                                    className="progress-bar bg-primary"
                                    role="progressbar"
                                    style={{ width: "72%" }}
                                    aria-valuenow="72"
                                    aria-valuemin="0"
                                    aria-valuemax="100"
                                  ></div>
                                </div>
                                <small>One Page</small>
                                <div
                                  className="progress mb-3"
                                  style={{ height: " 5px" }}
                                >
                                  <div
                                    className="progress-bar bg-primary"
                                    role="progressbar"
                                    style={{ width: "89%" }}
                                    aria-valuenow="89"
                                    aria-valuemin="0"
                                    aria-valuemax="100"
                                  ></div>
                                </div>
                                <small>Mobile Template</small>
                                <div
                                  className="progress mb-3"
                                  style={{ height: " 5px" }}
                                >
                                  <div
                                    className="progress-bar bg-primary"
                                    role="progressbar"
                                    style={{ width: "55%" }}
                                    aria-valuenow="55"
                                    aria-valuemin="0"
                                    aria-valuemax="100"
                                  ></div>
                                </div>
                                <small>Backend API</small>
                                <div
                                  className="progress mb-3"
                                  style={{ height: " 5px" }}
                                >
                                  <div
                                    className="progress-bar bg-primary"
                                    role="progressbar"
                                    style={{ width: "66%" }}
                                    aria-valuenow="66"
                                    aria-valuemin="0"
                                    aria-valuemax="100"
                                  ></div>
                                </div> */}
                              </div>
                            </div>
                          </div>
            )
          })}
    </div>
  )
}

export default ChartAnswer