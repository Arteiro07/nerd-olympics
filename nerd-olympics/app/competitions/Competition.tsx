import React from "react";
import Image from "next/image";
import Link from "next/link";
import { CompetitionDto } from "../../utilities/types";
import style from "./competition.module.scss";

export default function Competition(competition: CompetitionDto) {
	return (
		<>
			{competition.title} {competition.id} {competition.createdDate}{" "}
			{competition.description}
		</>
	);
}
