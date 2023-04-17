import React, { useContext } from "react";
import "../Styles/JobChoices.css";
import { variables } from "../../Variables";
import { useNavigate } from "react-router-dom";
import { AppContext } from "../../AppContext";

const JobChoices = (props) => {
  //המשתנה הבוליאני של האם המשתמש נמצא במסך המשרות שלי
  const { setJobForApplication, isMyJobs } = useContext(AppContext);

  const navigate = useNavigate();

  /*פונקציה שמופעלת כאשר המשתמש רוצה למחוק משרה ואז
  הוא לא יכול לראות את אותה משרה לעולם */
  const DeleteJob = () => {
    if (props.userId !== undefined) {
      if (props.userJobType === 0) {
        if (window.confirm("לעולם לא תוכל לראות את המשרה הזאת, אתה בטוח?")) {
          fetch(
            variables.API_URL +
              "User/CreateUser_JobAtDeleteOrLove?jobID=" +
              props.jobId +
              "&userID=" +
              props.userId +
              "&userJobType=3"
          )
            .then(() => {
              props.setJobs((prevJobs) => {
                return prevJobs.filter((job) => job.jobID !== props.jobId);
              });
            })
            .catch((error) => console.error(error));
        }
      } else {
        fetch(
          variables.API_URL +
            "User/UpdateUserJobType?jobID=" +
            props.jobId +
            "&userID=" +
            props.userId +
            "&userJobType=3"
        )
          .then(() => {
            props.setJobs((prevJobs) => {
              return prevJobs.filter((job) => job.jobID !== props.jobId);
            });
          })
          .catch((error) => console.error(error));
      }
    } else {
      navigate("/Login");
    }
  };

  /*פונקציה שמופעלת כאשר המשתמש אוהב משרה וזה שומר לו את בחירתו 
  או שולח אותו למסך ההתחברות אם אין לו חשבון*/
  const LikeJob = (event) => {
    if (props.userId !== undefined) {
      if (props.userJobType === 0) {
        fetch(
          variables.API_URL +
            "User/CreateUser_JobAtDeleteOrLove?jobID=" +
            props.jobId +
            "&userID=" +
            props.userId +
            "&userJobType=2"
        )
          .then(() => {
            event.target.classList.remove("iconStyle");
            event.target.classList.remove("bi-heart");
            event.target.classList.add("likedJob");
            event.target.classList.add("bi-heart-fill");
            RefreshJobs();
          })
          .catch((error) => console.error(error));
      } else {
        fetch(
          variables.API_URL +
            "User/UpdateUserJobType?jobID=" +
            props.jobId +
            "&userID=" +
            props.userId +
            "&userJobType=2"
        )
          .then(() => {
            event.target.classList.remove("iconStyle");
            event.target.classList.remove("bi-heart");
            event.target.classList.add("likedJob");
            event.target.classList.add("bi-heart-fill");
            RefreshJobs();
          })
          .catch((error) => console.error(error));
      }
    } else {
      navigate("/Login");
    }
  };

  /* פונקציית עזר ששומרת את אהבת המשרה של המשתמש */
  const RefreshJobs = () => {
    if (isMyJobs) {
      fetch(variables.API_URL + "User/GetApplyForJobs?userID=" + props.userId)
        .then((response) => response.json())
        .then((data) => {
          props.setJobs(data);
        })
        .catch((error) => console.log(error));
    } else {
      props.setJobs((prevJobs) => {
        const job = prevJobs.find((job) => job.jobID === props.jobId);
        job.userJobType = 2;
        return [...prevJobs];
      });
    }
  };

  /* פונקציה שמטרתה להוסיף למשרות שהמשתמש אהב לב אדום */
  const likeClass = () => {
    let classes;
    if (props.userJobType !== 2) {
      classes = "bi bi-heart iconStyle";
    } else {
      classes = "bi bi-heart-fill likedJob";
    }
    return classes;
  };

  /* פונקציה שמופעלת כאשר המשתמש רוצה להוסיף קורות חיים
  וזה מעביר אותו למסך הגשת המועמדות אם יש לו חשבון*/
  const JobApplication = () => {
    if (props.userId !== undefined) {
      setJobForApplication({
        jobId: props.jobId,
        userJobType: props.userJobType,
      });
      navigate("/JobApplication");
    } else {
      navigate("/Login");
    }
  };

  return (
    <div dir="rtl" className="divStyle rounded mx-auto row">
      <div className="col-2">
        <i
          role="button"
          className="bi bi-trash-fill iconStyle ms-3"
          onClick={DeleteJob}
        ></i>
        <i role="button" className={likeClass()} onClick={LikeJob}></i>
      </div>
      <div className="col-6"></div>
      <button
        className="btn btn-outline-light btn-lg sendCvBtn col-4"
        onClick={JobApplication}
      >
        הגשת מועמדות
      </button>
    </div>
  );
};

export default JobChoices;
