import { DoctorShortDetailsViewModel } from "../../../models/Users/Doctor/DoctorShortDetailsViewModel";
import styles from "./DoctorItem.module.scss";

interface Props {
  doctor: DoctorShortDetailsViewModel;
  index: number;
}

const DoctorItem = ({ doctor, index }: Props) => {
  return (
    <div className={styles.wrapper}>
      <div className={styles.content}>
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
    </div>
  );
};

export default DoctorItem;
