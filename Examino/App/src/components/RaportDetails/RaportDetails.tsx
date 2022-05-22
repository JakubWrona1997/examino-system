import React from "react";
import { Link, useParams } from "react-router-dom";
import "./RaportDetails.scss";

const RaportDetails = () => {
  const params = useParams();

  return (
    <React.Fragment>
      <header className="dashboard-content-header">
        Szczegóły wizyty [{params.id}]
      </header>
      <div className="dashboard-history-raport-details-wrapper">
        <div className="card-wrapper">
          <div className="card-content">
            <table>
              <tbody>
                <tr>
                  <th>Data wizyty</th>
                  <td>[dd/mm/yyyy]</td>
                </tr>
                <tr>
                  <th>Doktor</th>
                  <td>[doctor name]</td>
                </tr>
                <tr>
                  <th>Pacjent</th>
                  <td>[patient name]</td>
                </tr>
                <tr>
                  <th>Symptomy</th>
                  <td>[symptoms]</td>
                </tr>
                <tr>
                  <th>Badanie</th>
                  <td>[examination]</td>
                </tr>
                <tr>
                  <th>Diagnoza</th>
                  <td>[diagnosis]</td>
                </tr>
                <tr>
                  <th>Zalecenia</th>
                  <td>[recommendation]</td>
                </tr>
                <tr>
                  <th>Komentarz</th>
                  <td>[comment]</td>
                </tr>
                <tr>
                  <th>Recepta</th>
                  <td>
                    <Link to={`/dashboard/history/prescription/${123}/details`}>
                      [prescription number]
                    </Link>
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

export default RaportDetails;
