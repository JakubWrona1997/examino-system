import React from "react";
import { Link } from "react-router-dom";
import "./PatientDashboardHistory.scss";

const PatientDashboardHistory = () => {
  return (
    <React.Fragment>
      <header className="dashboard-content-header">Historia</header>
      <div className="dashboard-history-wrapper">
        <ul className="card-labels">
          <li>Nr</li>
          <li>Doktor</li>
          <li>Data wizyty</li>
          <li>Recepta</li>
        </ul>
        <div className="card-wrapper">
          <ul className="card-content">
            <li>[index]</li>
            <li>[doctor name]</li>
            <li>[dd/mm/yyyy]</li>
            <li>
              <Link to={`/TODO`}>[receipt number]</Link>
            </li>
            <li>
              <Link to={`/TODO`}>Pokaż szczegóły</Link>
            </li>
          </ul>
        </div>
      </div>
    </React.Fragment>
  );
};

export default PatientDashboardHistory;
