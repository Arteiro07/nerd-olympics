import { User } from "@/utilities/userTypes";
import React from "react";

type PlayerListProps = {
	user: User;
};

export default async function PlayerList(props: PlayerListProps) {
	return <div>PlayerList</div>;

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
