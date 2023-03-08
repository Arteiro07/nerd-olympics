"use client";

import { CompetitionDto } from "@/utilities/types";
import { useState } from "react";
import style from "./competitionCard.module.scss";
import { AiFillEdit, AiFillDelete } from "react-icons/ai";
import { useAuth } from "@/context/authContext";
import { deleteComp } from "@/services/compUtils";
import { useRouter } from "next/navigation";

type Props = {
	competition: CompetitionDto;
};

export default function CompetitionCard(props: Props) {
	const { user, setUser } = useAuth();
	const [isEditing, setIsediting] = useState(false);
	const router = useRouter();

	if (isEditing) {
		return <></>;
	}

	const handleDelete = async () => {
		await deleteComp(props.competition, user.token);
		alert("Competition deleted successfully");
		router.push("/competitions");
	};

	return (
		<div className={style.container}>
			<div className={style.compName}>{props.competition.name}</div>
			<div className={style.compDescrition}>
				{props.competition.description}
			</div>
			{user.userId === props.competition.userId ? (
				<div className={style.compOptions}>
					<button className={style.delete} onClick={handleDelete} type="button">
						<AiFillDelete />
					</button>
					<button
						className={style.edit}
						onClick={() => setIsediting(true)}
						type="button"
					>
						<AiFillEdit />
					</button>
				</div>
			) : (
				<></>
			)}
		</div>
	);
}
