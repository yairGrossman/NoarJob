import React from "react";
import "./Card.css";

const Card = (props) => {
  return (
    <section className="vh-100 gradient-custom">
      <div className="container py-5 h-70">
        <div className="row d-flex justify-content-center align-items-center h-100">
          <div className={"col-12 col-md-8 col-lg-6 " + props.cardSize}>
            <div className="card myCard" style={{ borderRadius: "1rem" }}>
              <div className="card-body p-5 text-center">{props.children}</div>
            </div>
          </div>
        </div>
      </div>
    </section>
  );
};

export default Card;
