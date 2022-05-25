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
    setRaport(raports.find((raport) => raport.raport.id === params.id));
  }, []);

  return (
    <React.Fragment>
      <header className="dashboard-content-header">Szczegóły wizyty</header>
      <div className="dashboard-history-raport-details-wrapper">
        <div className="card-wrapper">
          <div className="card-content">
            <table>
              <tbody>
                <tr>
                  <th>Data wizyty</th>
                  <td>
                    {raport &&
                      new Date(raport.raport.raportTime).toLocaleString(
                        "pl-PL"
                      )}
                  </td>
                </tr>
                <tr>
                  <th>Doktor</th>
                  <td>
                    {raport?.doctorName}&nbsp;{raport?.doctorSurname}
                  </td>
                </tr>
                <tr>
                  <th>Pacjent</th>
                  <td>
                    {raport?.patientName}&nbsp;{raport?.patientSurname}
                  </td>
                </tr>
                <tr>
                  <th>Symptomy</th>
                  <td>{raport?.raport.symptoms}</td>
                </tr>
                <tr>
                  <th>Badanie</th>
                  <td>{raport?.raport.examination}</td>
                </tr>
                <tr>
                  <th>Diagnoza</th>
                  <td>{raport?.raport.diagnosis}</td>
                </tr>
                <tr>
                  <th>Zalecenia</th>
                  <td>{raport?.raport.recommendation}</td>
                </tr>
                <tr>
                  <th>Komentarz</th>
                  <td>{raport?.raport.comment}</td>
                </tr>
                <tr>
                  <th>Recepta</th>
                  <td>
                    <Link
                      to={`/patient/history/prescription/${raport?.prescription.id}`}
                    >
                      Pokaż receptę
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
