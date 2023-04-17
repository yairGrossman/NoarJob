import React, { useRef, useState } from "react";
import { variables } from "../../Variables";
import { useNavigate } from "react-router-dom";
import "../Styles/Cvs.css";

const Cvs = (props) => {
  const navigate = useNavigate();
  //משתנה שעוזר לי לגשת לפקד פתיחת קבצים
  const fileInputRef = useRef(null);
  // משתנה ששומר את השם שנתן המשתמש לקובץ קורות החיים
  const [cvFileName, setCvFileName] = useState("");

  /* פונקציה שמופעלת כאשר משתמש בחר קורות חיים ושומרת את בחירתו */
  const ChosenCv = (event) => {
    const cv = JSON.parse(event.target.getAttribute("data-cv"));
    props.setUser((prevUser) => {
      return { ...prevUser, chosenCvForJob: cv };
    });

    props.setUserChooseCv(true);
    navigate("/JobApplication");
  };

  /*פונקציה שמופעלת כאשר משתמש לוחץ על הוספת קורות חיים 
  ואז נפתח לו סייר הקבצים שממנו הוא יכול להוסיף את קורות חייו */
  const AddCv = () => {
    fileInputRef.current.click();
  };

  /*פונקציה שמופעלת כאשר המשתמש נותן שם לקורות חייו ושומרת את 
  השם של קורות חייו */
  const CvFileName_TxtChanged = (event) => {
    setCvFileName(event.target.value);
  };

  /*פונקציה שמופעלת כאשר המשתמש בחר את קובץ קורות חייו מסייר הקבצים ושומרת את בחירתו 
  ומוסיפה את קובץ קורות חייו לתקייה בצד השרת
  ואת הדרך לקובץ בבסיס הנתונים */
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
        setCvFileName("");
      })
      .catch((error) => console.error(error));
  };

  /*פונקציה שמופעלת כאשר המשתמש רוצה לפתוח קובץ של קורות חיים
  ופותחת לו את קובץ קורות החיים */
  const OpenFile = (event) => {
    const filePath = event.target.getAttribute("data-filepath");
    window.open("http://localhost:5063/" + filePath);
  };

  /*פונקציה שמופעלת כאשר המשתמש רוצה למחוק משרה ומוחקת את המשרה שהמשתמש בחר */
  const DeleteCv = (event) => {
    if (window.confirm("אתה עומד למחוק את הקורות חיים לצמיתות")) {
      const cvId = parseInt(event.target.getAttribute("data-cvid"));

      fetch(variables.API_URL + "Cv/UpdateCvActivity?cvID=" + cvId).then(() => {
        props.setUser((prevUser) => {
          return {
            ...prevUser,
            lstCvs: prevUser.lstCvs.filter((cv) => cv.cvID !== cvId),
          };
        });
      });
    }
  };

  return (
    <React.Fragment>
      {props.user.lstCvs !== undefined &&
        props.user.lstCvs.map((cv) => {
          return (
            <div
              key={cv.cvID}
              className="row d-flex justify-content-center mb-4"
            >
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
                        className="bi bi-plus-circle addCvText col-2 px-0"
                        onClick={ChosenCv}
                      ></i>
                      <i
                        data-cvid={cv.cvID}
                        role="button"
                        className="bi bi-trash-fill agentIconStyle col-2 px-0"
                        onClick={DeleteCv}
                      ></i>
                      <span
                        data-filepath={cv.cvFilePath}
                        role="button"
                        dir="rtl"
                        className="bodyColor col-8 fileSelected"
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
