"use client";

import style from "./layout.module.scss";
import "./layout.scss";
import { AiFillHome } from "react-icons/ai";
import { BiUserCircle } from "react-icons/bi";

import Link from "next/link";
import Image from "next/image";
import logo from "../public/logo.svg";
import user from "../public/user.webp";
import AuthProvider from "@/context/authContext";
import { useState } from "react";
import Dropdown from "./Dropdown";
import UserLogo from "./UserLogo";

export default function RootLayout({
	children,
}: {
	children: React.ReactNode;
}) {
	return (
		<html lang="en">
			<head />
			<body>
				<AuthProvider>
					<div className={style.container}>
						<div className={style.navigationBar}>
							<nav>
								<ul>
									<li>
										<Image
											className={style.logo}
											src={logo}
											alt="Logo"
											width={50}
											height={50}
											priority
										/>
									</li>
									<li>
										<Link href="/">
											{" "}
											<AiFillHome />{" "}
										</Link>
									</li>
									<li>
										<Link href="/about">About </Link>
									</li>
									<li>
										<Link href="/competitions">Competitions</Link>
									</li>
									<li className={style.user}>
										<UserLogo />
									</li>
								</ul>
							</nav>
						</div>
						<div className={style.content}>{children}</div>
					</div>
				</AuthProvider>
			</body>
		</html>
	);
}
