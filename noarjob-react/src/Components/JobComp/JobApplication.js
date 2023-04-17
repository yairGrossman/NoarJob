import React, { useState } from "react";
import "../Styles/JobApplication.css";
import { variables } from "../../Variables";
import { useNavigate } from "react-router-dom";

const JobApplication = (props) => {
  const navigate = useNavigate();
  //משתנה שבודק האם המשתמש במצב עריכת פרטים או לא
  const [editable, setEditable] = useState(false);
  //משתנה לשמירת העיר שהמשתמש בחר
  const [city, setCity] = useState();

  /*פונקציה שמופעלת כאשר המשתמש רוצה להוסיף/לבחור קורות חיים
  ושולחת אותו למסך קורות החיים*/
  const NavToCvs = () => {
    fetch(variables.API_URL + "User/SetUserCvs?userID=" + props.user.userID)
      .then((response) => response.json())
      .then((data) => {
        props.setUser((prevUser) => {
          return { ...prevUser, lstCvs: data.lstCvs };
        });
        navigate("/Cvs");
      });
  };

  //פונקציה לשמירת השם הפרטי
  const FirstName_TxtChanged = (event) => {
    props.setUser((prevUser) => {
      return { ...prevUser, firstName: event.target.value };
    });
  };

  //פונקציה לשמירת שם המשפחה
  const LastName_TxtChanged = (event) => {
    props.setUser((prevUser) => {
      return { ...prevUser, lastName: event.target.value };
    });
  };

  //פונקציה לשמירת הטלפון
  const Phone_TxtChanged = (event) => {
    props.setUser((prevUser) => {
      return { ...prevUser, phone: event.target.value };
    });
  };

  //פונקציה שמראה את אפשרויות הערים
  const City_TxtChanged = (event) => {
    const text = event.target.value;
    props.setUser((prevUser) => {
      return {
        ...prevUser,
        city: {
          key: 0,
          value: text,
        },
      };
    });
    if (text !== "") {
      fetch(variables.API_URL + "Cities/GetCities?text=" + text)
        .then((response) => response.json())
        .then((data) => {
          if (JSON.stringify(data) !== "{}") {
            const citiesIds = Object.keys(data);
            setCity({
              cityId: citiesIds[0],
              cityName: data[citiesIds[0]],
            });
          } else {
            setCity({
              cityId: 0,
              cityName: "",
            });
          }
        });
    } else {
      setCity({
        cityId: 0,
        cityName: "",
      });
    }
  };

  //פונקציה ששומרת את העיר שהמשתמש בחר
  const ChosenCity = () => {
    props.setUser((prevUser) => {
      return {
        ...prevUser,
        city: {
          key: city.cityId,
          value: city.cityName,
        },
      };
    });

    setCity({
      cityId: 0,
      cityName: "",
    });
  };

  /*פונקציה שמעדכנת את הפרטים של המשתמש */
  const EditUser = () => {
    if (editable) {
      fetch(variables.API_URL + "User/UpdateUser", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(props.user),
      })
        .then(() => {})
        .catch((error) => console.error(error));
      setEditable(false);
    } else setEditable(true);
  };

  /*פונקציה שמופעלת כאשר המשתמש רוצה להגיש מועמדות 
  ומוסיפה את מועמדותו לטבלה המקשרת בין משרה למועמד */
  const SendJobApplication = () => {
    const now = new Date();
    const dateApplicated = now.toLocaleDateString("en-US");
    const formData = new FormData();
    formData.append("jobID", props.jobForApplication.jobId);
    formData.append("userID", props.user.userID);
    formData.append("cvID", props.user.chosenCvForJob.cvID);
    formData.append("dateApplicated", dateApplicated);

    if (props.jobForApplication.userJobType === 0) {
      fetch(variables.API_URL + "User/CreateUser_Job", {
        method: "POST",
        body: formData,
      })
        .then(() => {
          RefreshJobs();
        })
        .catch((error) => console.error(error));
    } else {
      fetch(variables.API_URL + "User/UpdateJobApplication", {
        method: "POST",
        body: formData,
      })
        .then(() => {
          RefreshJobs();
        })
        .catch((error) => console.error(error));
    }
    props.setUserChooseCv(false);
  };

  /*פונקציה עזר שמופעלת אחרי שהמשתמש 
  הגיש את מועמדותו ושולחת אותו למסך המשרות שלי */
  const RefreshJobs = () => {
    fetch(
      variables.API_URL + "User/GetApplyForJobs?userID=" + props.user.userID
    )
      .then((response) => response.json())
      .then((data) => {
        props.setJobs(data);
        navigate("/MyJobs");
      })
      .catch((error) => console.log(error));
  };

  return (
    <React.Fragment>
      <h2 className="subTitle text-center mb-4">:הגשת מועמדות למשרה</h2>
      <div className="row d-flex justify-content-center mb-5 mx-0">
        <div className="card col-xl-4">
          <div className="card-body text-center">
            <h3>
              {props.userChooseCv ? (
                <span className="bodyColor">
                  {props.user.chosenCvForJob.fileName}
                </span>
              ) : (
                <React.Fragment>
                  <i
                    role="button"
                    className="bi bi-file-earmark-plus me-3 addCvText"
                    onClick={NavToCvs}
                  ></i>
                  <span className="bodyColor">:הוספת קובץ קורות חיים</span>
                </React.Fragment>
              )}
            </h3>
          </div>
        </div>
      </div>
      <h2 className="subTitle text-center mb-4">
        :קורות החיים ישלחו עם הפרטים הבאים
      </h2>
      <div className="row d-flex justify-content-center mb-5 bodyColor mx-0">
        <div className="card col-xl-3">
          <div dir="rtl" className="card-body">
            <div className="row mb-2">
              <div className="col">
                {editable ? (
                  <input
                    type="text"
                    className="form-control"
                    value={props.user.firstName}
                    onChange={FirstName_TxtChanged}
                  />
                ) : (
                  <span>שם פרטי: {props.user.firstName}</span>
                )}
              </div>
              <div className="col text-right">
                {editable ? (
                  <input
                    type="text"
                    className="form-control"
                    value={props.user.lastName}
                    onChange={LastName_TxtChanged}
                  />
                ) : (
                  <span>שם משפחה: {props.user.lastName}</span>
                )}
              </div>
            </div>
            <div className="row mb-2">
              <div className="col">
                {editable ? (
                  <input
                    type="text"
                    className="form-control"
                    value={props.user.phone}
                    onChange={Phone_TxtChanged}
                  />
                ) : (
                  <span>מספר נייד: {props.user.phone}</span>
                )}
              </div>
              <div className="col">
                {editable ? (
                  <input
                    type="text"
                    value={props.user.city.value}
                    className="form-control"
                    onChange={City_TxtChanged}
                  />
                ) : (
                  <span> עיר מגורים: {props.user.city.value}</span>
                )}
              </div>
            </div>
            <div className="row mb-3">
              <div className="col-6">
                {editable ? (
                  <input
                    type="text"
                    className="form-control"
                    value={props.user.email}
                  />
                ) : (
                  <span>אמייל: {props.user.email}</span>
                )}
              </div>
              {editable && city !== undefined && city.cityId !== 0 && (
                <div className="col-6">
                  <button
                    className="btn btn-outline-light myBtn d-block"
                    onClick={ChosenCity}
                  >
                    {city.cityName}
                  </button>
                </div>
              )}
            </div>
            <div className="row">
              <div className="col">
                <button
                  className="btn btn-outline-light myBtn"
                  onClick={EditUser}
                >
                  {editable ? "עדכן" : "עריכת פרטים"}
                </button>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div className="d-flex justify-content-center">
        <button
          className="btn btn-outline-light btn-lg myBtn fs-4"
          onClick={SendJobApplication}
        >
          הגש מועמדות
        </button>
      </div>
    </React.Fragment>
  );
};

export default JobApplication;
