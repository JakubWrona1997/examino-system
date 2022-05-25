import React from "react";
import { useSelector } from "react-redux";
import { RootState } from "../../app/store";
import "./PatientHistory.scss";
import RaportHistoryItem from "../common/RaportHistoryItem/RaportHistoryItem";

const PatientHistory = () => {
  const { raports } = useSelector((state: RootState) => state.raports);

  return (
    <React.Fragment>
      <header className="dashboard-content-header">Historia</header>
      <div className="dashboard-history-wrapper">
        <div className="dashboard-history-labels">
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
          <RaportHistoryItem
            key={raport.raport.id}
            raport={raport}
            index={index + 1}
          />
        ))}
      </div>
    </React.Fragment>
  );
};

export default PatientHistory;
