import React, { useState } from "react";
import Card from "./Card";
import "./Search.css";
import SearchBody from "./SearchBody";
import { variables } from "../Variables";

const Search = () => {
  /*
   המשתנה לנראות הכפתורי בחירה(תחום תפקיד, תפקיד...) 
   וגם הנראות של כפתורי התוכן (למשל אם המשתמש בחר תחום תפקיד אז זה יציע לו את כל תחומי התפקיד)
  */
  const [visible, setVisible] = useState(true);
  /*
  משתנה לתוכן שיהיה בתוך רכיב גוף החיפוש
  */
  const [content, setContent] = useState([]);
  /*
  משתנה ששומר את הבחירה של תחום התפקיד של המשתמש
  */
  const [domainID, setDomainID] = useState(0);
  /*
  משתנה לשמירת איזה כפתור בחירה המשתמש בחר (תחום תפקיד, תפקיד...)
  */
  const [btnClicked, setBtnClicked] = useState("");

  const SearchByDomainBtn_Click = () => {
    setVisible(false);
  };

  const SearchByTxtBtn_Click = () => {
    setVisible(true);
  };

  const Choose_Click = (contentId) => {
    if (btnClicked === "domainBtn") setDomainID(contentId);
  };

  const Search_TxtChanged = (text) => {
    if (btnClicked === "domainBtn") {
      if (text !== "") {
        fetch(
          variables.API_URL +
            "JobCategories/GetParentJobCategoriesByText?text=" +
            text
        )
          .then((response) => response.json())
          .then((data) => {
            setContent(data);
          });
      } else {
        fetch(variables.API_URL + "JobCategories/GetParentJobCategories")
          .then((response) => response.json())
          .then((data) => {
            setContent(data);
          });
      }
    } else if (btnClicked === "roleBtn") {
      if (text !== "") {
        fetch(
          variables.API_URL +
            "JobCategories/GetJobCategoriesByParentIDAndByText?chosenJobCategory=" +
            domainID +
            "&text=" +
            text
        )
          .then((response) => response.json())
          .then((data) => {
            setContent(data);
          });
      } else {
        fetch(
          variables.API_URL +
            "JobCategories/GetJobCategoriesByParentID?chosenJobCategory=" +
            domainID
        )
          .then((response) => response.json())
          .then((data) => {
            setContent(data);
          });
      }
    }
  };

  const DomainBtn_Click = (event) => {
    setBtnClicked(event.target.value);
    fetch(variables.API_URL + "JobCategories/GetParentJobCategories")
      .then((response) => response.json())
      .then((data) => {
        setContent(data);
      });
  };

  const RoleBtn_Click = (event) => {
    setBtnClicked(event.target.value);
    fetch(
      variables.API_URL +
        "JobCategories/GetJobCategoriesByParentID?chosenJobCategory=" +
        domainID
    )
      .then((response) => response.json())
      .then((data) => {
        setContent(data);
      });
  };

  return (
    <div>
      <Card cardSize={"col-xl-12"}>
        <div className="mb-5">
          <button
            className="btn btn-outline-light btn-lg px-5 mx-5 myBtn"
            onClick={SearchByDomainBtn_Click}
          >
            חיפוש משרות לפי תחום
          </button>
          <button
            className="btn btn-outline-light btn-lg px-5 mx-5 myBtn"
            onClick={SearchByTxtBtn_Click}
          >
            חיפוש משרות חופשי
          </button>
        </div>
        <div className={visible ? "" : "visibleFalse"}>
          <div className="row form-outline form-white mb-4">
            <a id="goJobsPageByTxtBtn" className="col-1 searchBtn">
              <i className="bi bi-search"></i>
            </a>
            <input
              dir="rtl"
              type="text"
              className="form-control form-control-lg col"
              placeholder="לדוגמא: מוכר שווארמה"
            />
          </div>
        </div>
        <div className={"row " + (visible ? "visibleFalse" : "")}>
          <a id="goJobsPageByDomainBtn" className="col-1 searchBtn">
            <i className="bi bi-search"></i>
          </a>
          <button className="btn btn-outline-light btn-lg px-5 mx-3 myBtn col">
            בחירת סוג משרה
          </button>
          <button className="btn btn-outline-light btn-lg px-5 mx-3 myBtn col">
            בחירת מיקום
          </button>
          <button
            value="roleBtn"
            className="btn btn-outline-light btn-lg px-5 mx-3 myBtn col"
            onClick={RoleBtn_Click}
          >
            בחירת תפקיד
          </button>
          <button
            value="domainBtn"
            className="btn btn-outline-light btn-lg px-5 mx-3 myBtn col"
            onClick={DomainBtn_Click}
          >
            בחירת תחום
          </button>
        </div>
        {content.length !== 0 && (
          <div className={visible ? "visibleFalse" : ""}>
            <SearchBody
              content={content}
              onChoose={Choose_Click}
              onChangeTxt={Search_TxtChanged}
              btnClicked={btnClicked}
            />
          </div>
        )}
      </Card>
    </div>
  );
};

export default Search;
