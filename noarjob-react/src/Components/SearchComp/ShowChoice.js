import React from "react";
import "../Styles/Search.css";

const ShowChoice = (props) => {
  let keys;
  let count;
  //אם המשתמש לא בחר אל תציג לא בחירות
  if (props.choices.length === 0) {
    return;
  }

  //אם זה הבחירות זה רשימה/מערך תיצור מפתחות בשביל הmap
  if (props.isList) {
    keys = [];
    count = 0;
    for (let i = 0; i < props.choices.length; i++) {
      keys.push(i);
    }
  }

  return (
    <React.Fragment>
      {props.isList ? (
        <div className="dropdown">
          <button
            className="btn btn-outline-light btn-lg myBtn dropdown-toggle"
            type="button"
            data-bs-toggle="dropdown"
            aria-expanded="false"
          >
            {props.choices[0]}
          </button>
          <ul className="dropdown-menu">
            <li className="dropdown-item disabled">
              {props.choices.map((choice) => {
                return <p key={keys[count++]}>{choice}</p>;
              })}
            </li>
          </ul>
        </div>
      ) : (
        <h4 className="fw-bold px-5 mx-3 showChoiceColor">{props.choices}</h4>
      )}
    </React.Fragment>
  );
};

export default ShowChoice;
