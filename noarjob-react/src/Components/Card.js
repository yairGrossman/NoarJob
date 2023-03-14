import React from "react";
import "./Styles/Card.css";

const Card = (props) => {
  return (
    <section className="vh-70 gradient-custom">
      <div className="container pb-4 pt-3 h-70">
        <div className="row d-flex justify-content-center align-items-center h-100">
          <div className={"col-12 col-md-8 col-lg-6 " + props.cardSize}>
            <div className="card myCard rounded-4">
              <div className="card-body p-5 text-center">{props.children}</div>
            </div>
          </div>
        </div>
      </div>
    </section>
  );
};

export default Card;
