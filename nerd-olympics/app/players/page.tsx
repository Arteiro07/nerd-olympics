import axios from "axios";
import Player from "./Player";
import style from "./players.module.scss";
import { UserDetailed } from "../../utilities/types";

export default async function page() {
	const res = await axios.get(`https://dummyjson.com/users`);

	return (
		<div className={style.container}>
			{res.data.users.map((user: UserDetailed) => (
				<Player key={user.id} {...user} />
			))}
		</div>
	);
}
