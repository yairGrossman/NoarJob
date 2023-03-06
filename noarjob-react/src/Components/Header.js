import React, { useState } from "react";
import "./Header.css";
import {
  HashRouter,
  NavLink,
  Route,
  Routes,
  useNavigate,
} from "react-router-dom";
import Login from "./Login";
import Search from "./Search";
import Signup from "./Signup";

const Header = () => {
  const navigate = useNavigate();

  const MoveToLogin = () => {
    navigate("/Login");
  };

  const MoveToSignup = () => {
    navigate("/Signup");
  };

  return (
    <div>
      <div className="container">
        <header className="d-flex flex-wrap align-items-center justify-content-center justify-content-md-between py-3 mb-4 border-bottom">
          <h1 className="d-flex align-items-center col-md-3 mb-2 mb-md-0 text-decoration-none title">
            NoarJob
          </h1>

          <ul className="nav col-12 col-md-auto mb-2 justify-content-center mb-md-0">
            <li>
              <NavLink to="/" className="nav-link px-2 link-secondary">
                בית
              </NavLink>
            </li>
            <li>
              <a href="#" className="nav-link px-2 link-dark">
                Features
              </a>
            </li>
            <li>
              <a href="#" className="nav-link px-2 link-dark">
                Pricing
              </a>
            </li>
            <li>
              <a href="#" className="nav-link px-2 link-dark">
                FAQs
              </a>
            </li>
            <li>
              <a href="#" className="nav-link px-2 link-dark">
                About
              </a>
            </li>
          </ul>

          <div className="col-md-3 text-end">
            <button
              id="loginBtn"
              className="btn btn-outline-light me-3 myBtn"
              onClick={MoveToLogin}
            >
              כניסה
            </button>
            <button
              id="signupBtn"
              className="btn btn-outline-light myBtn"
              onClick={MoveToSignup}
            >
              הרשם
            </button>
          </div>
        </header>
      </div>
      <Routes>
        <Route path="/" element={<Search />} />
        <Route path="/Login" element={<Login />} />
        <Route path="/Signup" element={<Signup />} />
      </Routes>
    </div>
  );
};

export default Header;
