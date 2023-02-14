import { CompetitionDto } from "@/utilities/types";
import { baseURL, myHeaders } from ".";

export async function getCompetitions(): Promise<CompetitionDto[]> {
	try {
		const res = await fetch(baseURL + "/competitions/all", {
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
				throw new Error();
			default:
				throw new Error();
		}
	}
	return [];
}
