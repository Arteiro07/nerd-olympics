import React from "react";
import Image from "next/image";
import Link from "next/link";
import { User } from "../../utilities/userTypes";
import style from "./player.module.scss";

export default function Player(user: User) {
	return (
		<>
			<div className={style.card}>
				<Link href={`/players/${user.userId}`}>
					{user.userId}, {user.name} {user.email},
				</Link>
			</div>
			<div className={style.divider} />
		</>
	);
}
