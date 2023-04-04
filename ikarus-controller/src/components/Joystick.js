import React, { useRef, useEffect, useCallback } from "react";
import PropTypes from "prop-types";

import nipplejs from "nipplejs";

const Joystick = ({
    color = "#fff",
    size = 100,
    positionX = "50%",
    positionY = "50%",
    lockX,
    lockY,
    onMove,
    onUp,
    threshold = 0.15,
}) => {
    const container = useRef(null);
    const lastVector = useRef(null);

    const check = useCallback(
        (vector) => {
            if (!lastVector.current) {
                lastVector.current = vector;
                return true;
            }
            const dist = Math.sqrt(
                (vector.x - lastVector.current.x) ** 2 +
                    (vector.y - lastVector.current.y) ** 2
            );

            const shouldMove = dist > threshold;
            if (shouldMove) lastVector.current = vector;
            return shouldMove;
        },
        [threshold]
    );

    useEffect(() => {
        const joystick = nipplejs.create({
            zone: container.current,
            color,
            mode: "static",
            position: {
                left: positionX,
                top: positionY,
            },
            maxNumberOfNipples: 1,
            dataOnly: false,
            lockX,
            lockY,
            restOpacity: 1,
            size,
        });
        joystick.on("move", (evt, data) => {
            const { vector } = data;

            vector.x = +vector.x.toFixed(2);
            vector.y = +vector.y.toFixed(2);

            if (!check(vector)) return;
            onMove({ direction: vector });
        });
        joystick.on("end", (evt, data) => {
            onUp();
        });

        return () => {
            joystick.off("move");
            joystick.off("end");
            joystick.destroy();
        };
    }, [check, color, lockX, lockY, onUp, onMove, positionX, positionY, size]);

    return (
        <div
            ref={container}
            style={{ width: "100px", height: "100px", position: "relative" }}
        />
    );
};

Joystick.propTypes = {
    color: PropTypes.string,
    size: PropTypes.number,
    positionX: PropTypes.string,
    positionY: PropTypes.string,
    lockX: PropTypes.bool,
    lockY: PropTypes.bool,
    threshold: PropTypes.number,
    onUp: PropTypes.func.isRequired,
};

export default Joystick;
