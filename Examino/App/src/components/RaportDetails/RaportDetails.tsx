import React, { useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";
import { useSelector } from "react-redux";
import { RootState } from "../../app/store";
import { Raport } from "../../models/Raport";
import "./RaportDetails.scss";

const RaportDetails = () => {
  const [raport, setRaport] = useState<Raport>();
  const params = useParams();

  const { raports } = useSelector((state: RootState) => state.raports);

  useEffect(() => {
    setRaport(raports.find((raport) => raport.id === params.id));
  }, []);

  return (
    <React.Fragment>
      <header className="dashboard-content-header">
        Szczegóły wizyty {params.id}
      </header>
      <div className="dashboard-history-raport-details-wrapper">
        <div className="card-wrapper">
          <div className="card-content">
            <table>
              <tbody>
                <tr>
                  <th>Data wizyty</th>
                  <td>
                    {raport &&
                      new Date(raport.raportTime).toLocaleString("pl-PL")}
                  </td>
                </tr>
                <tr>
                  <th>Doktor</th>
                  <td>{raport?.doctorId}</td>
                </tr>
                <tr>
                  <th>Pacjent</th>
                  <td>{raport?.patientId}</td>
                </tr>
                <tr>
                  <th>Symptomy</th>
                  <td>{raport?.symptoms}</td>
                </tr>
                <tr>
                  <th>Badanie</th>
                  <td>{raport?.examination}</td>
                </tr>
                <tr>
                  <th>Diagnoza</th>
                  <td>{raport?.diagnosis}</td>
                </tr>
                <tr>
                  <th>Zalecenia</th>
                  <td>{raport?.recommendation}</td>
                </tr>
                <tr>
                  <th>Komentarz</th>
                  <td>{raport?.comment}</td>
                </tr>
                <tr>
                  <th>Recepta</th>
                  <td>
                    <Link
                      to={`/dashboard/history/prescription/${raport?.prescription.id}/details`}
                    >
                      {raport?.prescription.id}
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
