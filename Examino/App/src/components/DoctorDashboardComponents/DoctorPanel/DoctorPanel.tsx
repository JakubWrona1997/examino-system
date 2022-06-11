import React from "react";
import { useSelector } from "react-redux";
import { Link } from "react-router-dom";
import { RootState } from "../../../app/store";
import NoticeCard from "../../common/NoticeCard/NoticeCard";
import styles from "./DoctorPanel.module.scss";

const DoctorPanel = () => {
  const { user } = useSelector((state: RootState) => state.user);

  return (
    <React.Fragment>
      <header className={styles.header}>
        Witaj {user?.name.split(" ", 1)}!
      </header>
      <div className={styles.wrapper}>
        <div className={styles.cardWrapper}>
          <header className={styles.cardHeader}>Najbliższa wizyta</header>
          <div className={styles.cardContent}>
            <table>
              <tbody>
                <tr>
                  <th>Pacjent</th>
                  <td>Jan Kowalski</td>
                </tr>
                <tr>
                  <th>Data wizyty</th>
                  <td>30.05.2022 11:54:00</td>
                </tr>
                <tr className={styles.showDetails}>
                  <td>
                    <Link to="">Pokaż szczegóły</Link>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
        <div className={styles.cardWrapper}>
          <header className={styles.cardHeader}>Komunikaty przychodni</header>
          <div className={styles.cardContent}>
            <NoticeCard
              title="Sekretariat"
              message="Prosimy o składanie wniosków o dofinansowanie do 20 maja."
            />
            <NoticeCard
              title="Kadry"
              message="Prosimy o składanie wniosków o dofinansowanie do 20 maja."
            />
            <Link to="">Pokaż więcej</Link>
          </div>
        </div>
      </div>
    </React.Fragment>
  );
};

export default DoctorPanel;
