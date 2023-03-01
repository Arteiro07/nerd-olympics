import React from "react";
import { CompetitionDto } from "@/utilities/types";
import Competition from "./Competition";

type CompetitionListProps = {
	competitions: CompetitionDto[];
};

export default function List(props: CompetitionListProps) {
	return (
		<>
			{props.competitions?.map((competition: CompetitionDto) => (
				<Competition key={competition.competitionId} {...competition} />
			))}
		</>
	);
}
