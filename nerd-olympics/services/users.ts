import api from ".";
import { User } from "@/utilities/userTypes";

interface ApiError {
	error: string;
}

export async function getUsers(token: string): Promise<User[] | ApiError> {
	console.log("authorization:" + token);

	const config = {
		headers: {
			Token: token,
		},
	};
	try {
		const res = await api.get("/users/all", config);

		if (res.status === 200) {
			return res.data;
		} else {
			console.log(res.status);
			return {
				error:
					"An error occurred while making the API call trying to get all the Users in the database." +
					res.status,
			} as ApiError;
		}
	} catch (error) {
		console.error(error);
		return {
			error:
				"An error occurred while making the API call trying to get all the Users.",
		} as ApiError;
	}
}
