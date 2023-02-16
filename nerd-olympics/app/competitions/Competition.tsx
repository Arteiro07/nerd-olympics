import { useContext, useEffect, useState } from "react";
import Image from "next/image";
import Link from "next/link";
import { CompetitionDto } from "../../utilities/types";
import style from "./competition.module.scss";
import { AiOutlineEdit, AiOutlineDelete } from "react-icons/ai";
import { AuthContext } from "@/context/authContext";

export default function Competition(competition: CompetitionDto) {
	const { user, setUser } = useContext(AuthContext);
	const [owner, setOwner] = useState(false);

	useEffect(() => {
		if (competition.userId === user.id) setOwner(true);
	}, [user, owner, competition]);

	return (
		<div className={style.competitionCard}>
			<h2 className={style.title}>{competition.name}</h2>
			<h3 className={style.description}>{competition.description}</h3>
			<button className={style.button}> Info</button>
		</div>
	);
}
