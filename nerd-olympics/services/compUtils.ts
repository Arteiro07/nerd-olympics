import { CompetitionDto } from "@/utilities/types";
import { CONFIG_FILES } from "next/dist/shared/lib/constants";
import { baseURL, myHeaders } from ".";

export async function newComp(
	apiCompetition: CompetitionDto,
	token: string
): Promise<CompetitionDto | void> {
	myHeaders.append("Authorization", `Bearer ${token}`);

	console.log(myHeaders.get("Ocp-Apim-Subscription-Key"));
	try {
		const res = await fetch(baseURL + "/competitions", {
			method: "POST",
			headers: myHeaders,
			body: JSON.stringify(apiCompetition),
		});

		if (res.ok) {
			// refresh?
			alert("Submited sucessfully");
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

export async function checkComp(name: string): Promise<boolean> {
	try {
		const res = await fetch(
			baseURL +
				"/competitions/validation?" +
				new URLSearchParams({ competitionName: name }),
			{
				method: "GET",
				headers: myHeaders,
			}
		);

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

	return false;
}
