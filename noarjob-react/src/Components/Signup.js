import React, { useRef, useState } from "react";
import Card from "./Card";
import "./Styles/SearchBody.css";
import { variables } from "../Variables";

const Signup = (props) => {
  const [user, setUser] = useState();
  const [cityName, setCityName] = useState("");
  const [cityId, setCityId] = useState(0);
  const [chosenCity, setChosenCity] = useState([]);
  const emailRef = useRef(null);
  const passwordRef = useRef(null);
  const firstNameRef = useRef(null);
  const lastNameRef = useRef(null);
  const phoneRef = useRef(null);

  const Signup_Click = () => {
    const email = emailRef.current.value;
    const password = passwordRef.current.value;
    const firstName = firstNameRef.current.value;
    const lastName = lastNameRef.current.value;
    const phone = phoneRef.current.value;

    if (
      email !== "" &&
      password !== "" &&
      firstName !== "" &&
      lastName != "" &&
      phone !== "" &&
      chosenCity.length !== 0
    ) {
      const url = `User/CreateUser?email=${email}&userPassword=${password}&firstName=${firstName}&lastName=${lastName}&phone=${phone}&cityID=${chosenCity.chosenId}&cityName=${chosenCity.chosenName}`;
      fetch(variables.API_URL + url)
        .then((response) => response.json())
        .then((data) => {
          setUser(data);
          props.onLogin(data.firstName);
        });
    }
  };

  const Search_TxtChanged = (event) => {
    const text = event.target.value;
    if (text !== "") {
      fetch(variables.API_URL + "Cities/GetCities?text=" + text)
        .then((response) => response.json())
        .then((data) => {
          if (JSON.stringify(data) !== "{}") {
            const citiesIds = Object.keys(data);
            setCityName(data[citiesIds[0]]);
            setCityId(citiesIds[0]);
          } else {
            setCityName("");
            setCityId(0);
          }
        });
    } else {
      setCityName("");
      setCityId(0);
    }
  };

  const ChosenCity = (event) => {
    setChosenCity({ chosenId: cityId, chosenName: cityName });
    event.target.classList.add("chosenBtn");
  };

  return (
    <Card cardSize={"col-xl-5"}>
      <div className="mb-md-5 mt-md-4 pb-0">
        <h1 className="fw-bold mb-2 title">NoarJob</h1>
        <h2 className="fw-bold mb-5 text-uppercase subTitle">הרשמה</h2>

        <div className="form-outline form-white mb-3">
          <input
            dir="rtl"
            type="email"
            className="form-control form-control-lg"
            placeholder="אמייל"
            ref={emailRef}
          />
        </div>

        <div className="form-outline form-white mb-3">
          <input
            dir="rtl"
            type="password"
            className="form-control form-control-lg"
            placeholder="סיסמא"
            ref={passwordRef}
          />
        </div>

        <div className="form-outline form-white mb-3">
          <input
            dir="rtl"
            type="text"
            className="form-control form-control-lg"
            placeholder="שם פרטי"
            ref={firstNameRef}
          />
        </div>

        <div className="form-outline form-white mb-3">
          <input
            dir="rtl"
            type="text"
            className="form-control form-control-lg"
            placeholder="שם משפחה"
            ref={lastNameRef}
          />
        </div>

        <div className="form-outline form-white mb-5">
          <input
            dir="rtl"
            type="text"
            className="form-control form-control-lg"
            placeholder="טלפון"
            ref={phoneRef}
          />
        </div>

        <div className="form-outline form-white mb-2 row">
          <i className="bi bi-search col-2" style={{ fontSize: "1.5rem" }}></i>
          <input
            dir="rtl"
            type="text"
            className="form-control border-0 border-bottom rounded-2 col me-3"
            placeholder="איפה את/ה גר?"
            onChange={Search_TxtChanged}
          />
        </div>

        <div dir="rtl" className="form-outline form-white mb-5">
          {cityName.length !== 0 && (
            <button
              className="btn btn-outline-light btn-lg px-3 myBtn d-block"
              onClick={ChosenCity}
            >
              {cityName}
            </button>
          )}
        </div>

        <button
          className="btn btn-outline-light btn-lg px-5 myBtn d-block mx-auto"
          onClick={Signup_Click}
        >
          הרשם
        </button>

        <div className="d-flex justify-content-center text-center mt-4 pt-1">
          <a className="text-white">
            <i className="fab fa-facebook-f fa-lg"></i>
          </a>
          <a className="text-white">
            <i className="fab fa-twitter fa-lg mx-4 px-2"></i>
          </a>
          <a className="text-white">
            <i className="fab fa-google fa-lg"></i>
          </a>
        </div>
      </div>
    </Card>
  );
};

export default Signup;
