import React from "react";
import "../Styles/JobChoices.css";

const JobChoices = () => {
  return (
    <div dir="rtl" className="row divStyle rounded mx-auto">
      <i role="button" className="bi bi-trash-fill iconStyle col"></i>
      <i role="button" className="bi bi-heart iconStyle col"></i>
      <div className="col-5"></div>
      <button className="btn btn-outline-light btn-lg px-3 sendCvBtn me-4 col-3">
        הגשת מועמדות
      </button>
      <i role="button" className="bi bi-pencil-square iconStyle col"></i>
    </div>
  );
};

export default JobChoices;
