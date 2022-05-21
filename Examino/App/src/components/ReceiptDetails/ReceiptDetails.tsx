import React from "react";
import { useParams } from "react-router-dom";
import "./ReceiptDetails.scss";

const ReceiptDetails = () => {
  const params = useParams();

  return (
    <React.Fragment>
      <header className="dashboard-content-header">
        Szczegóły recepty [{params.id}]
      </header>
      <div className="dashboard-history-receipt-details-wrapper">
        <div className="card-wrapper">
          <div className="card-content">
            <table>
              <tbody>
                <tr>
                  <th>Data wystawienia</th>
                  <td>[dd/mm/yyyy]</td>
                </tr>
                <tr>
                  <th>Numer recepty</th>
                  <td>[receipt number]</td>
                </tr>
                <tr>
                  <th>Wystawca</th>
                  <td>[doctor name]</td>
                </tr>
                <tr>
                  <th>Pacjent</th>
                  <td>[patient name]</td>
                </tr>
                <tr>
                  <th>Recepta</th>
                  <td>[receipt content]</td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
      </div>
    </React.Fragment>
  );
};

export default ReceiptDetails;
