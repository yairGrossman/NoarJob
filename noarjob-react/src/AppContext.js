import React from "react";

export const AppContext = React.createContext({
  setJobForApplication: () => {},
  setIsMyJobs: () => {},
  isMyJobs: false,
});
