import React from "react";
import { useSelector } from "react-redux";
import { RootState } from "../../../app/store";
import "./DoctorHistory.scss";
import RaportItem from "../../common/RaportItem/RaportItem";

const DoctorHistory = () => {
  const { raports } = useSelector((state: RootState) => state.raports);

  return (
    <React.Fragment>
      <header className="dashboard-content-header">Historia</header>
      <div className="dashboard-doctor-history-wrapper">
        {raports.length > 0 ? (
          <React.Fragment>
            <div className="dashboard-doctor-history-labels">
              <table>
                <tbody>
                  <tr>
                    <th>Nr</th>
                    <th>Pacjent</th>
                    <th>Data wizyty</th>
                    <th>Recepta</th>
                  </tr>
                </tbody>
              </table>
            </div>
            {raports.map((raport, index) => (
              <RaportItem key={index} raport={raport} index={index + 1} />
            ))}
          </React.Fragment>
        ) : (
          <div>Brak historii wizyt do wyświetlenia</div>
        )}
      </div>
    </React.Fragment>
  );
};

export default DoctorHistory;
