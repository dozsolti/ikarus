import React, { useContext, useEffect } from "react";
import { SocketContext } from "../../contexts/SocketContext";

import Joystick from "../../components/Joystick";
import { Button } from "../../components/Button";

export const ExampleMovementGame = () => {
    const { emitInput } = useContext(SocketContext);

    useEffect(() => {
        /*const x = setInterval(() => {
            emitInput("joystick", "move", {
                name: "movement",
                direction: { x: 0.1, y: 0 },
            });
        }, 600);
        return () => {
            clearInterval(x);
        };*/
    }, []);
    const onMovementMove = ({ direction }) => {
        emitInput("joystick", "move", { name: "movement", direction });
    };

    const onMovementUp = () => {
        emitInput("joystick", "up", { name: "movement" });
    };
    const onCameraMove = ({ direction }) => {
        emitInput("joystick", "move", { name: "camera", direction });
    };

    const onCameraUp = () => {
        emitInput("joystick", "up", { name: "camera" });
    };

    const Jump = () => {
        emitInput("button", "down", { name: "jump" });
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
            {/* <Joystick
                color="#08D9D6"
                onMove={onMovementMove}
                onUp={onMovementUp}
            />
            <Joystick
                color="#FF2E63"
                lockX
                onMove={onCameraMove}
                onUp={onCameraUp}
            /> */}
            <Button text="Shoot!" onPress={Jump} />
        </div>
    );
};
