import React from "react";
import SearchAgent from "./SearchAgent";

const SearchAgents = (props) => {
  let count = 0;
  return (
    <React.Fragment>
      {props.searchAgents.map((searchAgent) => (
        <SearchAgent key={count++} searchAgent={searchAgent} />
      ))}
    </React.Fragment>
  );
};

export default SearchAgents;
