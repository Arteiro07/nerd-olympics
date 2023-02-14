"use client";

import { useAuth } from "@/context/authContext";
import { authSignUp } from "@/services/auth";
import { ChangeEvent, FormEvent, useContext, useEffect, useState } from "react";
import {
	User,
	initialState,
	UserSignUpResponse,
} from "../../utilities/userTypes";
import style from "./signup.module.scss";

export default function SignUp() {
	const { user, setUser } = useAuth();
	const [localUser, setLocalUser] = useState<User>(initialState);
	const [disabled, setDisabled] = useState(false);

	useEffect(() => {
		setDisabled(!localUser.email || !localUser.password || !localUser.name);
	}, [localUser]);

	const handleChange = (event: ChangeEvent<HTMLInputElement>) =>
		setLocalUser({ ...localUser, [event.target.name]: event.target.value });

	const handleSubmit = (e: FormEvent) => {
		e.preventDefault();
		signUp(localUser);
	};

	const signUp = async (apiUser: User) => {
		const res = (await authSignUp(apiUser)) as UserSignUpResponse;

		setUser({
			...user,
			userId: res.createdUser.userId,
			name: res.createdUser.name,
			email: res.createdUser.email,
			isLoggedIn: true,
			token: res.token,
		});
	};

	return (
		<div className={style.container}>
			<form onSubmit={handleSubmit}>
				<h1>Sign Up</h1>
				<input
					type="text"
					placeholder="Name"
					name="name"
					value={localUser.name}
					onChange={handleChange}
					required
				/>
				<input
					type="email"
					placeholder="Email"
					name="email"
					value={localUser.email}
					onChange={handleChange}
					required
				/>
				<input
					type="password"
					placeholder="Password"
					name="password"
					value={localUser.password}
					onChange={handleChange}
					required
				/>
				<input
					className={disabled ? style.disabled : style.submit}
					disabled={disabled}
					type="submit"
					value="Submit"
				/>
			</form>
		</div>
	);
}
