export type User = {
	name: string;
	email: string;
	password: string;
	isLoggedIn: boolean;
	id: number;
	token: string;
	avatarId: number;
	userId: number;
};

export const initialState: User = {
	userId: 0,
	name: "",
	password: "",
	email: "",
	isLoggedIn: false,
	id: 0,
	token: "",
	avatarId: 0,
};

export type UserLoginResponse = {
	token: string;
	user: User;
};
export type UserSignUpResponse = {
	token: string;
	createdUser: User;
};
