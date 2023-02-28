"use client";

import { CompetitionDto } from "@/utilities/types";
import Competition from "./Competition";
import { useState } from "react";
import { HiOutlineMagnifyingGlass } from "react-icons/hi2";
import { IoAddCircleOutline } from "react-icons/io5";

import style from "./competitions.module.scss";
import NewComp from "./NewComp";
import Modal from "@/components/Modal";
import { useAuth } from "@/context/authContext";

type CompetitionListProps = {
	competitions: CompetitionDto[];
};

export default function Competitions(props: CompetitionListProps) {
	const { user, setUser } = useAuth();
	const [query, setQuery] = useState("");
	const [competitions, setCompetitions] = useState(props.competitions);
	const [display, setDisplay] = useState(false);

	const handleQuery = (e: React.ChangeEvent<HTMLInputElement>) => {
		setQuery(e.target.value);
		setCompetitions((prevstate) =>
			props.competitions.filter(
				(c) =>
					c.name
						?.toLocaleLowerCase()
						.includes(e.target.value.toLocaleLowerCase()) ||
					c.description
						?.toLocaleLowerCase()
						.includes(e.target.value.toLocaleLowerCase())
			)
		);
	};

	return (
		<div className={style.container}>
			<div className={style.searchBarContainer}>
				<input
					type="text"
					placeholder="Search"
					value={query}
					onChange={handleQuery}
				/>
				<div className={style.glass}>
					<HiOutlineMagnifyingGlass />
				</div>
			</div>
			<div className={style.competitionsContainer}>
				{competitions?.map((competition: CompetitionDto) => (
					<Competition key={competition.competitionId} {...competition} />
				))}
			</div>
			{display ? (
				<Modal display={display} close={() => setDisplay(!display)}>
					<NewComp />
				</Modal>
			) : (
				<>
					{user.isLoggedIn ? (
						<IoAddCircleOutline
							className={style.addCompetition}
							onClick={() => setDisplay(!display)}
						/>
					) : (
						<></>
					)}
				</>
			)}
		</div>
	);
}
