import React, { FC } from "react";

interface SpinnerProps {
	size?: number;
	color?: string;
}

const Spinner: FC<SpinnerProps> = ({ size = 50, color = "#f2f2f2" }) => (
	<div
		style={{
			display: "inline-block",
			width: `${size}px`,
			height: `${size}px`,
			border: `${size / 10}px solid ${color}`,
			borderRadius: "50%",
			borderTopColor: "transparent",
			animation: "spin 1s ease-in-out infinite",
		}}
	/>
);

export default Spinner;
