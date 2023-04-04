import logo from "./logo.svg";
import "./App.css";
import { useCallback, useEffect } from "react";
import { useSocket } from "./hooks/useSocket";
import { SocketContext } from "./contexts/SocketContext";
import { BreakoutGame } from "./games/BreakoutGame";
import { ExampleMovementGame } from "./games/example/ExampleMovementGame";

function App() {
    const { connect, isLoading, socket } = useSocket();
    useEffect(() => {
        connect();
    }, []);

    const emitInput = useCallback(
        (type, eventType, data = null) => {
            socket.volatile.emit("input", { type, eventType, data });
        },
        [socket]
    );

    if (isLoading) return <img src={logo} className="App-logo" alt="logo" />;

    return (
        <SocketContext.Provider value={{ emitInput, socket }}>
            <div className="App">
                <BreakoutGame />
            </div>
        </SocketContext.Provider>
    );
}

export default App;
