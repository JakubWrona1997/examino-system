import React, { useEffect } from "react";
import { useSelector } from "react-redux";
import { RootState, useAppDispatch } from "../../../app/store";
import { removeAlert } from "../../../features/adminSlice";
import displayAlert from "../../../utils/displayAlert";
import DoctorItem from "../../common/DoctorItem/DoctorItem";
import styles from "./DoctorsRecord.module.scss";

const DoctorsRecord = () => {
  const { doctors, alert } = useSelector((state: RootState) => state.admin);
  const dispatch = useAppDispatch();

  useEffect(() => {
    if (alert) {
      displayAlert(alert);
    }
    return () => {
      if (alert) dispatch(removeAlert());
    };
  }, [alert]);

  return (
    <React.Fragment>
      <header className={styles.header}>Doktorzy</header>
      <div className={styles.wrapper}>
        {doctors.length > 0 ? (
          <React.Fragment>
            <div className={styles.labels}>
              <table>
                <tbody>
                  <tr>
                    <th>Nr</th>
                    <th>Doktor</th>
                    <th>Pesel</th>
                    <th>Specjalizacja</th>
                  </tr>
                </tbody>
              </table>
            </div>
            {doctors.map((doctor, index) => (
              <DoctorItem key={index} doctor={doctor} index={index + 1} />
            ))}
          </React.Fragment>
        ) : (
          <div>Brak doktorów do wyświetlenia</div>
        )}
      </div>
    </React.Fragment>
  );
};

export default DoctorsRecord;
