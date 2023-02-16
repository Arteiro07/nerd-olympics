"use client";

import { CompetitionDto } from "@/utilities/types";
import Competition from "./Competition";
import { useState } from "react";
import { HiOutlineMagnifyingGlass } from "react-icons/hi2";
import { IoAddCircleOutline } from "react-icons/io5";

import style from "./competitions.module.scss";
import NewComp from "./NewComp";

type CompetitionListProps = {
	competitions: CompetitionDto[];
};

export default function Competitions(props: CompetitionListProps) {
	const [query, setQuery] = useState("");
	const [competitions, setCompetitions] = useState(props.competitions);
	const [newCompDisplay, setNewCompDisplay] = useState(false);

	const handleQuery = (e: React.ChangeEvent<HTMLInputElement>) => {
		setQuery(e.target.value);

		setCompetitions((prevstate) =>
			props.competitions.filter(
				(c) => c.name?.includes(query) || c.description?.includes(query)
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
			<IoAddCircleOutline
				className={style.addCompetition}
				onClick={() => setNewCompDisplay(!newCompDisplay)}
			/>
			{newCompDisplay ? (
				<div className={style.newCompContainer}>
					<NewComp />
				</div>
			) : (
				<></>
			)}
		</div>
	);
}
/*
onClick={(e) => {
	setNewCompDisplay(!newCompDisplay);
}}
*/

/*
const refundDetailsRef = useRef<HTMLDivElement>(null) 
const refundStatus = salesOrder.refundError ? 'REFUNDED_STATUS_ERROR' : salesOrder.refundStatus  
useEffect(() => {    
	const dismissComments = (event: MouseEvent) => {      
		if (isOpened && refundDetailsRef.current && !refundDetailsRef.current.contains(event.target as unknown as Node))        
			setIsOpened(false)
	    }
		document.addEventListener('mousedown', dismissComments)
		return () => {      document.removeEventListener('mousedown', dismissComments)    }  
}, [refundDetailsRef, isOpened])

*/
