import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { useSelector } from "react-redux";
import { RootState } from "../../app/store";
import { Raport } from "../../models/Raport";
import "./PrescriptionDetails.scss";

const PrescriptionDetails = () => {
  const [raport, setRaport] = useState<Raport>();
  const params = useParams();

  const { raports } = useSelector((state: RootState) => state.raports);

  useEffect(() => {
    setRaport(raports.find((raport) => raport.prescription.id === params.id));
  }, []);

  return (
    <React.Fragment>
      <header className="dashboard-content-header">
        Szczegóły recepty {params.id}
      </header>
      <div className="dashboard-history-prescription-details-wrapper">
        <div className="card-wrapper">
          <div className="card-content">
            <table>
              <tbody>
                <tr>
                  <th>Data wystawienia</th>
                  <td>
                    {raport &&
                      new Date(raport.raportTime).toLocaleString("pl-PL")}
                  </td>
                </tr>
                <tr>
                  <th>Numer recepty</th>
                  <td>{raport?.prescription.id}</td>
                </tr>
                <tr>
                  <th>Wystawca</th>
                  <td>{raport?.doctorId}</td>
                </tr>
                <tr>
                  <th>Pacjent</th>
                  <td>{raport?.patientId}</td>
                </tr>
                <tr>
                  <th>Recepta</th>
                  <td>{raport?.prescription.medicines}</td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
      </div>
    </React.Fragment>
  );
};

export default PrescriptionDetails;
