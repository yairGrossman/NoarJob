import React from "react";
import "./Search.css";
import "./SearchBody.css";

const SearchBody = (props) => {
  const contentsKey = Object.keys(props.content);
  console.log(props.content);

  const CategoryBtn_Click = (event) => {
    props.onChoose(event.target.value);
    event.target.classList.remove("myBtn");
    event.target.classList.add("chosenBtn");
  };

  const Search_TxtChanged = (event) => {
    const text = event.target.value;
    props.onChangeTxt(text);
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
            onChange={Search_TxtChanged}
          />
        </div>
        <div id="btnDiv" className="mt-4">
          {contentsKey.map((contentId) => {
            return (
              <button
                key={contentId}
                value={contentId}
                className="btn btn-outline-light mb-2 btn-lg px-3 myBtn float-end BtnBlock"
                style={{ width: "230px" }}
                onClick={CategoryBtn_Click}
              >
                {props.content[contentId]}
              </button>
            );
          })}
        </div>
      </div>
    </div>
  );
};

export default SearchBody;
