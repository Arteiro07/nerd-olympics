"use client";
import { AuthContext } from "@/context/authContext";
import React, { useState, useContext, useEffect } from "react";
import { BiUserCircle } from "react-icons/bi";
import Dropdown from "./Dropdown";
import style from "./userLogo.module.scss";
import Image from "next/image";

export default function UserLogo() {
	const { user, setUser } = useContext(AuthContext);
	const [logout, setLogout] = useState(false);
	const [dropdown, setDropdown] = useState(false);

	useEffect(() => {
		if (user.isLoggedIn) {
			setLogout(true);
		} else {
			setLogout(false);
		}
	}, [user.isLoggedIn]);

	return (
		<div className={style.container}>
			<div className={style.logo} onClick={() => setDropdown(!dropdown)}>
				{logout ? (
					<Image
						src={`https://api.dicebear.com/5.x/bottts/svg?seed=${user.name}`}
						alt="user_logo"
						height={60}
						width={60}
					/>
				) : (
					<BiUserCircle />
				)}
			</div>
			<div>{dropdown ? <Dropdown isLoggedIn={logout} /> : <></>}</div>
		</div>
	);
}
