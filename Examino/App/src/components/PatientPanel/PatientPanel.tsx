import React from "react";
import { Link } from "react-router-dom";
import "./PatientPanel.scss";
import patient from "../../assets/patient.svg";

const PatientPanel = () => {
  return (
    <React.Fragment>
      <header className="dashboard-content-header">Witaj [user]!</header>
      <div className="dashboard-panel-wrapper">
        <div className="card-wrapper">
          <header className="card-header">Twoja ostatnia wizyta</header>
          <div className="card-content">
            <table>
              <tbody>
                <tr>
                  <th>Doktor</th>
                  <td>[doctor name]</td>
                </tr>
                <tr>
                  <th>Data wizyty</th>
                  <td>[dd/mm/yyyy]</td>
                </tr>
                <tr className="show-details">
                  <td>
                    <Link to={`/dashboard/history/raports/${123}/details`}>
                      Pokaż szczegóły
                    </Link>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
        <div className="card-wrapper">
          <header className="card-header">Umów się na następną wizytę</header>
          <div className="card-content">
            <table>
              <tbody>
                <tr>
                  <td>
                    Możesz umówić się na następną wizytę przez portal bez
                    konieczności kontaktowania się z przychodnią
                  </td>
                  <td>
                    <button>Umów się</button>
                  </td>
                </tr>
              </tbody>
            </table>
            <img src={patient} alt="patient" width={150} />
          </div>
        </div>
        <div className="card-wrapper">
          <header className="card-header">Recepta</header>
          <div className="card-content">
            <table>
              <tbody>
                <tr>
                  <th>Numer recepty</th>
                  <td>[prescription number]</td>
                </tr>
                <tr className="show-details">
                  <td>
                    <Link to={`/dashboard/history/prescription/${123}/details`}>
                      Pokaż szczegóły
                    </Link>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
        <div className="card-wrapper">
          <header className="card-header">Skierowanie</header>
          <div className="card-content">
            <table>
              <tbody>
                <tr>
                  <th>Numer skierowania</th>
                  <td>[referral number]</td>
                </tr>
                <tr className="show-details">
                  <td>Pokaż szczegóły</td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
      </div>
    </React.Fragment>
  );
};

export default PatientPanel;
