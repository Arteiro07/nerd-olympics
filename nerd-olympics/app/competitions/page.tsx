import { getCompetitions } from "@/services/competitions";
import { CompetitionDto } from "@/utilities/types";
import Competitions from "./Competitions";

export default async function page() {
	//get a list of competitions from the back end
	const competitions: CompetitionDto[] = await getCompetitions();

	return (
		<>
			<Competitions competitions={competitions} />
		</>
	);
}
