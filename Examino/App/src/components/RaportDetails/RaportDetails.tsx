import React, { useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";
import { useSelector } from "react-redux";
import { RootState } from "../../app/store";
import { RaportViewModel } from "../../models/Raports/RaportViewModel";
import styles from "./RaportDetails.module.scss";

const RaportDetails = () => {
  const [raport, setRaport] = useState<RaportViewModel>();
  const params = useParams();

  const { user } = useSelector((state: RootState) => state.user);
  const { raports } = useSelector((state: RootState) => state.raports);

  useEffect(() => {
    if (raports) {
      setRaport(raports.find((raport) => raport.raport.id === params.id));
    }
  }, [raports]);

  return (
    <React.Fragment>
      <header className={styles.header}>Szczegóły wizyty</header>
      <div className={styles.wrapper}>
        <div className={styles.cardWrapper}>
          <div className={styles.cardContent}>
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
                    {raport?.prescription ? (
                      <Link
                        to={`/${user?.role}/history/prescription/${raport.prescription.id}`}
                      >
                        Pokaż receptę
                      </Link>
                    ) : (
                      "-"
                    )}
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
