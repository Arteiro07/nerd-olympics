import { User } from "@/utilities/types";

import api from ".";

export async function authSignUp(user: User) {
	try{
		const res = await api.post("/users/registration");
	
		if(res.status===200) {
			console.log( res.data);
		}
		else {
			console.log(res.status);
        }
	}
	catch(error) {
		console.log(error);
	}
	return null;
}