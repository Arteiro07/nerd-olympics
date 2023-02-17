"use client";
import { useRef } from "react";
import { Canvas, useFrame } from "@react-three/fiber";
import { Mesh } from "three";

export default function Brain() {
	const meshRef = useRef<any>();

	useFrame(() => {
		if (!meshRef.current) {
			return;
		}

		meshRef.current.rotation.x += 0.01;
		meshRef.current.rotation.y += 0.01;
	});

	return (
		<Canvas>
			<ambientLight intensity={0.1} />
			<directionalLight color="red" position={[0, 0, 5]} />
			<mesh ref={meshRef}>
				<boxGeometry args={[2, 2, 2]} />
				<meshStandardMaterial />
			</mesh>
		</Canvas>
	);
}
