import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { useSelector } from "react-redux";
import { RootState } from "../../app/store";
import { RaportViewModel } from "../../models/Raports/RaportViewModel";
import styles from "./PrescriptionDetails.module.scss";

const PrescriptionDetails = () => {
  const [raport, setRaport] = useState<RaportViewModel>();
  const params = useParams();

  const { raports } = useSelector((state: RootState) => state.raports);

  useEffect(() => {
    if (raports) {
      setRaport(
        raports.find((raport) => raport.prescription?.id === params.id)
      );
    }
  }, [raports]);

  return (
    <React.Fragment>
      <header className={styles.header}>Szczegóły recepty</header>
      <div className={styles.wrapper}>
        <div className={styles.cardWrapper}>
          <div className={styles.cardContent}>
            <table>
              <tbody>
                <tr>
                  <th>Data wystawienia</th>
                  <td>
                    {raport &&
                      new Date(raport.raport.raportTime).toLocaleString(
                        "pl-PL"
                      )}
                  </td>
                </tr>
                <tr>
                  <th>Numer recepty</th>
                  <td>{raport?.prescription.id}</td>
                </tr>
                <tr>
                  <th>Wystawca</th>
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
                  <th>Leki</th>
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
