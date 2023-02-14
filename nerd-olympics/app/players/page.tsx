"use client";

import Player from "./Player";
import style from "./players.module.scss";
import { getUsers } from "@/services/users";
import { useAuth } from "@/context/authContext";
import { User } from "@/utilities/userTypes";
import PlayerList from "./PlayerList";

export default function Page() {
	const { user, setUser } = useAuth();

	return <></>;
	//const res = await getUsers(user.token);
}
/*
if ("error" in res) {
	console.error(res.error);
	return (
		<h1>
			Error fetching the Users try refreshing or check the console for further
			information
		</h1>
	);
} else {
	return (
		<div className={style.container}>
			{res.map((user: User) => (
				<Player key={user.id} {...user} />
			))}
		</div>
	);
}*/
