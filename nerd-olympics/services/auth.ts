import encrypt from "@/services/encrypt";
import {
	User,
	UserSignUpResponse,
	UserLoginResponse,
} from "@/utilities/userTypes";
import { SetStateAction } from "react";
import { baseURL, myHeaders } from ".";

export async function authSignUp(
	apiUser: User
): Promise<UserSignUpResponse | void> {
	try {
		const res = await fetch(baseURL + "/users/registration", {
			method: "POST",
			headers: myHeaders,
			body: JSON.stringify({
				name: apiUser.name,
				email: apiUser.email,
				password: apiUser.password,
			}),
		});

		if (res.ok) {
			return await res.json();
		}

		if (!res.ok) {
			throw new Error("Bad response from server", {
				cause: {
					res,
				},
			});
		}
	} catch (err: any) {
		//replace any
		switch (err.cause.res?.status) {
			case 404:
				throw new Error();
			case 401:
				throw new Error();
			default:
				throw new Error();
		}
	}
}

export async function authSignIn(
	apiUser: User
): Promise<UserLoginResponse | void> {
	try {
		const res = await fetch(baseURL + "/users/authentication", {
			method: "POST",
			headers: myHeaders,
			body: JSON.stringify({
				email: apiUser.email,
				password: apiUser.password,
			}),
		});

		if (res.ok) {
			return await res.json();
		}

		if (!res.ok) {
			throw new Error("Bad response from server", {
				cause: {
					res,
				},
			});
		}
	} catch (err: any) {
		//replace any
		switch (err.cause.res?.status) {
			case 404:
				throw new Error();
			case 401:
				alert("Wrong username or password");
			default:
				throw new Error();
		}
	}
}

export async function checkUserEmail(email: string): Promise<boolean> {
	try {
		const res = await fetch(
			baseURL + "/users/validation?" + new URLSearchParams({ email: email }),
			{
				method: "GET",
				headers: myHeaders,
			}
		);
		if (res.ok) {
			// refresh?
			return true;
		}

		if (!res.ok) {
			throw new Error("Bad response from server", {
				cause: {
					res,
				},
			});
		}
	} catch (err: any) {
		//replace any
		switch (err.cause.res?.status) {
			case 404:
				throw new Error();
			case 401:
				throw new Error();
			default:
				throw new Error();
		}
	}

	return false;
}
