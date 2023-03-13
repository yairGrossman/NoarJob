import React from "react";
import Job from "./Job";
import { useLocation } from "react-router-dom";

const Jobs = () => {
  const location = useLocation();
  const jobs = location.state?.jobs;

  return (
    <React.Fragment>
      {jobs.map((job) => {
        return (
          <Job
            key={job.jobID}
            companyTypeName={job.companyTypeName}
            employerName={job.employerName}
            numOfEmployees={job.numOfEmployees}
            phone={job.phone}
            email={job.email}
            title={job.title}
            companyName={job.companyName}
            cities={job.citiesDictionary}
            types={job.typesDictionary}
            categories={job.categoriesDictionary}
            description={job.description}
            requirements={job.requirements}
          />
        );
      })}
    </React.Fragment>
  );
};

export default Jobs;
