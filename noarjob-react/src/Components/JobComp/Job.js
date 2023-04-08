import Card from "../Card";
import React from "react";
import JobSettings from "./JobSettings";
import JobChoices from "./JobChoices";
import "../Styles/Job.css";

const Job = (props) => {
  const categoriesKeys = Object.keys(props.categories);
  delete props.categories[categoriesKeys[0]];
  return (
    <Card cardSize={"col-xl-8"}>
      <div dir="rtl" className="container">
        <div className="row mb-4 text-light">
          <p className="col-5">קטגוריית החברה: {props.companyTypeName}</p>
          <p className="col">שם המעסיק: {props.employerName}</p>
          <p className="col">מספר העובדים: {props.numOfEmployees}</p>
        </div>
        <div className="row justify-content-md-center mb-4 text-light">
          <p className="col-4">מספר טלפון: {props.phone}</p>
          <p className="col-5">אמייל: {props.email}</p>
        </div>
        <h1 className="mt-2 jobTitle">{props.title}</h1>
        {props.userJobType === 1 ? (
          <React.Fragment>
            <h2 className="fw-bold mb-2 text-uppercase subTitle text-decoration-underline">
              {props.companyName}
            </h2>
            <h4 className="mb-5 text-uppercase" style={{ color: "#CEE5D0" }}>
              תאריך הגשת המועמדות: {props.dateApplicated}
            </h4>
          </React.Fragment>
        ) : (
          <h2 className="fw-bold mb-5 text-uppercase subTitle text-decoration-underline">
            {props.companyName}
          </h2>
        )}

        <JobSettings
          categoryTitle="מיקום המשרה"
          categoryBtnTxt="בחר עיר"
          categoryOptions={props.cities}
        />
        <JobSettings
          categoryTitle="סוג המשרה"
          categoryBtnTxt="בחר סוג"
          categoryOptions={props.types}
        />
        <JobSettings
          categoryTitle="קטגוריית המשרה"
          categoryBtnTxt="בחר קטגורייה"
          categoryOptions={props.categories}
        />

        <div className="div-size text-align-right">
          <h4 className="text-decoration-underline">תיאור:</h4>
          <p className="mb-3">{props.description}</p>
        </div>
        <div className="div-size text-align-right">
          <h4 className="text-decoration-underline">דרישות:</h4>
          <p className="mb-3">{props.requirements}</p>
        </div>
      </div>
      <JobChoices
        jobId={props.jobId}
        dateApplicated={props.dateApplicated}
        userJobType={props.userJobType}
        userId={props.userId}
        setJobs={props.setJobs}
      />
    </Card>
  );
};

export default Job;
