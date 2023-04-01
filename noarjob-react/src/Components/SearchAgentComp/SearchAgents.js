import React from "react";
import SearchAgent from "./SearchAgent";

const SearchAgents = (props) => {
  let count = 0;
  return (
    <React.Fragment>
      {props.searchAgents.map((searchAgent) => (
        <SearchAgent key={count++} searchAgent={searchAgent} />
      ))}
      <div dir="rtl" className="row d-flex justify-content-center mb-3">
        <div className="col-12 col-md-8 col-lg-6 col-xl-8">
          <i class="bi bi-plus-circle iconStyle"></i>
        </div>
      </div>
    </React.Fragment>
  );
};

export default SearchAgents;
