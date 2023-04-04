import { useState } from "react";
import socketIOClient from "socket.io-client";
const ENDPOINT = "ws://"+'192.168.241.114'+":3000";

export const useSocket = () => {
    const [socket, setSocket] = useState(null);
    const [isLoading, setIsLoading] = useState(true);
    const [isConnected, setIsConnected] = useState(false);

    const connect = () => {
        setIsLoading(true);
        const socket_ = socketIOClient(ENDPOINT, {
            path: "/server",
            query: {
                type: "controller",
            },
        });
        socket_.connect();
        socket_.on("connect", () => setIsConnected(true));
        socket_.on("disconnect", () => setIsConnected(false));
        setSocket(socket_);
        setIsLoading(false);
    };

    return {
        connect,
        isLoading,
        isConnected,
        socket,
    };
};
