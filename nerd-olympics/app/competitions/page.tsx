import style from "./competitions.module.scss";
import Competition from "./Competition";
import { CompetitionDto } from "../../utilities/types";
import api from "@/services";

export default async function page() {
	//get a list of competitions from the back end
	const res = await api.get(
		`https://apim-nerd-olympics-dev.azure-api.net/competitions/all`
	);

	return (
		<div className={style.container}>
			{res.data.map((competition: CompetitionDto) => (
				<Competition key={competition.id} {...competition} />
			))}
		</div>
	);
}
