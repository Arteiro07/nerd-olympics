import { CompetitionDto, CompetitionDtoInitialState } from "@/utilities/types";
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
				throw new Error("404 page not found", err);
			case 401:
				throw new Error("401 Unauthorized ", err);
			default:
				throw new Error();
		}
	}
	return [];
}

export async function getCompetition(id: number): Promise<CompetitionDto> {
	try {
		const res = await fetch(
			baseURL +
				"/competitions?" +
				new URLSearchParams({ competitionId: `${id}` }),
			{
				method: "GET",
				headers: myHeaders,
			}
		);
		console.log(res);
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
				throw new Error("404 page not found", err);
			case 401:
				throw new Error("401 Unauthorized ", err);
			default:
				throw new Error();
		}
	}
	return CompetitionDtoInitialState;
}
