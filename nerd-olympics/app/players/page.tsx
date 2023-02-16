"use client";

import Player from "./Player";
import style from "./players.module.scss";
import { getUsers } from "@/services/users";
import { useAuth } from "@/context/authContext";
import { User } from "@/utilities/userTypes";

export default async function Page() {
	const { user, setUser } = useAuth();
	const res = await getUsers(user.token);

	return (
		<div className={style.container}>
			{res.map((user: User) => (
				<Player key={user.id} {...user} />
			))}
		</div>
	);
}
/*


*/
