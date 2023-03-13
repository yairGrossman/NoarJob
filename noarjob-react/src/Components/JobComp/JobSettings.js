import React from "react";

const JobSettings = (props) => {
  const optionsIds = Object.keys(props.categoryOptions);

  return (
    <div className="row mb-4" style={{ width: "55%" }}>
      <h5 className="col text-align-right my-auto">{props.categoryTitle}:</h5>
      <div className="dropdown col text-align-right">
        <button
          className="btn btn-outline-light btn-lg myBtn dropdown-toggle"
          type="button"
          data-bs-toggle="dropdown"
          aria-expanded="false"
        >
          {props.categoryBtnTxt}
        </button>
        <ul className="dropdown-menu">
          {optionsIds.map((optionId) => {
            return (
              <li key={optionId} className="dropdown-item">
                <p>{props.categoryOptions[optionId]}</p>
              </li>
            );
          })}
        </ul>
      </div>
    </div>
  );
};

export default JobSettings;
