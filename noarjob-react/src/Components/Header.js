import React, { useState } from "react";
import "./Styles/Header.css";
import { NavLink, Route, Routes, useNavigate } from "react-router-dom";
import Login from "./Login";
import Search from "./SearchComp/Search";
import Signup from "./Signup";
import SearchAgents from "./SearchAgentComp/SearchAgents";

const Header = () => {
  const navigate = useNavigate();
  //משתנה שעוזר לי לדעת האם המשתמש התחבר לאתר
  const [logged, setLogged] = useState(false);
  //משתנה שלמירת השם של המשתמש
  const [userName, setUserName] = useState("");

  /*פונקציה שמופעלת כאשר לוחצים על הכפתור של כניסה */
  const MoveToLogin = () => {
    navigate("/Login");
  };

  /*פונקציה שמופעלת כאשר לוחצים על הכפתור של הרשם */
  const MoveToSignup = () => {
    navigate("/Signup");
  };

  /*פונקציה שמופעלת כאשר המתמש נרשם/התחבר לאתר */
  const OnLogin = (pUserName) => {
    setUserName(pUserName);
    setLogged(true);
    navigate("/");
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
              <NavLink
                to="/SearchAgents"
                className="nav-link px-2 link-dark myLink"
              >
                סוכן חכם
              </NavLink>
            </li>
            <li>
              <a href="#" className="nav-link px-2 link-dark myLink">
                המשרות המתאימות לך
              </a>
            </li>
            <li>
              <a href="#" className="nav-link px-2 link-dark myLink">
                הגדרות
              </a>
            </li>
          </ul>

          <div className="col-md-3 text-end">
            {logged ? (
              <h3 dir="rtl" className="fw-bold mb-2 me-3 userName">
                שלום {userName}
              </h3>
            ) : (
              <div>
                <button
                  className="btn btn-outline-light me-3 myBtn"
                  onClick={MoveToLogin}
                >
                  כניסה
                </button>
                <button
                  className="btn btn-outline-light myBtn"
                  onClick={MoveToSignup}
                >
                  הרשם
                </button>
              </div>
            )}
          </div>
        </header>
      </div>
      <Routes>
        <Route path="*" element={<Search />} />
        <Route path="/SearchAgents" element={<SearchAgents />} />
        <Route path="/Login" element={<Login onLogin={OnLogin} />} />
        <Route path="/Signup" element={<Signup onLogin={OnLogin} />} />
      </Routes>
    </div>
  );
};

export default Header;
