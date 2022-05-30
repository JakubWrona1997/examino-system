import React from "react";
import { useSelector } from "react-redux";
import { Link } from "react-router-dom";
import { RootState } from "../../../app/store";
import NoticeCard from "../../common/NoticeCard/NoticeCard";
import "./DoctorPanel.scss";

const DoctorPanel = () => {
  const { user } = useSelector((state: RootState) => state.user);

  return (
    <React.Fragment>
      <header className="dashboard-content-header">
        Witaj {user?.name.split(" ", 1)}!
      </header>
      <div className="dashboard-doctor-panel-wrapper">
        <div className="card-wrapper">
          <header className="card-header">Najbliższa wizyta</header>
          <div className="card-content">
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
                <tr className="show-details">
                  <td>
                    <Link to="">Pokaż szczegóły</Link>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
        <div className="card-wrapper">
          <header className="card-header">Komunikaty przychodni</header>
          <div className="card-content">
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
