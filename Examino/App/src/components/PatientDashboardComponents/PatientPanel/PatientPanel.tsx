import React from "react";
import { Link } from "react-router-dom";
import { useSelector } from "react-redux";
import { RootState } from "../../../app/store";
import styles from "./PatientPanel.module.scss";
import patient from "../../../assets/patient.svg";

const PatientPanel = () => {
  const { user } = useSelector((state: RootState) => state.user);
  const { raports } = useSelector((state: RootState) => state.raports);

  return (
    <React.Fragment>
      <header className={styles.header}>
        Witaj {user?.name.split(" ", 1)}!
      </header>
      <div className={styles.wrapper}>
        {raports.length > 0 && (
          <div className={styles.cardWrapper}>
            <header className={styles.cardHeader}>Twoja ostatnia wizyta</header>
            <div className={styles.cardContent}>
              <table>
                <tbody>
                  <tr>
                    <th>Doktor</th>
                    <td>
                      {raports[0]?.doctorName}&nbsp;{raports[0]?.doctorSurname}
                    </td>
                  </tr>
                  <tr>
                    <th>Data wizyty</th>
                    <td>
                      {new Date(raports[0]?.raport.raportTime).toLocaleString(
                        "pl-PL"
                      )}
                    </td>
                  </tr>
                  <tr className={styles.showDetails}>
                    <td>
                      <Link
                        to={`/patient/history/raport/${raports[0]?.raport.id}`}
                      >
                        Pokaż szczegóły
                      </Link>
                    </td>
                  </tr>
                </tbody>
              </table>
            </div>
          </div>
        )}
        <div className={styles.cardWrapper}>
          <header className={styles.cardHeader}>
            Umów się na następną wizytę
          </header>
          <div className={styles.cardContent}>
            <table>
              <tbody>
                <tr>
                  <td>
                    Możesz umówić się na następną wizytę przez portal bez
                    konieczności kontaktowania się z przychodnią
                  </td>
                  <td>
                    <button>Umów się</button>
                  </td>
                </tr>
              </tbody>
            </table>
            <img src={patient} alt="patient" width={150} />
          </div>
        </div>
        {raports.length > 0 && raports[0].prescription && (
          <div className={styles.cardWrapper}>
            <header className={styles.cardHeader}>Recepta</header>
            <div className={styles.cardContent}>
              <table>
                <tbody>
                  <tr>
                    <th>Numer recepty</th>
                    <td>{raports[0]?.prescription.id}</td>
                  </tr>
                  <tr className={styles.showDetails}>
                    <td>
                      <Link
                        to={`/patient/history/prescription/${raports[0]?.prescription.id}`}
                      >
                        Pokaż szczegóły
                      </Link>
                    </td>
                  </tr>
                </tbody>
              </table>
            </div>
          </div>
        )}
        <div className={styles.cardWrapper}>
          <header className={styles.cardHeader}>Skierowanie</header>
          <div className={styles.cardContent}>
            <table>
              <tbody>
                <tr>
                  <th>Numer skierowania</th>
                  <td>23494601124063422697</td>
                </tr>
                <tr className={styles.showDetails}>
                  <td>Pokaż szczegóły</td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
      </div>
    </React.Fragment>
  );
};

export default PatientPanel;
