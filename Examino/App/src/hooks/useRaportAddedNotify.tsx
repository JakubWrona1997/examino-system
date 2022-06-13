import { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import { useSelector } from "react-redux";
import { RootState, useAppDispatch } from "../app/store";
import { getRaports } from "../features/raportSlice";
import * as signalR from "@microsoft/signalr";
import displayAlert from "../utils/displayAlert";

interface IRaportAddedNotify {
  textMessage: string;
  fromUserId: string;
  toUserId: string;
  raportId: string;
}

const useRaportAddedNotify = () => {
  const [isConnected, setIsConnected] = useState<boolean>(false);
  const [connection, setConnection] = useState<signalR.HubConnection | null>(
    null
  );

  const { user } = useSelector((state: RootState) => state.user);
  const dispatch = useAppDispatch();

  useEffect(() => {
    if (connection) {
      connection.start().then(() =>
        connection.on("RaportAdded", async (data: IRaportAddedNotify) => {
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

  const connectToRaportAddedHub = () => {
    if (!isConnected) {
      const newConnection = new signalR.HubConnectionBuilder()
        .withUrl("https://localhost:7258/hub")
        .withAutomaticReconnect()
        .build();

      setConnection(newConnection);
      setIsConnected(true);
    }
  };

  const displayAlertWithLink = (data: IRaportAddedNotify) => {
    const alertMessage = (
      <span>
        {data.textMessage}
        <br />
        <Link
          to={`/${user?.role}/history/raport/${data.raportId}`}
          style={{ color: "#0000ff", textDecoration: "underline" }}
        >
          Pokaż szczegóły
        </Link>
      </span>
    );
    displayAlert({ type: "info", message: alertMessage }, 10000);
  };

  return { connectToRaportAddedHub };
};

export default useRaportAddedNotify;
