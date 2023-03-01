import { User } from "@/utilities/userTypes";
import { baseURL, myHeaders } from ".";

export async function getUsers(token: string): Promise<User[]> {
	myHeaders.append("Authorization", `Bearer ${token}`);

	try {
		const res = await fetch(baseURL + "/users/all", {
			method: "GET",
			headers: myHeaders,
		});
		if (res?.ok) {
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
				return [];
			default:
				throw new Error();
		}
	}
	return [];
}
