"use client";

import { Suspense } from "react";
import Brain from "./Brain";
import { Canvas } from "@react-three/fiber";

export default function Page() {
	return (
		<Suspense fallback={null}>
			<Canvas camera={{ position: [0, 0, 0.1], near: 0.1 }}>
				<Brain />
			</Canvas>
		</Suspense>
	);
}

//return <></>;
