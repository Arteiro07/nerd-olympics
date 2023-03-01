"use client";
import { useRef } from "react";
import { useLoader, useFrame } from "@react-three/fiber";
import { GLTFLoader } from "three/examples/jsm/loaders/GLTFLoader";
import { OrbitControls } from "@react-three/drei";

export default function Brain() {
	const meshRef = useRef<any>();
	const gltf = useLoader(GLTFLoader, "/brain.gltf");

	useFrame(() => {
		if (!meshRef.current) {
			return;
		}

		meshRef.current.rotation.x += 0.001;
		meshRef.current.rotation.y += 0.001;
	});

	return (
		<>
			<OrbitControls target={[0, 0, 0]} maxPolarAngle={1.45} />
			<ambientLight color="orange" intensity={0.5} />
			<directionalLight color="orange" position={[0, 0, 5]} />
			<directionalLight color="orange" position={[0, 5, 0]} />
			<directionalLight color="orange" position={[5, 0, 0]} />
			<primitive object={gltf.scene} ref={meshRef} />
		</>
	);
}
