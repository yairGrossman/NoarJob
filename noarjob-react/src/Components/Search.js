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
  משתנה ששומר את הבחירה של המשתמש
  */
  const [contentIds, setContentIds] = useState({
    domainID: 0,
    roleIds: [],
    cityIds: [],
    typeIds: [],
  });
  /*
  משתנה לשמירת איזה כפתור בחירה המשתמש בחר (תחום תפקיד, תפקיד...)
  */
  const [btnClicked, setBtnClicked] = useState("");

  /*
  כאשר לוחצים על הכפתור של חיפוש לפי קטגוריות החיפוש לפי טקסט נעלם
  */
  const SearchByDomainBtn_Click = () => {
    setVisible(false);
  };

  /*
  כאשר לוחצים על הכפתור של חיפוש לפי טקסט החיפוש לפי קטגוריות נעלם
  */
  const SearchByTxtBtn_Click = () => {
    setVisible(true);
  };

  /*
  פונקציה שמופעלת כאשר המשתמש בוחר קטגורייה כלשהי(תחום תפקיד, תפקיד, עיר ...) 
  כאשר הוא בחר אז נשמר בחירתו על ידי המשתנה לשמירת הבחירות של המשתמש
  */
  const Choose_Click = (contentId) => {
    if (btnClicked === "domainBtn") {
      setContentIds((prevState) => {
        return {
          ...prevState,
          domainID: contentId,
        };
      });
    } else if (btnClicked === "roleBtn") {
      setContentIds((prevState) => {
        return {
          ...prevState,
          roleIds: [...prevState.roleIds, contentId],
        };
      });
    }
  };

  /*
  פונקציה שמופעלת כאשר המתמש מחפש קטגורייה כלשהי על ידי טקסט הכוונה בקטגורייה זה תחום תפקידתפקיד וכו
  ואז היא שמה במשתנה לתוכן שיהיה בתוך רכיב גוף החיפוש 
  -את התוכן שהיא קיבלה מהJson
   */
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
            contentIds.domainID +
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
            contentIds.domainID
        )
          .then((response) => response.json())
          .then((data) => {
            setContent(data);
          });
      }
    }
  };

  /*פונקציה שמופעלת כאשר המשתמש לחץ על הכפתור: תחום תפקיד
  ואז שמה את את כל תחומי התפקיד בתוך המשתנה של התוכן */
  const DomainBtn_Click = (event) => {
    setContentIds((prevState) => {
      return { ...prevState, roleIds: [] };
    });
    setBtnClicked(event.target.value);
    fetch(variables.API_URL + "JobCategories/GetParentJobCategories")
      .then((response) => response.json())
      .then((data) => {
        setContent(data);
      });
  };

  /*פונקציה שמופעלת כאשר המשתמש לחץ על הכפתור: תפקיד
  ואז שמה את את כל התפקידים בתוך המשתנה של התוכן */
  const RoleBtn_Click = (event) => {
    setBtnClicked(event.target.value);
    fetch(
      variables.API_URL +
        "JobCategories/GetJobCategoriesByParentID?chosenJobCategory=" +
        contentIds.domainID
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
            <a className="col-1 searchBtn">
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
          <a className="col-1 searchBtn">
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
              chosenBtns={contentIds}
            />
          </div>
        )}
      </Card>
    </div>
  );
};

export default Search;
