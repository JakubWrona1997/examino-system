import React from "react";
import { useSelector } from "react-redux";
import { Link } from "react-router-dom";
import { RootState, useAppDispatch } from "../../../app/store";
import { deleteRaport } from "../../../features/raportSlice";
import { RaportViewModel } from "../../../models/Raports/RaportViewModel";
import { FaTrash } from "react-icons/fa";
import "./RaportItem.scss";

interface Props {
  raport: RaportViewModel;
  index: number;
}

const RaportItem = ({ raport, index }: Props) => {
  const { user } = useSelector((state: RootState) => state.user);
  const dispatch = useAppDispatch();

  return (
    <React.Fragment>
      <div className="raport-history-wrapper">
        <div className="raport-history-content">
          <table>
            <tbody>
              <tr>
                <td>{index}</td>
                {user?.role === "doctor" && (
                  <td>
                    {raport.patientName}&nbsp;{raport.patientSurname}
                  </td>
                )}
                {user?.role === "patient" && (
                  <td>
                    {raport.doctorName}&nbsp;{raport.doctorSurname}
                  </td>
                )}
                <td>
                  {new Date(raport.raport.raportTime).toLocaleString("pl-PL")}
                </td>
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
                <td>
                  <Link
                    to={`/${user?.role}/history/raport/${raport.raport.id}`}
                  >
                    Pokaż szczegóły
                  </Link>
                </td>
              </tr>
            </tbody>
          </table>
        </div>
        {user?.role === "doctor" && (
          <div
            className="raport-history-content"
            onClick={() => dispatch(deleteRaport(raport.raport.id))}
          >
            <FaTrash />
          </div>
        )}
      </div>
    </React.Fragment>
  );
};

export default RaportItem;
