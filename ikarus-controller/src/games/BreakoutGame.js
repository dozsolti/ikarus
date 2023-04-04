import React, { useContext } from "react";
import { SocketContext } from "../contexts/SocketContext";

import Joystick from "../components/Joystick";

export const BreakoutGame = () => {
    const { emitInput } = useContext(SocketContext);

    const onMove = ({ direction }) => {
        emitInput("joystick", "move", { direction, name: "movement" });
    };

    const onUp = () => {
        emitInput("joystick", "up", { name: "movement" });
    };

    return (
        <div
            style={{
                display: "flex",
                flex: 1,
                flexDirection: "row",
                justifyContent: "space-evenly",
                alignItems: "center",
            }}>
            <Joystick
                size={300}
                positionY="120%"
                positionX="70%"
                color="#08D9D6"
                lockX
                onMove={onMove}
                onUp={onUp}
            />
        </div>
    );
};
