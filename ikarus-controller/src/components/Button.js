import React from "react";
import "./Button.css";

export const Button = ({ text, onPress }) => {
    return (
        <button className="ui-button" onPointerDown={onPress}>
            {text}
        </button>
    );
};
