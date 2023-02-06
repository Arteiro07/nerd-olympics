"use client";
import { authSignUp } from "@/services/auth";
import { ChangeEvent, FormEvent, useEffect, useState } from "react";
import { User } from "../../utilities/types";
import style from "./signup.module.scss";

export default function SignUp() {
	const [user, setUser] = useState<User>({
		name: "",
		email: "",
		password: "",
	});
	const [disabled, setDisabled] = useState(false);
	useEffect(() => {
		setDisabled(!user.email || !user.password || !user.name);
	}, [user]);

	const handleSubmit = (e: FormEvent) => {
		e.preventDefault();
		console.log(user);
		authSignUp(user);
	};

	const handleChange = (event: ChangeEvent<HTMLInputElement>) =>
		setUser({ ...user, [event.target.name]: event.target.value });

	return (
		<div className={style.container}>
			<form onSubmit={handleSubmit}>
				<h1>Sign Up</h1>
				<input
					type="text"
					placeholder="Name"
					name="name"
					value={user.name}
					onChange={handleChange}
					required
				/>
				<input
					type="email"
					placeholder="Email"
					name="email"
					value={user.email}
					onChange={handleChange}
					required
				/>
				<input
					type="password"
					placeholder="Password"
					name="password"
					value={user.password}
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
