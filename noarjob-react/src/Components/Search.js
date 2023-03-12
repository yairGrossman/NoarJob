import React, { useState } from "react";
import Card from "./Card";
import "./Styles/Search.css";
import SearchBody from "./SearchBody";
import { variables } from "../Variables";
import ShowChoice from "./ShowChoice";

const Search = () => {
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
  משתנה ששומר את הבחירה של המשתמש
  */
  const [contentIds, setContentIds] = useState({
    domainId: 0,
    roleIds: [],
    cityId: 0,
    typeIds: [],
  });

  const [contentNames, setContentNames] = useState({
    domainName: "",
    roleNames: [],
    cityName: "",
    typeNames: [],
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
  };

  /*
  כאשר לוחצים על הכפתור של חיפוש לפי טקסט החיפוש לפי קטגוריות נעלם
  */
  const SearchByTxtBtn_Click = () => {
    setVisible(true);
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

  const CityBtn_Click = (event) => {
    setBtnClicked(event.target.value);
    setContent({});
  };

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

  return (
    <div>
      <Card cardSize={"col-xl-12"}>
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
        <div className={visible ? "" : "visibleFalse"}>
          <div className="row form-outline form-white mb-4">
            <a className="col-1 searchBtn">
              <i className="bi bi-search"></i>
            </a>
            <input
              dir="rtl"
              type="text"
              className="form-control form-control-lg col"
              placeholder="לדוגמא: מוכר שווארמה"
            />
          </div>
        </div>
        <div className={"row " + (visible ? "visibleFalse" : "")}>
          <a className="col-1 searchBtn">
            <i className="bi bi-search"></i>
          </a>
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
            "row showChoiceMargin mt-3 mb-0 " + (visible ? "visibleFalse" : "")
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
          <div className={visible ? "visibleFalse" : ""}>
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
    </div>
  );
};

export default Search;
