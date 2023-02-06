import React from "react";
import Image from "next/image";
import Link from "next/link";
import { CompetitionDto } from "../../utilities/types";
import style from "./competition.module.scss";

export default function Competition(competition: CompetitionDto) {
	const date: string = competition.createdDate.toString();

	return (
		<div className={style.competitionCard}>
			<div className={style.title}>{competition.title}</div>
			<div className={style.date}>{date}</div>
			<div className={style.description}>{competition.description}</div>
			<button className={style.button}> Info</button>
		</div>
	);
}
