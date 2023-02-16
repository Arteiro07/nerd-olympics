import style from "./newComp.module.scss";
import { useState, useEffect, ChangeEvent, FormEvent } from "react";
import { useAuth } from "@/context/authContext";
import { CompetitionDto, CompetitionDtoInitialState } from "@/utilities/types";
import Competition from "./Competition";
import { newComp } from "@/services/compUtils";

export default function NewComp() {
	const { user, setUser } = useAuth();
	const [localComp, setLocalComp] = useState<CompetitionDto>(
		CompetitionDtoInitialState
	);
	const [disabled, setDisabled] = useState(false);

	useEffect(() => {
		setDisabled(!localComp?.name || !localComp.description);
	}, [localComp]);

	const handleChange = (event: ChangeEvent<HTMLInputElement>) =>
		setLocalComp({ ...localComp, [event.target.name]: event.target.value });

	const handleSubmit = async (e: FormEvent) => {
		e.preventDefault();
		setLocalComp({ ...localComp, userId: user.id });
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
					type="text"
					placeholder="Name"
					name="name"
					value={localComp.name}
					onChange={handleChange}
					required
				/>
				<input
					type="text"
					placeholder="Description"
					name="description"
					value={localComp.description}
					onChange={handleChange}
					required
				/>
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
