import React from "react";

const JobSettings = (props) => {
  /*משתנה ששומר את השמות של הקטגוריות
  זה יכול להיות תחום תפקיד, תפקידים וכולי*/
  const options = Object.values(props.categoryOptions);
  //משתנה ששומר את אורך המערך של שמות הקטגוריות
  const optionsLength = options.length;
  //משתנה ששומר את הקטגורייה הראשונה במערך
  const optionTitle = options[0];

  options.shift();
  let keys = [];
  let count = 0;
  for (let i = 0; i < options.length; i++) {
    keys.push(i);
  }

  return (
    <React.Fragment>
      <div className="row mb-3" style={{ width: "55%" }}>
        <h5 className="col text-align-right my-auto">{props.categoryTitle}:</h5>
        {optionsLength > 1 ? (
          <div className="dropdown col text-align-right">
            <button
              className="btn btn-outline-light btn-lg myBtn dropdown-toggle"
              type="button"
              data-bs-toggle="dropdown"
              aria-expanded="false"
            >
              {optionTitle}
            </button>
            <ul className="dropdown-menu">
              {options.map((option) => {
                return (
                  <li key={keys[count++]} className="dropdown-item disabled">
                    <p>{option}</p>
                  </li>
                );
              })}
            </ul>
          </div>
        ) : (
          <h4 className="col fw-bold px-0 mx-3 showChoiceColor text-align-right">
            {optionTitle}
          </h4>
        )}
      </div>
    </React.Fragment>
  );
};

export default JobSettings;
