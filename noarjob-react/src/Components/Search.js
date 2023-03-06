import React, { useState } from "react";
import Card from "./Card";
import "./Search.css";
import SearchBody from "./SearchBody";
import { variables } from "../Variables";

const Search = () => {
  const [visible, setVisible] = useState(true);
  const [categories, setCategories] = useState({ categories: [] });
  const [btnClicked, setBtnClicked] = useState(false);

  const SearchByDomainBtn_Click = () => {
    setVisible(false);
  };

  const SearchByTxtBtn_Click = () => {
    setVisible(true);
  };

  const DomainBtn_Click = () => {
    setBtnClicked(true);
    fetch(variables.API_URL + "JobCategories/GetParentJobCategories")
      .then((response) => response.json())
      .then((data) => {
        setCategories({ categories: data });
      });
  };

  return (
    <div>
      <Card cardSize={"col-xl-12"}>
        <div className="mb-5">
          <button
            id="SearchByDomainBtn"
            className="btn btn-outline-light btn-lg px-5 mx-5 myBtn"
            onClick={SearchByDomainBtn_Click}
          >
            חיפוש משרות לפי תחום
          </button>
          <button
            id="SearchByTxtBtn"
            className="btn btn-outline-light btn-lg px-5 mx-5 myBtn"
            onClick={SearchByTxtBtn_Click}
          >
            חיפוש משרות חופשי
          </button>
        </div>
        <div id="searchByTxtDiv" className={visible ? "" : "visibleFalse"}>
          <div className="row form-outline form-white mb-4">
            <a id="goJobsPageByTxtBtn" className="col-1 searchBtn">
              <i className="bi bi-search"></i>
            </a>
            <input
              dir="rtl"
              id="SearchTxt"
              type="text"
              className="form-control form-control-lg col"
              placeholder="לדוגמא: מוכר שווארמה"
            />
          </div>
        </div>
        <div
          id="searchByDomainDiv"
          className={"row " + (visible ? "visibleFalse" : "")}
        >
          <a id="goJobsPageByDomainBtn" className="col-1 searchBtn">
            <i className="bi bi-search"></i>
          </a>
          <button
            id="JobTypeBtn"
            className="btn btn-outline-light btn-lg px-5 mx-3 myBtn col"
          >
            בחירת סוג משרה
          </button>
          <button
            id="LocationBtn"
            className="btn btn-outline-light btn-lg px-5 mx-3 myBtn col"
          >
            בחירת מיקום
          </button>
          <button
            id="RoleBtn"
            className="btn btn-outline-light btn-lg px-5 mx-3 myBtn col"
          >
            בחירת תפקיד
          </button>
          <button
            id="DomainBtn"
            className="btn btn-outline-light btn-lg px-5 mx-3 myBtn col"
            onClick={DomainBtn_Click}
          >
            בחירת תחום
          </button>
        </div>
        {categories.categories.length != 0 && (
          <div className={visible ? "visibleFalse" : ""}>
            <SearchBody content={categories.categories} />
          </div>
        )}
      </Card>
    </div>
  );
};

export default Search;
