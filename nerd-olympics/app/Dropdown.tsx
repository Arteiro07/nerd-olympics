"use client";

import { AuthContext } from "@/context/authContext";
import { User, UserLoginResponse } from "@/utilities/userTypes";
import Link from "next/link";
import { ChangeEvent, FormEvent, useContext, useEffect, useState } from "react";
import style from "./dropdown.module.scss";
import { initialState } from "@/utilities/userTypes";
import { authSignUp, authSignIn } from "@/services/auth";
import { useRouter } from "next/navigation";
import Spinner from "@/components/Spinner";

type DropdownProps = {
	isLoggedIn: boolean;
	close: () => void;
};

export default function Dropdow(props: DropdownProps) {
	const { user, setUser } = useContext(AuthContext);
	const [localUser, setLocalUser] = useState(initialState);
	const [disabled, setDisabled] = useState(false);
	const [isLoading, setIsLoading] = useState(false);

	const handleChange = (event: ChangeEvent<HTMLInputElement>) =>
		setLocalUser({ ...localUser, [event.target.name]: event.target.value });

	useEffect(() => {
		setDisabled(!localUser.email || !localUser.password);
	}, [localUser]);

	const handleSubmit = async (e: FormEvent) => {
		e.preventDefault();
		setIsLoading(true);
		const res = (await authSignIn(localUser)) as UserLoginResponse;
		setIsLoading(false);
		setUser({
			...user,
			userId: res.user.userId,
			name: res.user.name,
			email: res.user.email,
			isLoggedIn: true,
			token: res.token,
		});
		props.close();
	};

	if (props.isLoggedIn) {
		return (
			<div className={style.container}>
				<div className={style.modalOverlay} onClick={props.close} />
				<div className={style.modalContainer}>
					<button
						className={style.logout}
						onClick={() => setUser(initialState)}
					>
						Logout
					</button>
				</div>
			</div>
		);
	} else {
		return (
			<div className={style.container}>
				<div className={style.modalOverlay} onClick={props.close} />
				<div className={style.modalContainer}>
					{isLoading ? (
						<div className={style.isLoading}>
							<Spinner />
						</div>
					) : (
						<>
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
							<Link
								className={style.signup}
								href="/signup"
								onClick={() => props.close()}
							>
								Sign Up
							</Link>
						</>
					)}
				</div>
			</div>
		);
	}
}
