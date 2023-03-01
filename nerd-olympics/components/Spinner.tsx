import React, { FC } from "react";
import style from "./spinner.module.scss";

const Spinner: FC = () => (
	<div className={style.spinner}>
		<div></div>
		<div></div>
		<div></div>
		<div></div>
		<div></div>
		<div></div>
		<div></div>
		<div></div>
		<div></div>
		<div></div>
		<div></div>
		<div></div>
	</div>
);

export default Spinner;
