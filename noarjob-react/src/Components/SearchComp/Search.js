import React, { Fragment, useState, useEffect } from "react";
import { Route, Routes, useNavigate } from "react-router-dom";
import Card from "../Card";
import "../Styles/Search.css";
import SearchBody from "./SearchBody";
import { variables } from "../../Variables";
import ShowChoice from "./ShowChoice";
import Jobs from "../JobComp/Jobs";

const Search = (props) => {
  const navigate = useNavigate();
  /*
  משתנה ששומר את המזהה של הבחירה של המשתמש
  */
  const [contentIds, setContentIds] = useState({
    domainId: 0,
    roleIds: [],
    cityId: 0,
    typeIds: [],
  });

  //משתנה ששומר את השם של הבחירה של המשתמש
  const [contentNames, setContentNames] = useState({
    domainName: "",
    roleNames: [],
    cityName: "",
    typeNames: [],
  });

  //משתנה ששומר את החיפוש לפי טקסט של המשתמש
  const [searchTxt, setSearchTxt] = useState("");

  useEffect(() => {
    if (props.isEditAgent) {
      setSearchTxt(props.agentTxt);

      setContentIds({
        domainId: props.editAgentIds.domainId,
        roleIds: props.editAgentIds.roleIds,
        cityId: props.editAgentIds.cityId,
        typeIds: props.editAgentIds.typeIds,
      });

      setContentNames({
        domainName: props.editAgentValues.domainName,
        roleNames: props.editAgentValues.roleNames,
        cityName: props.editAgentValues.cityName,
        typeNames: props.editAgentValues.typeNames,
      });
    }
  }, []);

  const [jobs, setJobs] = useState();

  //משתנה שעוזר לי לדעת האם המשתמש מחפש לי תחומים או לפי טקסט משרות
  const [byDomain, setByDomain] = useState(false);
  /*
   המשתנה לנראות הכפתורי בחירה(תחום תפקיד, תפקיד...) 
   וגם הנראות של כפתורי התוכן (למשל אם המשתמש בחר תחום תפקיד אז זה יציע לו את כל תחומי התפקיד)
  */
  const [visible, setVisible] = useState(true);
  /*
  משתנה לתוכן שיהיה בתוך רכיב גוף החיפוש
  */
  const [content, setContent] = useState([]);

  //משתנה ספציפי לשימרת טיפוסי המשרות אני לא משתמש בטיפוסי המשרות במשתנה content
  // כי הוא מכיל רק מערך של נתונים אחד ולעומת זאת לטיפוסי משרות יש שני מערכי נתונים
  const [typesContent, setTypesContent] = useState({
    types: [],
    subTypes: [],
  });

  /*
  משתנה לשמירת איזה כפתור בחירה המשתמש בחר (תחום תפקיד, תפקיד...)
  */
  const [btnClicked, setBtnClicked] = useState("");

  /*
  כאשר לוחצים על הכפתור של חיפוש לפי קטגוריות החיפוש לפי טקסט נעלם
  */
  const SearchByDomainBtn_Click = () => {
    setVisible(false);
    setByDomain(true);
  };

  /*
  כאשר לוחצים על הכפתור של חיפוש לפי טקסט החיפוש לפי קטגוריות נעלם
  */
  const SearchByTxtBtn_Click = () => {
    setVisible(true);
    setByDomain(false);
  };

  /*
  פונקציה שמופעלת כאשר המשתמש בוחר קטגורייה כלשהי(תחום תפקיד, תפקיד, עיר ...) 
  כאשר הוא בחר אז נשמר בחירתו על ידי המשתנה לשמירת הבחירות של המשתמש
  */
  const Choose_Click = (content) => {
    if (btnClicked === "domainBtn") {
      setContentIds((prevState) => {
        return {
          ...prevState,
          domainId: content.contentId,
          roleIds: [],
        };
      });

      setContentNames((prevState) => {
        return {
          ...prevState,
          domainName: content.contentName,
          roleNames: [],
        };
      });
    } else if (btnClicked === "roleBtn") {
      setContentIds((prevState) => {
        return {
          ...prevState,
          roleIds: [...prevState.roleIds, content.contentId],
        };
      });

      setContentNames((prevState) => {
        return {
          ...prevState,
          roleNames: [...prevState.roleNames, content.contentName],
        };
      });
    } else if (btnClicked === "cityBtn") {
      setContentIds((prevState) => {
        return {
          ...prevState,
          cityId: content.contentId,
        };
      });

      setContentNames((prevState) => {
        return {
          ...prevState,
          cityName: content.contentName,
        };
      });
    } else {
      setContentIds((prevState) => {
        return {
          ...prevState,
          typeIds: [...prevState.typeIds, content.contentId],
        };
      });

      setContentNames((prevState) => {
        return {
          ...prevState,
          typeNames: [...prevState.typeNames, content.contentName],
        };
      });
    }
  };

  /*
  פונקציה שמופעלת כאשר המתמש מחפש קטגורייה כלשהי על ידי טקסט הכוונה בקטגורייה זה תחום תפקידתפקיד וכו
  ואז היא שמה במשתנה לתוכן שיהיה בתוך רכיב גוף החיפוש 
  -את התוכן שהיא קיבלה מהJson
   */
  const Search_TxtChanged = (text) => {
    if (btnClicked === "domainBtn") {
      if (text !== "") {
        fetch(
          variables.API_URL +
            "JobCategories/GetParentJobCategoriesByText?text=" +
            text
        )
          .then((response) => response.json())
          .then((data) => {
            setContent(data);
          });
      } else {
        fetch(variables.API_URL + "JobCategories/GetParentJobCategories")
          .then((response) => response.json())
          .then((data) => {
            setContent(data);
          });
      }
    } else if (btnClicked === "roleBtn") {
      if (text !== "") {
        fetch(
          variables.API_URL +
            "JobCategories/GetJobCategoriesByParentIDAndByText?chosenJobCategory=" +
            contentIds.domainId +
            "&text=" +
            text
        )
          .then((response) => response.json())
          .then((data) => {
            setContent(data);
          });
      } else {
        fetch(
          variables.API_URL +
            "JobCategories/GetJobCategoriesByParentID?chosenJobCategory=" +
            contentIds.domainId
        )
          .then((response) => response.json())
          .then((data) => {
            setContent(data);
          });
      }
    } else if (btnClicked === "cityBtn") {
      if (text !== "") {
        fetch(variables.API_URL + "Cities/GetCities?text=" + text)
          .then((response) => response.json())
          .then((data) => {
            setContent(data);
          });
      } else {
        setContent({});
      }
    }
  };

  /*פונקציה שמופעלת כאשר המשתמש לחץ על הכפתור: תחום תפקיד
  ואז שמה את את כל תחומי התפקיד בתוך המשתנה של התוכן */
  const DomainBtn_Click = (event) => {
    setBtnClicked(event.target.value);
    fetch(variables.API_URL + "JobCategories/GetParentJobCategories")
      .then((response) => response.json())
      .then((data) => {
        setContent(data);
      });
  };

  /*פונקציה שמופעלת כאשר המשתמש לחץ על הכפתור: תפקיד
  ואז שמה את את כל התפקידים בתוך המשתנה של התוכן */
  const RoleBtn_Click = (event) => {
    setBtnClicked(event.target.value);
    fetch(
      variables.API_URL +
        "JobCategories/GetJobCategoriesByParentID?chosenJobCategory=" +
        contentIds.domainId
    )
      .then((response) => response.json())
      .then((data) => {
        setContent(data);
      });
  };

  /*
  פונקציה שמופעלת כאשר המשתמש בוחר על הכפתור לבחירת עיר
   */
  const CityBtn_Click = (event) => {
    setBtnClicked(event.target.value);
    setContent({});
  };

  /*פונקציה שמופעלת כאשר המשתמש לוחץ על הכפתור לבחירת סוגי/הקפי משרה 
  ושמה בתוך המשתנה שלמירת סוגי משרה והקפי משרה את התוכן שקיבלה
  */
  const TypeBtn_Click = (event) => {
    setBtnClicked(event.target.value);

    fetch(variables.API_URL + "JobTypes/GetAllJobTypes")
      .then((response) => response.json())
      .then((data) => {
        setTypesContent((prevState) => {
          return { ...prevState, types: data };
        });
      });

    fetch(variables.API_URL + "JobTypes/GetAllSubTypes")
      .then((response) => response.json())
      .then((data) => {
        setTypesContent((prevState) => {
          return { ...prevState, subTypes: data };
        });
      });
  };

  /*פונקציה שמופעלת כאשר המתמש לוחץ על הכפתור נקה ומאפס את אותו תחום שבו המשתמש נמצא */
  const CleanBtn_Click = () => {
    if (btnClicked === "domainBtn") {
      setContentIds((prevState) => {
        return { ...prevState, domainId: 0 };
      });

      setContentNames((prevState) => {
        return { ...prevState, domainName: "" };
      });
    } else if (btnClicked === "roleBtn") {
      setContentIds((prevState) => {
        return { ...prevState, roleIds: [] };
      });

      setContentNames((prevState) => {
        return { ...prevState, roleNames: [] };
      });
    } else if (btnClicked === "cityBtn") {
      setContentIds((prevState) => {
        return { ...prevState, cityId: 0 };
      });

      setContentNames((prevState) => {
        return { ...prevState, cityName: [] };
      });
    } else {
      setContentIds((prevState) => {
        return { ...prevState, typeIds: [] };
      });

      setContentNames((prevState) => {
        return { ...prevState, typeNames: [] };
      });
    }
  };

  /*פונקציה שמופעלת כאשר המשתמש מחפש משרה לפי טקסט ושומרת את מה שהוא רשם */
  const SearchByText_TxtChanged = (event) => {
    setSearchTxt(event.target.value);
  };

  /*פונקציה שמופעלת כאשר המשתמש מחליט לחפש משרה, לעבור למסך משרות */
  const Search_Click = () => {
    let req;
    if (byDomain) {
      req = {
        parentCategory: contentIds.domainId,
        jobCategories: contentIds.roleIds,
        jobTypes: contentIds.typeIds,
        city: contentIds.cityId,
        text: null,
        userID: -1,
      };
    } else {
      req = {
        parentCategory: 0,
        jobCategories: [],
        jobTypes: [],
        city: 0,
        text: searchTxt,
        userID: -1,
      };
    }

    fetch(variables.API_URL + "Jobs/GetJobsSearch", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(req),
    })
      .then((response) => response.json())
      .then((data) => {
        setJobs(data);
        navigate("/Jobs");
      })
      .catch((error) => console.error(error));
  };

  /*פונקציה להוספת או עדכון סוכן חכם*/
  const AdditAgent_Click = () => {
    let searchAgent = {
      searchAgentID: props.isEditAgent ? props.editAgentIds.searchAgentID : 0,
      userID: props.user.userID,
      parentCategoryKvp: {
        key: contentIds.domainId,
        value: contentNames.domainName,
      },
      childCategoriesDictionary: (() => {
        let childCategoryDic = {};
        for (let i = 0; i < contentIds.roleIds.length; i++) {
          childCategoryDic[contentIds.roleIds[i]] = contentNames.roleNames[i];
        }
        return childCategoryDic;
      })(),
      cityKvp: {
        key: contentIds.cityId,
        value: contentNames.cityName,
      },
      typesDictionary: (() => {
        let typesDic = {};
        for (let i = 0; i < contentIds.typeIds.length; i++) {
          typesDic[contentIds.typeIds[i]] = contentNames.typeNames[i];
        }
        return typesDic;
      })(),
      text: searchTxt,
    };

    if (props.isEditAgent) {
      fetch(variables.API_URL + "SearchAgent/UpdateSearchAgentValues", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(searchAgent),
      })
        .then(() => {
          props.additAgent("searchAgent");
        })
        .catch((error) => console.error(error));
    } else {
      fetch(variables.API_URL + "SearchAgent/InsertSearchAgentValues", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(searchAgent),
      })
        .then((response) => response.json())
        .then(() => {
          props.additAgent("searchAgent");
        })
        .catch((error) => console.error(error));
    }
  };

  return (
    <React.Fragment>
      <Card cardSize={"col-xl-12"}>
        {props.isntAgent && (
          <div className="mb-5">
            <button
              className="btn btn-outline-light btn-lg px-5 mx-5 myBtn"
              onClick={SearchByDomainBtn_Click}
            >
              חיפוש משרות לפי תחום
            </button>
            <button
              className="btn btn-outline-light btn-lg px-5 mx-5 myBtn"
              onClick={SearchByTxtBtn_Click}
            >
              חיפוש משרות חופשי
            </button>
          </div>
        )}
        <div className={visible ? "" : "visibleFalse"}>
          <div className="row form-outline form-white mb-4">
            {props.isntAgent ? (
              <Fragment>
                <span
                  role="button"
                  className="col-1 searchBtn"
                  onClick={Search_Click}
                >
                  <i className="bi bi-search"></i>
                </span>
                <input
                  dir="rtl"
                  type="text"
                  className="form-control form-control-lg col"
                  placeholder="לדוגמא: מוכר שווארמה"
                  onChange={SearchByText_TxtChanged}
                />
              </Fragment>
            ) : (
              <Fragment>
                <div className="col-10"></div>
                <input
                  dir="rtl"
                  type="text"
                  className="form-control form-control-lg col me-3"
                  placeholder="מילת מפתח"
                  onChange={SearchByText_TxtChanged}
                  value={searchTxt}
                />
              </Fragment>
            )}
          </div>
        </div>

        <div
          className={
            "row " + (visible && props.isntAgent ? "visibleFalse" : "")
          }
        >
          {props.isntAgent ? (
            <span
              role="button"
              className="col-1 searchBtn"
              onClick={Search_Click}
            >
              <i className="bi bi-search"></i>
            </span>
          ) : (
            <span
              role="button"
              className="col-1 searchBtn"
              onClick={AdditAgent_Click}
            >
              <i role="button" className="bi bi-plus-circle agentIconStyle"></i>
            </span>
          )}
          <button
            value="typeBtn"
            className="btn btn-outline-light btn-lg px-5 mx-3 myBtn col"
            onClick={TypeBtn_Click}
          >
            בחירת סוג משרה
          </button>
          <button
            value="cityBtn"
            className="btn btn-outline-light btn-lg px-5 mx-3 myBtn col"
            onClick={CityBtn_Click}
          >
            בחירת מיקום
          </button>
          <button
            value="roleBtn"
            className="btn btn-outline-light btn-lg px-5 mx-3 myBtn col"
            onClick={RoleBtn_Click}
          >
            בחירת תפקיד
          </button>
          <button
            value="domainBtn"
            className="btn btn-outline-light btn-lg px-5 mx-3 myBtn col"
            onClick={DomainBtn_Click}
          >
            בחירת תחום
          </button>
        </div>

        <div
          dir="rtl"
          className={
            "row showChoiceMargin mt-3 mb-0 " +
            (visible && props.isntAgent ? "visibleFalse" : "")
          }
        >
          <div className="col m-0 p-0">
            <ShowChoice isList={false} choices={contentNames.domainName} />
          </div>
          <div className="col m-0 p-0">
            <ShowChoice isList={true} choices={contentNames.roleNames} />
          </div>
          <div className="col m-0 p-0">
            <ShowChoice isList={false} choices={contentNames.cityName} />
          </div>
          <div className="col m-0 p-0">
            <ShowChoice isList={true} choices={contentNames.typeNames} />
          </div>
        </div>

        {(content.length !== 0 || typesContent.types.length !== 0) && (
          <div className={visible && props.isntAgent ? "visibleFalse" : ""}>
            <SearchBody
              content={btnClicked !== "typeBtn" ? content : typesContent}
              onChoose={Choose_Click}
              onChangeTxt={Search_TxtChanged}
              btnClicked={btnClicked}
              chosenBtns={contentIds}
              CleanBtn_Click={CleanBtn_Click}
            />
          </div>
        )}
      </Card>
      <Routes>
        {jobs !== undefined && jobs.length > 0 && (
          <Route path="/Jobs" element={<Jobs jobs={jobs} />} />
        )}
      </Routes>
    </React.Fragment>
  );
};

export default Search;
