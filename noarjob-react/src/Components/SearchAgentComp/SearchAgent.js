import React from "react";
import "../Styles/SearchAgent.css";
import ShowChoice from "../SearchComp/ShowChoice";
import { useNavigate } from "react-router-dom";
import { variables } from "../../Variables";

const SearchAgent = (props) => {
  const navigate = useNavigate();
  const jobCategories = Object.values(
    props.searchAgent.childCategoriesDictionary
  );
  const jobTypes = Object.values(props.searchAgent.typesDictionary);

  const EditAgent_Click = () => {
    const jobCategorieIds = Object.keys(
      props.searchAgent.childCategoriesDictionary
    );
    const jobTypesIds = Object.keys(props.searchAgent.typesDictionary);

    const contentIds = {
      searchAgentID: props.searchAgent.searchAgentID,
      domainId: props.searchAgent.parentCategoryKvp.key,
      roleIds: jobCategorieIds,
      cityId: props.searchAgent.cityKvp.key,
      typeIds: jobTypesIds,
    };

    const agentTxt = props.searchAgent.text;
    const contentNames = {
      domainName: props.searchAgent.parentCategoryKvp.value,
      roleNames: jobCategories,
      cityName: props.searchAgent.cityKvp.value,
      typeNames: jobTypes,
    };

    props.EditAgentValues(contentIds, contentNames, agentTxt);
    props.titleNameFun("עריכת");

    navigate("/AddAgent/*");
  };

  const DeleteAgent_Click = () => {
    if (window.confirm("אתה עומד למחוק את הסוכן לצמיתות. אתה בטוח?")) {
      fetch(
        variables.API_URL +
          "SearchAgent/UpdateSearchAgentActivity?searchAgentID=" +
          props.searchAgent.searchAgentID
      ).then(() => {
        props.deleteAgent((prevAgents) => {
          return prevAgents.filter(
            (searchAgent) =>
              searchAgent.searchAgentID !== props.searchAgent.searchAgentID
          );
        });
      });
    }
  };

  const Search_Click = () => {
    fetch(
      variables.API_URL +
        "SearchAgents/GetJobsBySearchAgent?searchAgentID=" +
        props.searchAgent.searchAgentID +
        "&userID=" +
        props.searchAgent.userID
    )
      .then((response) => response.json())
      .then((data) => {
        props.AgentSearch(data);
      })
      .catch((error) => console.error(error));
  };

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
              <i
                role="button"
                className="bi bi-pencil-square agentIconStyle ms-4"
                onClick={EditAgent_Click}
              ></i>
              <i
                role="button"
                className="bi bi-trash-fill agentIconStyle"
                onClick={DeleteAgent_Click}
              ></i>
              <i
                role="button"
                className="bi bi-search agentIconStyle me-4"
                onClick={Search_Click}
              ></i>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default SearchAgent;
