import axios from "axios";
import React from "react";
import Image from "next/image";
import { NextPageContext } from "next";
import { User } from "@/utilities/userTypes";

export default async function Page(user: User) {
	const res = await axios.get(`https://dummyjson.com/users/${user.id}`);

	return <div className="playerCard">{res.data.email}</div>;
}
