import { Button, Typography } from "@material-ui/core";
import React, { useState, useEffect } from "react";
import FormControlLabel from "@material-ui/core/FormControlLabel";
import Radio from "@material-ui/core/Radio";
import { useHistory } from "react-router-dom";
import "./user_form.css";
import { useStateValue } from "../../StateProvider";
import axios from "axios";
import { actionTypes } from "../../redux/reducer";
import { useParams } from "react-router";
import { Icon, Input } from "semantic-ui-react";
import validator from "validator";
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import { useAuth0 } from '@auth0/auth0-react'
function User_form() {
  var quest = [];
  var post_answer = [];
  var history = useHistory();
  var [answerText, setAnswerText] = useState("");
  var [answer, setAnswer] = useState([]);
  var [email, setEmail] = useState("");
  var [{ questions, doc_name, doc_desc }, dispatch] = useStateValue();
  // console.log("email: " + email);
  const { user, isAuthenticated, isLoading } = useAuth0();
    
   

  let { id } = useParams();
  const d = new Date();
  const idText = `${id}_${d.getSeconds()}_${d.getMilliseconds()}`;

  function select(que, option) {
    var k = answer.findIndex((ele) => ele.question == que);

    answer[k].answer = option;
    setAnswer(answer);
  }

  useEffect(() => {
    questions.map((q) => {
      answer.push({
        question: q.questionText,
        answer: " ",
      });
    });
    questions.map((q, qindex) => {
      quest.push({ header: q.questionText, key: q.questionText });
    });
  }, [questions, answer]);

  useEffect(() => {
    async function data_adding() {
      var request = await axios.get(`http://localhost:3000/survey/${id}`);

      var question_data = request.data.questions;
      console.log(question_data);
      var doc_name = request.data.document_name;
      var doc_descip = request.data.doc_desc;
      dispatch({
        type: actionTypes.SET_DOC_NAME,
        doc_name: doc_name,
      });

      dispatch({
        type: actionTypes.SET_DOC_DESC,
        doc_desc: doc_descip,
      });
      dispatch({
        type: actionTypes.SET_QUESTIONS,
        questions: question_data,
      });
    }

    data_adding();
  }, []);
  if (isLoading) {
    return <div>Loading ...</div>;
  }
  var post_answer_data = {};
  function selectinputText(que, value, index) {
    var k = answer.findIndex((ele) => ele.question == que);
    if (k) {
      answer[k].answer = answerText;
    } else {
      console.log("answer loi");
    }
    setAnswer(answer);
    console.log("answer", answer);
  }

  function selectcheck(e, que, option) {
    var d = [];

    var k = answer.findIndex((e) => e.question == que);
    console.log(
      "selectcheck",
      e,
      que,
      option,
      "k: ",
      k,
      "answer[k]: ",
      answer[k]
    );
    if (answer[k].answer) {
      d = answer[k].answer.split(",");
    }
    if (e == true) {
      d.push(option);
    } else {
      var n = d.findIndex((el) => el.option == option);
      d.splice(n, 1);
    }

    answer[k].answer = d.join(",");

    setAnswer(answer);
    console.log(answer);
  }

  function submit() {
    answer.map((ele) => {
      post_answer_data[ele.question] = ele.answer;
    });
    delete answer.shift(0);
    
    if (!user.email) {
      console.log("err");
      toast.error("Lỗi rồi, phải nhập đúng email", {
        position: "top-right",
        autoClose: 5000,
        hideProgressBar: false,
        closeOnClick: true,
        pauseOnHover: true,
        draggable: true,
        progress: undefined,
      });
    } else {
      console.log('answer', answer)
     toast.success("Thành công", {
          position: "top-right",
          autoClose: 5000,
          hideProgressBar: false,
          closeOnClick: true,
          pauseOnHover: true,
          draggable: true,
          progress: undefined,
        });
        axios.post(`http://localhost:3000/answer_request/`, {
          id: idText,
          cloumn: user.email,
          dateSubmit: d,
          doc_name: doc_name,
          list_answer: answer,
        });
        history.push(`/submitted`);
      
    }
  }

  return (
    <div className="submit">
      <div className="user_form">
        <div className="user_form_section">
          <div className="user_title_section">
            <Typography style={{ fontSize: "26px" }}>{doc_name}</Typography>
            <Typography style={{ fontSize: "15px" }}>{doc_desc}</Typography>
            <br />
          
          </div>
          <ToastContainer
            position="top-right"
            autoClose={5000}
            hideProgressBar={false}
            newestOnTop={false}
            closeOnClick
            rtl={false}
            pauseOnFocusLoss
            draggable
            pauseOnHover
          />
          {/* Same as */}
          <ToastContainer />
          <div></div>

          {questions.map((question, qindex) => (
            <div className="user_form_questions">
              <Typography
                style={{
                  fontSize: "15px",
                  fontWeight: "400",
                  letterSpacing: ".1px",
                  lineHeight: "24px",
                  paddingBottom: "8px",
                }}
              >
                {qindex + 1}. {question.questionText}
              </Typography>
              {question.options.map((ques, index) => (
                <div key={index} style={{ marginBottom: "5px" }}>
                  <div style={{ display: "flex" }}>
                    <div className="form-check">
                      {question.questionType != "radio" ? (
                        question.questionType != "text" ? (
                          <label>
                            <input
                              type={question.questionType}
                              name={qindex}
                              value={ques.optionText}
                              className="form-check-input"
                              required={question.required}
                              style={{  marginRight: "5px" }}
                              onChange={(e) => {
                                selectcheck(
                                  e.target.checked,
                                  question.questionText,
                                  ques.optionText
                                );
                              }}
                            />{" "}
                            {ques.optionText}
                          </label>
                        ) : (
                          //input
                          <label>
                            <input
                              key={index}
                              type={question.questionType}
                              name={qindex}
                              // value={answer.map(ele)=> ele.}
                              className="form-check-input"
                              required={question.required}
                              style={{
                                width:"200px",
                                height: "30px",
                                borderRadius: "5px",
                                // marginLeft: "5px",
                                marginRight: "5px",
                              }}
                              onChange={(e) => {
                                selectinputText(
                                  question.questionText,
                                  setAnswerText(e.target.value),
                                  index
                                );
                              }}
                            />{" "}
                          </label>
                        )
                      ) : (
                        //checkbox
                        <label>
                          <input
                            type={question.questionType}
                            name={qindex}
                            value={ques.optionText}
                            className="form-check-input"
                            required={question.required}
                            style={{ marginRight: "5px" }}
                            onChange={() => {
                              select(question.questionText, ques.optionText);
                            }}
                          />
                          {ques.optionText}
                        </label>
                      )}
                    </div>
                  </div>
                </div>
              ))}
            </div>
          ))}

          <div className="user_form_submit">
            <Button
              variant="contained"
              color="primary"
              onClick={submit}
              style={{ fontSize: "14px" }}
            >
              Submit
            </Button>
          </div>

          <div className="user_footer">Bình Javascript :v</div>
        </div>
      </div>
    </div>
  );
}

export default User_form;
