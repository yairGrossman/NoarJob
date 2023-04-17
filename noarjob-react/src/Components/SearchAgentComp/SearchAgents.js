import React from "react";
import SearchAgent from "./SearchAgent";
import { useNavigate } from "react-router-dom";

const SearchAgents = (props) => {
  let count = 0;
  const navigate = useNavigate();

  /*פונקציה שמופעלת כאשר המשתמש רוצה להוסיף סוכן חכם ומפנה אותו
  למסך הוספת סוכן חכם */
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
          EditAgentValues={props.EditAgentValues}
          titleNameFun={props.titleNameFun}
          deleteAgent={props.deleteAgent}
          AgentSearch={props.AgentSearch}
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
