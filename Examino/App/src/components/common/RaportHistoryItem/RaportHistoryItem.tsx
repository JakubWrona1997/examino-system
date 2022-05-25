import React from "react";
import { Link } from "react-router-dom";
import { Raport } from "../../../models/Raport";
import "./RaportHistoryItem.scss";

interface Props {
  raport: Raport;
  index: number;
}

const RaportHistoryItem = ({ raport, index }: Props) => {
  return (
    <React.Fragment>
      <div className="raport-history-wrapper">
        <div className="raport-history-content">
          <table>
            <tbody>
              <tr>
                <td>{index}</td>
                <td>
                  {raport.doctorName}&nbsp;{raport.doctorSurname}
                </td>
                <td>
                  {new Date(raport.raport.raportTime).toLocaleString("pl-PL")}
                </td>
                <td>
                  <Link to={`prescription/${raport.prescription.id}/details`}>
                    {raport.prescriptionCode}
                  </Link>
                </td>
                <td>
                  <Link to={`raports/${raport.raport.id}/details`}>
                    Pokaż szczegóły
                  </Link>
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
    </React.Fragment>
  );
};

export default RaportHistoryItem;
