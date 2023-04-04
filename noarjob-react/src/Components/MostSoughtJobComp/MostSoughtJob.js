import { useState, useEffect } from "react";
import Jobs from "../JobComp/Jobs";
import { variables } from "../../Variables";

const MostSoughtJob = (props) => {
  const [mostSoughtJobs, setMostSoughtJobs] = useState([]);

  useEffect(() => {
    let searchAgents = props.searchAgents;
    let jobCategorieIds = [];
    let jobTypesIds = [];
    let citiesIds = [];
    let userId = props.searchAgents[0].userID;

    for (let i = 0; i < searchAgents.length; i++) {
      jobCategorieIds.push(
        ...Object.keys(searchAgents[i].childCategoriesDictionary)
      );
      jobTypesIds.push(...Object.keys(searchAgents[i].typesDictionary));
      citiesIds.push(searchAgents[i].cityKvp.key);
    }

    fetch(variables.API_URL + "Jobs/GetTheMostSoughtJobBL", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        userID: userId,
        childCategoriesLst: jobCategorieIds,
        citiesLst: citiesIds,
        typesLst: jobTypesIds,
      }),
    })
      .then((response) => response.json())
      .then((data) => {
        console.log(data);
        setMostSoughtJobs(data);
      })
      .catch((error) => console.error(error));
  }, [props.searchAgents]);

  return (
    <div className="row d-flex justify-content-center mb-3">
      <div className="col-12 col-md-8 col-lg-6 col-xl-8">
        <h1 className="text-center bodyColor">המשרות הכי מבוקשות</h1>
      </div>
      <Jobs jobs={mostSoughtJobs} />
    </div>
  );
};

export default MostSoughtJob;
