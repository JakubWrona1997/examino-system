import React from "react";
import { Link } from "react-router-dom";
import "./PatientDashboardHistory.scss";

const PatientDashboardHistory = () => {
  return (
    <React.Fragment>
      <header className="dashboard-content-header">Historia</header>
      <div className="dashboard-history-wrapper">
        <div className="card-labels">
          <table>
            <tbody>
              <tr>
                <th>Nr</th>
                <th>Doktor</th>
                <th>Data wizyty</th>
                <th>Recepta</th>
              </tr>
            </tbody>
          </table>
        </div>
        <div className="card-wrapper">
          <div className="card-content">
            <table>
              <tbody>
                <tr>
                  <td>[index]</td>
                  <td>[doctor name]</td>
                  <td>[dd/mm/yyyy]</td>
                  <td>
                    <Link to={`TODO`}>[receipt number]</Link>
                  </td>
                  <td>
                    <Link to={`TODO`}>Pokaż szczegóły</Link>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
      </div>
    </React.Fragment>
  );
};

export default PatientDashboardHistory;
