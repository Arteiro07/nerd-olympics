import { CompetitionDto } from "@/utilities/types";
import { baseURL, myHeaders } from ".";

export async function newComp(
	apiCompetition: CompetitionDto,
	token: string
): Promise<CompetitionDto | void> {
	myHeaders.append("Authorization", `Bearer ${token}`);

	try {
		console.log(JSON.stringify(apiCompetition));
		const res = await fetch(baseURL + "/competitions", {
			method: "POST",
			headers: myHeaders,
			body: JSON.stringify(apiCompetition),
		});

		if (res.ok) {
			// refresh?
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

export async function deleteComp(
	apiCompetition: CompetitionDto,
	token: string
): Promise<void> {
	myHeaders.append("Authorization", `Bearer ${token}`);

	try {
		console.log(JSON.stringify(apiCompetition));
		const res = await fetch(baseURL + "/competitions", {
			method: "DELETE",
			headers: myHeaders,
			body: JSON.stringify(apiCompetition.competitionId),
		});

		if (res.ok) {
			// refresh?
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

export async function editComp(
	apiCompetition: CompetitionDto,
	token: string
): Promise<void> {}
