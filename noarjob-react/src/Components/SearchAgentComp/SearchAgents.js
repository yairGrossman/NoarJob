import React from "react";
import SearchAgent from "./SearchAgent";
import { useNavigate } from "react-router-dom";

const SearchAgents = (props) => {
  let count = 0;
  const navigate = useNavigate();
  const AddAgent_Click = () => {
    props.titleNameFun("הוספת");
    navigate("/AddAgent/*");
  };

  return (
    <React.Fragment>
      {props.searchAgents.map((searchAgent) => (
        <SearchAgent
          key={count++}
          searchAgent={searchAgent}
          EditAgntValues={props.EditAgntValues}
          titleNameFun={props.titleNameFun}
          deleteAgent={props.deleteAgent}
        />
      ))}
      <div dir="rtl" className="row d-flex justify-content-center mb-3">
        <div className="col-12 col-md-8 col-lg-6 col-xl-8">
          <i
            role="button"
            className="bi bi-plus-circle agentIconStyle"
            onClick={AddAgent_Click}
          ></i>
        </div>
      </div>
    </React.Fragment>
  );
};

export default SearchAgents;
