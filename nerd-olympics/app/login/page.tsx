"use client";

import { AuthContext } from "@/context/authContext";
import { authSignIn } from "@/services/auth";
import { initialState, UserLoginResponse } from "@/utilities/userTypes";
import Link from "next/link";
import { useRouter } from "next/navigation";
import React, {
	ChangeEvent,
	useContext,
	useState,
	FC,
	useEffect,
	FormEvent,
} from "react";
import style from "./login.module.scss";

const Login: FC = () => {
	const { user, setUser } = useContext(AuthContext);
	const [localUser, setLocalUser] = useState(initialState);
	const [disabled, setDisabled] = useState(false);
	const router = useRouter();
	const handleChange = (event: ChangeEvent<HTMLInputElement>) =>
		setLocalUser({ ...localUser, [event.target.name]: event.target.value });

	useEffect(() => {
		setDisabled(!localUser.email || !localUser.password);
	}, [localUser]);

	const handleSubmit = async (e: FormEvent) => {
		e.preventDefault();
		const res = (await authSignIn(localUser)) as UserLoginResponse;

		setUser({
			...user,
			userId: res.user.userId,
			name: res.user.name,
			email: res.user.email,
			isLoggedIn: true,
			token: res.token,
		});
		router.push("/");
	};

	return (
		<div className={style.container}>
			<form onSubmit={handleSubmit}>
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
					value="Login"
				/>
			</form>
			<Link className={style.signup} href="/signup">
				Sign Up
			</Link>
		</div>
	);
};

export default Login;
