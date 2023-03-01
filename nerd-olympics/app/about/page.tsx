import Spinner from "@/components/Spinner";
import Image from "next/image";
import about_img from "../../public/hotpot.png";
import style from "./about.module.scss";

export default function page() {
	return (
		<div className={style.container}>
			<h1>About</h1>
			<div>
				Nerd olympics is a website where a group of friends compete over a
				series of inane challenges to see who&apos;s the best human among them.
			</div>
			<Image
				className={style.image}
				src={about_img}
				alt="about_img"
				width={300}
			/>
		</div>
	);
}
