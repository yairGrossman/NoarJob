import React, { useRef, useState } from "react";
import "../Styles/JobApplication.css";
import { variables } from "../../Variables";

const JobApplication = (props) => {
  const fileInputRef = useRef(null);
  const [editable, setEditable] = useState(false);
  const [city, setCity] = useState();

  /*פונקציה שמופעלת כאשר לוחצים על הוספת קובץ
  ואז אתה יכול לבחור את הקובץ במחשב */
  const openFiles = () => {
    fileInputRef.current.click();
  };

  /*פונקציה ששומרת את קורות החיים שהמשתמש בחר */
  const handleFileSelect = (event) => {
    console.log(event.target.files);
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

  return (
    <React.Fragment>
      <h2 className="subTitle text-center mb-4">:הגשת מועמדות למשרה</h2>
      <div className="row d-flex justify-content-center mb-5">
        <div className="card col-xl-4">
          <div className="card-body text-center">
            <h3>
              <i
                role="button"
                className="bi bi-file-earmark-plus me-3 addCvText"
                onClick={openFiles}
              ></i>
              <span className="bodyColor">:הוספת קובץ קורות חיים</span>
            </h3>
            <input
              type="file"
              ref={fileInputRef}
              onChange={handleFileSelect}
              style={{ display: "none" }}
            />
          </div>
        </div>
      </div>
      <h2 className="subTitle text-center mb-4">
        :קורות החיים ישלחו עם הפרטים הבאים
      </h2>
      <div className="row d-flex justify-content-center mb-5 bodyColor">
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
    </React.Fragment>
  );
};

export default JobApplication;
