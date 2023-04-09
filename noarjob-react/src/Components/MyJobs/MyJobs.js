import React, { useRef, useState, useEffect, useContext } from "react";
import Jobs from "../JobComp/Jobs";
import { variables } from "../../Variables";
import { AppContext } from "../../AppContext";

const MyJobs = (props) => {
  const lovedJobsBtn = useRef(null);
  const applyForBtn = useRef(null);

  const { setIsMyJobs } = useContext(AppContext);
  useEffect(() => {
    setIsMyJobs(true);
  }, []);

  //סוגי המשרה 1-משרות ששלחתי אליהם מועמדות
  //2-משרות שאהבתי
  const [jobsType, setJobsType] = useState(1);

  const ShowApplyForJobs = (event) => {
    fetch(variables.API_URL + "User/GetApplyForJobs?userID=" + props.userId)
      .then((response) => response.json())
      .then((data) => {
        props.setJobs(data);
      })
      .catch((error) => console.log(error));

    if (jobsType !== 1) {
      event.target.classList.add("shadow-lg");
      event.target.classList.add("chosenBtn");
      event.target.classList.remove("myBtn");
      lovedJobsBtn.current.classList.add("myBtn");
      lovedJobsBtn.current.classList.remove("shadow-lg");
      lovedJobsBtn.current.classList.remove("chosenBtn");
      setJobsType(1);
    }
  };

  const ShowLovedJobs = (event) => {
    fetch(variables.API_URL + "User/GetLovedJobs?userID=" + props.userId)
      .then((response) => response.json())
      .then((data) => {
        props.setJobs(data);
      })
      .catch((error) => console.log(error));

    if (jobsType !== 2) {
      event.target.classList.add("shadow-lg");
      event.target.classList.add("chosenBtn");
      event.target.classList.remove("myBtn");
      applyForBtn.current.classList.add("myBtn");
      applyForBtn.current.classList.remove("shadow-lg");
      applyForBtn.current.classList.remove("chosenBtn");
      setJobsType(2);
    }
  };

  return (
    <React.Fragment>
      <div className="row d-flex justify-content-center mx-0">
        <div className="col-xl-8 mb-4">
          <div dir="rtl" className="row">
            <button
              ref={applyForBtn}
              className="btn btn-outline-light btn-lg chosenBtn fs-4 col shadow-lg"
              onClick={ShowApplyForJobs}
            >
              היסטוריית משרות אליהם הגשתי מועמדות
            </button>
            <button
              ref={lovedJobsBtn}
              className="btn btn-outline-light btn-lg myBtn fs-4 col"
              onClick={ShowLovedJobs}
            >
              היסטוריית משרות אליהם הגשתי מועמדות
            </button>
          </div>
        </div>
        <Jobs jobs={props.jobs} setJobs={props.setJobs} userId={props.userId} />
      </div>
    </React.Fragment>
  );
};

export default MyJobs;
