"use client";

import { Suspense } from "react";
import Brain from "./Brain";
import { Canvas } from "@react-three/fiber";

export default function Page() {
	return (
		<Suspense fallback={null}>
			<Canvas>
				<Brain />
			</Canvas>
		</Suspense>
	);
}

//return <></>;
