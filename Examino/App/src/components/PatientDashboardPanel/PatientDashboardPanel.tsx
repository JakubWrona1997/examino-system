import React from "react";
import "./PatientDashboardPanel.scss";

const PatientDashboardPanel = () => {
  return (
    <React.Fragment>
      <header className="dashboard-content-header">Witaj [user]!</header>
      <div className="dashboard-panel-wrapper">
        <div className="card-wrapper">
          <header className="card-header">Twoja ostatnia wizyta</header>
          <div className="card-content">[content]</div>
        </div>
        <div className="card-wrapper">
          <header className="card-header">Umów się na następną wizytę</header>
          <div className="card-content">[content]</div>
        </div>
        <div className="card-wrapper">
          <header className="card-header">Recepta</header>
          <div className="card-content">[content]</div>
        </div>
        <div className="card-wrapper">
          <header className="card-header">Skierowanie</header>
          <div className="card-content">[content]</div>
        </div>
      </div>
    </React.Fragment>
  );
};

export default PatientDashboardPanel;
