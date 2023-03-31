import React, { useRef, useState, useNavigate, navigate } from "react";
import Card from "./Card";
import { variables } from "../Variables";

const Login = (props) => {
  const emailRef = useRef(null);
  const passwordRef = useRef(null);
  const [user, setUser] = useState();

  const Login_Click = () => {
    const email = emailRef.current.value;
    const password = passwordRef.current.value;
    fetch(
      variables.API_URL +
        "User/UserLogin?email=" +
        email +
        "&password=" +
        password
    )
      .then((response) => response.json())
      .then((data) => {
        setUser(data);
        props.onLogin(data);
      });
  };

  return (
    <Card cardSize={"col-xl-5"}>
      <div className="mb-md-5 mt-md-4 pb-5">
        <h1 className="fw-bold mb-2 title">NoarJob</h1>
        <h2 className="fw-bold mb-5 text-uppercase subTitle">התחברות</h2>

        <div className="form-outline form-white mb-4">
          <input
            dir="rtl"
            type="email"
            className="form-control form-control-lg"
            placeholder="אמייל"
            ref={emailRef}
          />
        </div>

        <div className="form-outline form-white mb-5">
          <input
            dir="rtl"
            type="password"
            className="form-control form-control-lg"
            placeholder="סיסמה"
            ref={passwordRef}
          />
        </div>

        <button
          className="btn btn-outline-light btn-lg px-5 myBtn"
          onClick={Login_Click}
        >
          התחבר
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

export default Login;
