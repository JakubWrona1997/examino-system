import { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import { useSelector } from "react-redux";
import { RootState, useAppDispatch } from "../../app/store";
import { getRaports } from "../../features/raportSlice";
import * as signalR from "@microsoft/signalr";
import displayAlert from "../../utils/displayAlert";
import styles from "./Notify.module.scss";

interface SignalRDataViewModel {
  textMessage: string;
  fromUserId: string;
  toUserId: string;
  raportId: string;
}

const Notify = () => {
  const [connection, setConnection] = useState<null | signalR.HubConnection>(
    null
  );
  const { user } = useSelector((state: RootState) => state.user);
  const dispatch = useAppDispatch();

  useEffect(() => {
    if (user?.role === "patient") {
      const connect = new signalR.HubConnectionBuilder()
        .withUrl("https://localhost:7258/hub")
        .withAutomaticReconnect()
        .build();

      setConnection(connect);
    }
  }, [user]);

  useEffect(() => {
    if (connection) {
      connection.start().then(() =>
        connection.on("RaportAdded", async (data: SignalRDataViewModel) => {
          if (user?._id === data.toUserId) {
            await dispatch(getRaports());
            const Message = (
              <span className={styles.notify}>
                {data.textMessage}
                <br />
                <Link to={`/patient/history/raport/${data.raportId}`}>
                  Pokaż szczegóły
                </Link>
              </span>
            );
            displayAlert(
              {
                type: "info",
                message: Message,
              },
              10000
            );
          }
        })
      );
    }
  }, [connection]);

  return <div />;
};

export default Notify;
