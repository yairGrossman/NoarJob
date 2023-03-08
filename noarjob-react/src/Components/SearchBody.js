import React, { useRef } from "react";
import "./Search.css";
import "./SearchBody.css";

const SearchBody = (props) => {
  const contentsKey = Object.keys(props.content);
  const optionsBtnRef = useRef(null);

  const CategoryBtn_Click = (event) => {
    props.onChoose(event.target.value);
    if (props.btnClicked === "domainBtn") {
      const optionsBtn = optionsBtnRef.current.querySelectorAll(".chosenBtn");
      optionsBtn.forEach((optionBtn) => {
        optionBtn.classList.remove("chosenBtn");
        optionBtn.classList.add("myBtn");
      });
    }

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
            type="text"
            className="form-control border-0 border-bottom rounded-0 col"
            placeholder="חיפוש"
            onChange={Search_TxtChanged}
          />
        </div>
        <div className="mt-4" ref={optionsBtnRef}>
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
