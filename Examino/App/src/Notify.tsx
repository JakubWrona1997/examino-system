import { useState, useEffect } from "react";
import * as signalR from "@microsoft/signalr";

const Notify = () => {
  const [connection, setConnection] = useState<null | signalR.HubConnection>(
    null
  );

  useEffect(() => {
    const connect = new signalR.HubConnectionBuilder()
      .withUrl("https://localhost:7258/hub")
      .withAutomaticReconnect()
      .build();

    setConnection(connect);
  }, []);

  useEffect(() => {
    if (connection) {
      connection
        .start()
        .then(() =>
          connection.on("Added", (data) => {
            console.log(data);
          })
        )
        .catch((error) => console.log(error));
    }
  }, [connection]);

  return <div />;
};

export default Notify;
