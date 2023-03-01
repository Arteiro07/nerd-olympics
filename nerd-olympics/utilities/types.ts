export enum ClassificationType {
	None = 0,
	Ascending,
	Descending,
}
export enum MeasurementType {
	None = 0,
	Time,
	Repetitions,
	Points,
	Length,
}
export type CompetitionDto = {
	competitionId: number;
	name: string;
	description: string;
	createdDate: Date;
	userId: number;
	classificationType: ClassificationType;
	measurementType: MeasurementType;
};
export const CompetitionDtoInitialState: CompetitionDto = {
	competitionId: 0,
	name: "",
	description: "",
	createdDate: new Date(),
	userId: 0,
	classificationType: ClassificationType.Ascending,
	measurementType: MeasurementType.Time,
};
