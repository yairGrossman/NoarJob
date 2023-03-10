import React, { useState } from "react";
import "./Search.css";
import "./SearchBody.css";
import "./Types.css";

const Types = (props) => {
  const [flipArrow, setFlipArrow] = useState(false);

  const ChooseBtn_Click = (event) => {
    props.ChooseBtn_Click(event);
  };

  const FlipArrow = () => {
    if (flipArrow) {
      setFlipArrow(false);
    } else {
      setFlipArrow(true);
    }
  };

  return (
    <div>
      <button
        dir="rtl"
        className="btn bg-white float-end dropdownBtn mb-2"
        type="button"
        data-bs-toggle="collapse"
        data-bs-target={"#" + props.collapseId}
        aria-expanded="false"
        onClick={FlipArrow}
      >
        <p className="float-end">{props.typeName}</p>
        <i
          className={
            flipArrow
              ? "bi bi-caret-down-fill float-start flipArrow"
              : "bi bi-caret-down-fill float-start"
          }
        ></i>
      </button>
      <div className="collapse float-end" id={props.collapseId}>
        {props.typeIds.map((contentId) => {
          return (
            <button
              key={contentId}
              value={contentId}
              className={props.ChosenBtns(contentId) + " mt-1"}
              style={{ width: "230px" }}
              onClick={ChooseBtn_Click}
            >
              {props.types[contentId]}
            </button>
          );
        })}
      </div>
    </div>
  );
};

export default Types;
