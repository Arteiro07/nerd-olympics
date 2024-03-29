"use client";

import React, { createContext, useEffect, useContext, useState } from "react";
import { User } from "@/utilities/userTypes";
import { initialState } from "@/utilities/userTypes";

interface ContextValue {
	user: User;
	setUser: React.Dispatch<React.SetStateAction<User>>;
}

export const AuthContext = createContext<ContextValue>({
	user: initialState,
	setUser: () => initialState,
});

export function useAuth() {
	return useContext(AuthContext);
}

export default function AuthProvider({
	children,
}: {
	children: React.ReactNode;
}) {
	const [user, setUser] = useState(initialState);

	useEffect(() => {
		const sessionUser = JSON.parse(sessionStorage.getItem("user")!);
		if (sessionUser) {
			setUser(sessionUser);
		}
	}, []);

	useEffect(() => {
		sessionStorage.setItem("user", JSON.stringify(user));
	}, [user]);

	return (
		<AuthContext.Provider value={{ user, setUser }}>
			{children}
		</AuthContext.Provider>
	);
}
