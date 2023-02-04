"use client";
import { authSignUp } from "@/services/auth";
import { ChangeEvent, FormEvent, SyntheticEvent, useState } from "react";
import { User } from "../../utilities/types";

export default function SignUp() {
	const [user, setUser] = useState<User>({
		name: "",
		email: "",
		password: "",
	});

	const handleSubmit = (e: FormEvent) => {
		e.preventDefault();
		console.log(user);
		authSignUp(user);
	};

	const handleChange = (event: ChangeEvent<HTMLInputElement>) =>
		setUser({ ...user, [event.target.name]: event.target.value });

	return (
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
			<button type="submit" value="Submit">
				Sign Up
			</button>
		</form>
	);
}
