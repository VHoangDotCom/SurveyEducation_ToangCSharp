import React, { useState, useEffect } from "react";
import { IconButton } from "@material-ui/core";
import "./Templates.css";
import blank from "./../../image/forms-blank-googlecolors.png";
import party from "./../../image/party_invite.png";
import contact from "./../../image//contact.png";
import { useHistory } from "react-router-dom";
import uuid from "react-uuid";
import axios from "axios";

import UnfoldMoreIcon from "@material-ui/icons/UnfoldMore";
import MoreVertIcon from "@material-ui/icons/MoreVert";
function Templates() {
  const history = useHistory();

  function createform() {
    var create_form_id = uuid();
    console.log("create_form_id", create_form_id);

    history.push("/form/" + create_form_id);
    var questions_list = [
      {
        questionText: "Question",
        questionType: "radio",
        options: [{ optionText: "Option 1" }],
        open: true,
        required: false,
      },
    ];

    axios.post(`http://localhost:3000/survey/${create_form_id}`, {
      document_name: "untitled_form",
      doc_desc: "Add Description",
      questions: questions_list,
    });
  }
  return (
    <div className="template_section">
      <div className="template_top">
        <div className="template_left">
          <p style={{ color: "#202124", fontSize: "16px" }}>Start a new form</p>
        </div>
        <div className="template_right">
          <div className="gallery_button">
            Template gallery
            <UnfoldMoreIcon fontSize="small" />
          </div>
          <IconButton>
            <MoreVertIcon fontSize="small" />
          </IconButton>
        </div>
      </div>
      <div className="template_body">
        <div className="card" onClick={createform}>
          <img src={blank} className="card_image" style={{}} />
          <p className="title">Blank</p>
        </div>
        <div className="card">
          <img src={party} className="card_image" style={{}} />
          <p className="title" style={{ fontSize: "small" }}>
            Party Invite
          </p>
        </div>
        <div className="card">
          <img src={contact} className="card_image" style={{}} />
          <p className="title" style={{ fontSize: "small" }}>
            Contact Information
          </p>
        </div>
      </div>
    </div>
  );
}

export default Templates;
