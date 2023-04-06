import React, { useState } from "react";
import "./Styles/Header.css";
import { NavLink, Route, Routes, useNavigate } from "react-router-dom";
import Login from "./Login";
import Search from "./SearchComp/Search";
import Signup from "./Signup";
import SearchAgents from "./SearchAgentComp/SearchAgents";
import { variables } from "../Variables";
import AddSearchAgents from "./SearchAgentComp/AddSearchAgent";
import Jobs from "./JobComp/Jobs";
import MostSoughtJob from "./MostSoughtJobComp/MostSoughtJob";

const Header = () => {
  const navigate = useNavigate();
  //משתנה שעוזר לי לדעת האם המשתמש התחבר לאתר
  const [logged, setLogged] = useState(false);
  //משתנה שלמירת השם של המשתמש
  const [user, setUser] = useState({});
  //משתנה לשמירת סוכנים חכמים
  const [searchAgents, setSearchAgents] = useState([]);
  //משתנה לשמירת הכותרת של הוסה/עריכה של סוכן חכם
  const [additAgentTitle, setAdditAgentTitle] = useState();

  //משתנה לשימרת התז של הערכים של הסוכן חכם
  const [editAgentIds, setEditAgentIds] = useState([]);
  //משתנה לשמירת השמות של הערכים של הסוכן חכם
  const [editAgentValues, setEditAgentValues] = useState([]);
  //משתנה לשימרת מילת המפתח של הסוכן החכם
  const [agentTxt, setAgentTxt] = useState("");
  //משתנה לשמירת המשרות של הוסכן החכם
  const [jobs, setJobs] = useState();

  /*פונקציה שמופעלת כאשר לוחצים על הכפתור של כניסה */
  const MoveToLogin = () => {
    navigate("/Login");
  };

  /*פונקציה שמופעלת כאשר לוחצים על הכפתור של הרשם */
  const MoveToSignup = () => {
    navigate("/Signup");
  };

  /*פונקציה שמופעלת כאשר המתמש נרשם/התחבר לאתר */
  const OnLogin = (user) => {
    setUser(user);
    setLogged(true);
    navigate("/");
  };

  /*פונקציה שמופעלת כאשר המשתמש רוצה להכנס לסוכן חכם או למשרות הכי מבוקשות
  ואם אין לו משתמש זה שולח אותו למסך ההתחברות 
  ואם הוא התחבר זה שולח אותו למסך שבחר  */
  const UserLogged = (event) => {
    if (logged) {
      fetch(
        variables.API_URL +
          "SearchAgents/GetSearchAgentsByUser?userID=" +
          user.userID
      )
        .then((response) => response.json())
        .then((data) => {
          if (
            event.target !== undefined &&
            event.target.getAttribute("data-value") === "mostSoughtJobLink"
          ) {
            if (data !== null && data.length > 0) {
              MostSoughtJobHelper(data);
            } else {
              alert("אין משרות מתאימות");
            }
          } else {
            setSearchAgents(data);
          }
        });

      if (
        event === "searchAgent" ||
        event.target.getAttribute("data-value") === "searchAgentLink"
      ) {
        navigate("/SearchAgents");
      }
    } else {
      navigate("/Login");
    }
  };

  /*פונקציה עזר שמטרתה לשים במשתנה של המשרות 
  את המשרות הכי מבוקשות של משתמשים הדומים לאותו משתמש */
  const MostSoughtJobHelper = (searchAgents) => {
    let jobCategorieIds = [];
    let jobTypesIds = [];
    let citiesIds = [];
    let userId;
    if (searchAgents.length > 0) {
      userId = searchAgents[0].userID;
    }

    for (let i = 0; i < searchAgents.length; i++) {
      jobCategorieIds.push(
        ...Object.keys(searchAgents[i].childCategoriesDictionary)
      );
      jobTypesIds.push(...Object.keys(searchAgents[i].typesDictionary));
      citiesIds.push(searchAgents[i].cityKvp.key);
    }
    fetch(variables.API_URL + "Jobs/GetTheMostSoughtJobBL", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        userID: userId,
        childCategoriesLst: jobCategorieIds,
        citiesLst: citiesIds,
        typesLst: jobTypesIds,
      }),
    })
      .then((response) => response.json())
      .then((data) => {
        setJobs(data);
        navigate("/MostSoughtJob");
      })
      .catch((error) => console.error(error));
  };

  /*פונקציה שמופעלת כאשר לוחצים על כפתור הוספת/עריכת סוכן חכם ומוסיפה לכותרת את המילה
  עריכת או הוספת */
  const AdditAgentTitle = (titleName) => {
    setAdditAgentTitle(titleName);
  };
  //פונקציה שמופעלת כאשר המשתמש לוחץ על עריכת סוכן חכם ושמה את הערכים של הסוכן במשתנים
  const EditAgentValues = (contentIds, contentNames, agentTxt) => {
    setEditAgentIds(contentIds);
    setEditAgentValues(contentNames);
    setAgentTxt(agentTxt);
  };

  const AgentSearch = (jobs) => {
    setJobs(jobs);
    navigate("/JobsAgent");
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
              <span
                data-value="searchAgentLink"
                role="button"
                className="nav-link px-2 link-dark myLink"
                onClick={UserLogged}
              >
                סוכן חכם
              </span>
            </li>
            <li>
              <span
                data-value="mostSoughtJobLink"
                role="button"
                className="nav-link px-2 link-dark myLink"
                onClick={UserLogged}
              >
                המשרות המתאימות לך
              </span>
            </li>
            <li>
              <span role="button" className="nav-link px-2 link-dark myLink">
                המשרות שלי
              </span>
            </li>
          </ul>

          <div className="col-md-3 text-end">
            {logged ? (
              <h3 dir="rtl" className="fw-bold mb-2 me-3 bodyColor">
                שלום {user.firstName}
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
        <Route
          path="*"
          element={
            <Search isntAgent={true} isEditAgent={false} userId={user.userID} />
          }
        />
        <Route
          path="/SearchAgents"
          element={
            <SearchAgents
              searchAgents={searchAgents}
              deleteAgent={setSearchAgents}
              titleNameFun={AdditAgentTitle}
              EditAgentValues={EditAgentValues}
              AgentSearch={AgentSearch}
            />
          }
        />
        <Route path="/Login" element={<Login onLogin={OnLogin} />} />
        <Route path="/Signup" element={<Signup onLogin={OnLogin} />} />
        <Route
          path="/AddAgent/*"
          element={
            <AddSearchAgents
              user={user}
              additAgent={UserLogged}
              titleName={additAgentTitle}
              editAgentIds={editAgentIds}
              editAgentValues={editAgentValues}
              agentTxt={agentTxt}
            />
          }
        />
        <Route path="/JobsAgent" element={<Jobs jobs={jobs} />} />
        <Route path="/MostSoughtJob" element={<MostSoughtJob jobs={jobs} />} />
      </Routes>
    </div>
  );
};

export default Header;
