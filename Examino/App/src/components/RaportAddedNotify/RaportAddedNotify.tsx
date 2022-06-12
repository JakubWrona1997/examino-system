import { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import { useSelector } from "react-redux";
import { RootState, useAppDispatch } from "../../app/store";
import { getRaports } from "../../features/raportSlice";
import * as signalR from "@microsoft/signalr";
import displayAlert from "../../utils/displayAlert";
import styles from "./RaportAddedNotify.module.scss";

interface SignalRDataViewModel {
  textMessage: string;
  fromUserId: string;
  toUserId: string;
  raportId: string;
}

const RaportAddedNotify = () => {
  const [isConnected, setIsConnected] = useState<boolean>(false);
  const [connection, setConnection] = useState<signalR.HubConnection | null>(
    null
  );
  const { user } = useSelector((state: RootState) => state.user);
  const dispatch = useAppDispatch();

  useEffect(() => {
    if (user?.role === "patient" && isConnected === false) {
      const newConnection = new signalR.HubConnectionBuilder()
        .withUrl("https://localhost:7258/hub")
        .withAutomaticReconnect()
        .build();

      setConnection(newConnection);
      setIsConnected(true);
    }
  }, [user, isConnected]);

  useEffect(() => {
    if (connection) {
      connection.start().then(() =>
        connection.on("RaportAdded", async (data: SignalRDataViewModel) => {
          if (user?._id === data.toUserId) {
            await dispatch(getRaports());
            displayAlertWithLink(data);
          }
        })
      );
    }
    return () => {
      if (connection) {
        connection.stop();
        setConnection(null);
        setIsConnected(false);
      }
    };
  }, [connection]);

  const displayAlertWithLink = (data: SignalRDataViewModel) => {
    const alertMessage = (
      <span className={styles.alertMessage}>
        {data.textMessage}
        <br />
        <Link to={`/patient/history/raport/${data.raportId}`}>
          Pokaż szczegóły
        </Link>
      </span>
    );
    displayAlert({ type: "info", message: alertMessage }, 10000);
  };

  return null;
};

export default RaportAddedNotify;
