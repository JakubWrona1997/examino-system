import React from "react";
import { useSelector } from "react-redux";
import { RootState } from "../../../app/store";
import styles from "./PatientHistory.module.scss";
import RaportItem from "../../common/RaportItem/RaportItem";

const PatientHistory = () => {
  const { raports } = useSelector((state: RootState) => state.raports);

  return (
    <React.Fragment>
      <header className={styles.header}>Historia</header>
      <div className={styles.wrapper}>
        {raports.length > 0 ? (
          <React.Fragment>
            <div className={styles.labels}>
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
              <RaportItem
                key={raport.raport.id}
                raport={raport}
                index={index + 1}
              />
            ))}
          </React.Fragment>
        ) : (
          <div>Brak historii wizyt do wyświetlenia</div>
        )}
      </div>
    </React.Fragment>
  );
};

export default PatientHistory;
