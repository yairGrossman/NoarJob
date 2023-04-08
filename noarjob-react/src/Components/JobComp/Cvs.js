import React, { useRef, useState } from "react";
import { variables } from "../../Variables";
import { useNavigate } from "react-router-dom";
import "../Styles/Cvs.css";

const Cvs = (props) => {
  const navigate = useNavigate();
  const fileInputRef = useRef(null);
  const [cvFileName, setCvFileName] = useState("");

  const ChosenCv = (event) => {
    const cv = JSON.parse(event.target.getAttribute("data-cv"));
    props.setUser((prevUser) => {
      return { ...prevUser, chosenCvForJob: cv };
    });
    alert("בחירתך נשמרה!");
    props.setUserChooseCv(true);
    navigate("/JobApplication");
  };

  const AddCv = () => {
    fileInputRef.current.click();
  };

  const CvFileName_TxtChanged = (event) => {
    setCvFileName(event.target.value);
  };

  const HandleFileSelect = (event) => {
    const file = event.target.files[0];
    const formData = new FormData();
    formData.append("file", file);
    formData.append("cvFileName", cvFileName);
    formData.append("userID", props.user.userID);
    fetch(variables.API_URL + "Cv/InsertCv", {
      method: "POST",
      body: formData,
    })
      .then((response) => response.json())
      .then((data) => {
        props.setUser((prevUser) => {
          return {
            ...prevUser,
            lstCvs: [...prevUser.lstCvs, data],
          };
        });
      })
      .catch((error) => console.error(error));
  };

  const OpenFile = (event) => {
    const filePath = event.target.getAttribute("data-filepath");
    window.open("http://localhost:5063/" + filePath);
  };

  return (
    <React.Fragment>
      {props.user.lstCvs.map((cv) => {
        return (
          <div key={cv.cvID} className="row d-flex justify-content-center mb-4">
            <div className="card col-xl-2">
              <div className="card-body">
                <h3>
                  <div className="row">
                    <i
                      data-cv={JSON.stringify({
                        cvFilePath: cv.cvFilePath,
                        cvIsActive: true,
                        cvID: cv.cvID,
                        fileName: cv.fileName,
                      })}
                      role="button"
                      className="bi bi-plus-circle addCvText col-2"
                      onClick={ChosenCv}
                    ></i>
                    <span
                      data-filepath={cv.cvFilePath}
                      role="button"
                      dir="rtl"
                      className="bodyColor col-10 fileSelected"
                      onClick={OpenFile}
                    >
                      {cv.fileName}
                    </span>
                  </div>
                </h3>
              </div>
            </div>
          </div>
        );
      })}
      <div dir="rtl" className="row d-flex justify-content-center">
        <div className="col-xl-2">
          <div className="row">
            <input
              type="text"
              className="form-control col"
              placeholder="תן שם לקובץ שאתה מוסיף"
              value={cvFileName}
              onChange={CvFileName_TxtChanged}
            />
            <i
              role="button"
              className="bi bi-plus-circle agentIconStyle col-2"
              onClick={AddCv}
            ></i>
          </div>
        </div>
        <input
          type="file"
          ref={fileInputRef}
          onChange={HandleFileSelect}
          style={{ display: "none" }}
        />
      </div>
    </React.Fragment>
  );
};

export default Cvs;
