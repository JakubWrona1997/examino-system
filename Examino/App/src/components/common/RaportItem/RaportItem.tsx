import React from "react";
import { Link } from "react-router-dom";
import { RaportViewModel } from "../../../models/Raports/RaportViewModel";
import "./RaportItem.scss";

interface Props {
  raport: RaportViewModel;
  index: number;
}

const RaportItem = ({ raport, index }: Props) => {
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
                  <Link
                    to={`/patient/history/prescription/${raport.prescription.id}`}
                  >
                    Pokaż receptę
                  </Link>
                </td>
                <td>
                  <Link to={`/patient/history/raport/${raport.raport.id}`}>
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

export default RaportItem;