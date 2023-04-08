import Jobs from "../JobComp/Jobs";

const MostSoughtJob = (props) => {
  return (
    <div className="row d-flex justify-content-center mb-3">
      <div className="col-12 col-md-8 col-lg-6 col-xl-8">
        <h1 className="text-center bodyColor">המשרות הכי מבוקשות</h1>
      </div>
      {props.jobs !== undefined && (
        <Jobs jobs={props.jobs} setJobs={props.setJobs} userId={props.userId} />
      )}
    </div>
  );
};

export default MostSoughtJob;
