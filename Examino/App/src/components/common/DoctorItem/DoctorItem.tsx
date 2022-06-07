import React from "react";
import { useAppDispatch } from "../../../app/store";
import { deleteDoctor } from "../../../features/adminSlice";
import { DoctorShortDetailsViewModel } from "../../../models/Users/Doctor/DoctorShortDetailsViewModel";
import { FaTrash } from "react-icons/fa";
import "./DoctorItem.scss";

interface Props {
  doctor: DoctorShortDetailsViewModel;
  index: number;
}

const DoctorItem = ({ doctor, index }: Props) => {
  const dispatch = useAppDispatch();

  return (
    <React.Fragment>
      <div className="doctor-item-wrapper">
        <div className="doctor-item-content">
          <table>
            <tbody>
              <tr>
                <td>{index}</td>
                <td>
                  {doctor.name}&nbsp;{doctor.surname}
                </td>
                <td>{doctor.pesel}</td>
                <td>{doctor.qualification}</td>
              </tr>
            </tbody>
          </table>
        </div>
        <div
          className="doctor-item-content"
          onClick={() => dispatch(deleteDoctor(doctor.id))}
        >
          <FaTrash />
        </div>
      </div>
    </React.Fragment>
  );
};

export default DoctorItem;
