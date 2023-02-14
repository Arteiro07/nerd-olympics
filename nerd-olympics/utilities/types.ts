export type UserDetailed = {
	id: number;
	firstName: string;
	lastName: string;
	age: number;
	gender: string;
	image: string;
};

export type CompetitionDto = {
	competitionId: number;
	name: string;
	description: string;
	createdDate: Date;
	userId: number;
};

export const CompetitionDtoInitialState: CompetitionDto = {
	competitionId: 0,
	name: "",
	description: "",
	createdDate: new Date(),
	userId: 0,
};
