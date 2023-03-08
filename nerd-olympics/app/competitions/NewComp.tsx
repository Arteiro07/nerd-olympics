import style from "./newComp.module.scss";
import { useState, useEffect, ChangeEvent, FormEvent } from "react";
import { useAuth } from "@/context/authContext";
import {
	CompetitionDto,
	CompetitionDtoInitialState,
	MeasurementType,
	ClassificationType,
} from "@/utilities/types";
import Competition from "./Competition";
import { checkComp, newComp } from "@/services/compUtils";
import {
	TiArrowDownOutline,
	TiArrowDownThick,
	TiArrowUpOutline,
	TiArrowUpThick,
} from "react-icons/ti";

export default function NewComp() {
	const { user, setUser } = useAuth();
	const [localComp, setLocalComp] = useState<CompetitionDto>(
		CompetitionDtoInitialState
	);
	const [disabled, setDisabled] = useState(false);
	const [Ascending, setAscending] = useState(false);
	const [inUse, setInUse] = useState(false);

	useEffect(() => {
		setDisabled(!localComp?.name || !localComp.description || inUse);
	}, [localComp, inUse]);

	const handleBlur = async () => {
		if (localComp.name !== "") {
			setInUse(await checkComp(localComp.name));
		}
	};
	const handleFocus = () => {
		setInUse(false);
	};

	const handleChange = (event: ChangeEvent<HTMLInputElement>) => {
		setLocalComp({ ...localComp, [event.target.name]: event.target.value });
	};
	const handleSelectChange = (event: ChangeEvent<HTMLSelectElement>) => {
		setLocalComp({
			...localComp,
			[event.target.name]: parseInt(event.target.value),
		});
	};

	const handleSubmit = async (e: FormEvent) => {
		e.preventDefault();
		setLocalComp({ ...localComp, userId: user.userId });

		const comp = await newComp(localComp, user.token);
		console.log(comp);
	};

	return (
		<div className={style.container}>
			<h1>New Competition</h1>
			<h3>Mock Competition</h3>
			<Competition {...localComp} />
			<form onSubmit={handleSubmit}>
				<input
					autoFocus
					type="text"
					placeholder="Name"
					name="name"
					value={localComp.name}
					onChange={handleChange}
					onBlur={handleBlur}
					required
					onFocus={handleFocus}
				/>
				{inUse ? (
					<div className={style.inUse}>Name already in use</div>
				) : (
					<div className={style.inUse}></div>
				)}
				<input
					type="text"
					placeholder="Description"
					name="description"
					value={localComp.description}
					onChange={handleChange}
					required
				/>
				<div className={style.classificationType}>
					Classifcation Type:
					{Ascending ? (
						<>
							<div>
								<TiArrowUpOutline
									className={style.arrow}
									onClick={() => {
										setAscending(!Ascending);
										setLocalComp({
											...localComp,
											classificationType: ClassificationType.Ascending,
										});
									}}
								/>
							</div>
							<div>
								<TiArrowDownThick />
							</div>
						</>
					) : (
						<>
							<div>
								<TiArrowUpThick />
							</div>
							<div>
								<TiArrowDownOutline
									className={style.arrow}
									onClick={() => {
										setAscending(!Ascending);
										setLocalComp({
											...localComp,
											classificationType: ClassificationType.Descending,
										});
									}}
								/>
							</div>
						</>
					)}
				</div>
				<div>Classification Type: </div>
				<select
					onChange={(e) => {
						handleSelectChange(e);
					}}
					value={localComp.measurementType}
					name="measurementType"
					className={style.selectMeasurement}
				>
					<option value={MeasurementType.Time}>Length </option>
					<option value={MeasurementType.Repetitions}>Points</option>
					<option value={MeasurementType.Points}>Reception</option>
					<option value={MeasurementType.Length}>Time</option>
				</select>
				<input
					className={disabled ? style.disabled : style.submit}
					disabled={disabled}
					type="submit"
					value="Submit"
				/>
			</form>
		</div>
	);
}
