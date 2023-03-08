import { getCompetition } from "@/services/competitions";
import { CompetitionDto } from "@/utilities/types";
import React from "react";
import CompetitionCard from "./CompetitionCard";

export default async function page({ params }: any) {
	const competition: CompetitionDto = await getCompetition(params.competition);

	return <CompetitionCard competition={competition} />;
}
