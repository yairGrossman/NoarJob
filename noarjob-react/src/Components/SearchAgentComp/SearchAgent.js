import React from "react";
import "../Styles/SearchAgent.css";
import ShowChoice from "../SearchComp/ShowChoice";

const SearchAgent = (props) => {
  const jobCategories = Object.values(
    props.searchAgent.childCategoriesDictionary
  );
  const jobTypes = Object.values(props.searchAgent.typesDictionary);
  return (
    <div dir="rtl" className="row d-flex justify-content-center mb-3">
      <div className="col-12 col-md-8 col-lg-6 col-xl-8">
        <div className="card rounded-3">
          <div className="card-body py-2 d-flex align-items-center">
            <div className="col m-0 p-0">
              <ShowChoice
                isList={false}
                choices={props.searchAgent.parentCategoryKvp.value}
              />
            </div>
            <div className="col m-0 p-0">
              <ShowChoice isList={true} choices={jobCategories} />
            </div>
            <div className="col m-0 p-0">
              <ShowChoice
                isList={false}
                choices={props.searchAgent.cityKvp.value}
              />
            </div>
            <div className="col m-0 p-0">
              <ShowChoice isList={true} choices={jobTypes} />
            </div>
            <div className="col m-0 p-0">
              <ShowChoice isList={false} choices={props.searchAgent.text} />
            </div>
            <div className="d-flex align-items-center">
              <i className="bi bi-pencil-square iconStyle ms-4"></i>
              <i className="bi bi-trash-fill iconStyle"></i>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default SearchAgent;
