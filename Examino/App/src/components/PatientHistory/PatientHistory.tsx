import React from "react";
import { Link } from "react-router-dom";
import { useSelector } from "react-redux";
import { RootState } from "../../app/store";
import "./PatientHistory.scss";

const PatientHistory = () => {
  const { raports } = useSelector((state: RootState) => state.raports);

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
        {raports.map((raport, index) => (
          <div key={index} className="card-wrapper">
            <div className="card-content">
              <table>
                <tbody>
                  <tr>
                    <td>{index}</td>
                    <td>{raport.doctorId}</td>
                    <td>
                      {new Date(raport.raportTime).toLocaleString("pl-PL")}
                    </td>
                    <td>
                      <Link
                        to={`prescription/${raport.prescription.id}/details`}
                      >
                        {raport.prescription.id}
                      </Link>
                    </td>
                    <td>
                      <Link to={`raports/${raport.id}/details`}>
                        Pokaż szczegóły
                      </Link>
                    </td>
                  </tr>
                </tbody>
              </table>
            </div>
          </div>
        ))}
      </div>
    </React.Fragment>
  );
};

export default PatientHistory;
