import React, { useState } from "react";
import "./Search.css";
import "./SearchBody.css";

const SearchBody = (props) => {
  const categories = props.content;
  const categoriesKey = Object.keys(categories);

  const CategoryBtn_Click = (e) => {
    console.log(e.target.value);
  };

  return (
    <div className="card contentCard float-end mt-4">
      <div className="card-body myBodyCard overflow-auto">
        <div className="row">
          <i className="bi bi-search col-2" style={{ fontSize: "1.5rem" }}></i>
          <input
            dir="rtl"
            id="searchBtnByTxt"
            type="text"
            className="form-control border-0 border-bottom rounded-0 col"
            placeholder="חיפוש"
          />
        </div>
        <div id="btnDiv" className="mt-4">
          {categoriesKey.map((category) => {
            return (
              <button
                key={category}
                value={category}
                className="btn btn-outline-light mb-2 btn-lg px-3 myBtn float-end BtnBlock"
                style={{ width: "230px" }}
                onClick={CategoryBtn_Click}
              >
                {categories[category]}
              </button>
            );
          })}
        </div>
      </div>
    </div>
  );
};

export default SearchBody;
