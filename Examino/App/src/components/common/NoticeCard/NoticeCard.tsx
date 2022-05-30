import { FaEnvelope } from "react-icons/fa";
import "./NoticeCard.scss";

interface Props {
  title: string;
  message: string;
}

const NoticeCard = ({ title, message }: Props) => {
  return (
    <div className="notice-card-wrapper">
      <div className="notice-card-content">
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
