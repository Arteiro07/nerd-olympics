import { CompetitionDto } from "@/utilities/types";
import { FC } from "react";
import style from "./competition.module.scss";

type Props = {
	competition: CompetitionDto;
};

export default function CompetitionCard(props: Props) {
	return (
		<div className={style.container}>
			<div className={style.compName}>{props.competition.name}</div>
			<div className={style.compDescrition}>
				{props.competition.description}
			</div>
			<div className={style.compDate}>
				{/*props.competition.createdDate.toLocaleDateString()*/}
			</div>
		</div>
	);
}
