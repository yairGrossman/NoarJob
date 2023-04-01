import React from "react";
import Search from "../SearchComp/Search";

const AddSearchAgents = (props) => {
  return (
    <React.Fragment>
      <div className="row d-flex justify-content-center mb-3">
        <div className="col-12 col-md-8 col-lg-6 col-xl-8">
          <h1 className="text-center bodyColor">הוספת סוכן חכם</h1>
        </div>
      </div>
      <Search isntAgent={false} user={props.user} addAgent={props.addAgent} />
    </React.Fragment>
  );
};

export default AddSearchAgents;
