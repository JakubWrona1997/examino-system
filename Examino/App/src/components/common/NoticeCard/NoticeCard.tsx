import { FaEnvelope } from "react-icons/fa";
import styles from "./NoticeCard.module.scss";

interface Props {
  title: string;
  message: string;
}

const NoticeCard = ({ title, message }: Props) => {
  return (
    <div className={styles.wrapper}>
      <div className={styles.content}>
        <table>
          <tbody>
            <tr>
              <td>
                <FaEnvelope />
              </td>
              <td>
                <span>{title}</span>
                <span>{message}</span>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default NoticeCard;
