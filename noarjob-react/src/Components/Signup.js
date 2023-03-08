import React from "react";
import Card from "./Card";

const Signup = () => {
  return (
    <Card cardSize={"col-xl-5"}>
      <div className="mb-md-5 mt-md-4 pb-0">
        <h1 className="fw-bold mb-2 title">NoarJob</h1>
        <h2 className="fw-bold mb-5 text-uppercase subTitle">הרשמה</h2>

        <div className="form-outline form-white mb-3">
          <input
            type="email"
            className="form-control form-control-lg"
            placeholder="Email"
          />
        </div>

        <div className="form-outline form-white mb-3">
          <input
            type="password"
            className="form-control form-control-lg"
            placeholder="Password"
          />
        </div>

        <div className="form-outline form-white mb-3">
          <input
            type="text"
            className="form-control form-control-lg"
            placeholder="First name"
          />
        </div>

        <div className="form-outline form-white mb-3">
          <input
            type="text"
            className="form-control form-control-lg"
            placeholder="Last name"
          />
        </div>

        <div className="form-outline form-white mb-5">
          <input
            type="text"
            className="form-control form-control-lg"
            placeholder="Phone"
          />
        </div>

        <button className="btn btn-outline-light btn-lg px-5 myBtn">
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
