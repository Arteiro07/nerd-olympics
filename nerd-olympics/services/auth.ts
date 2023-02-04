import { User } from "@/utilities/types";

import api from ".";
const requestOptions = {
	method: 'POST',
	headers: { 'Content-Type': 'application/json' },
	body: JSON.stringify({ title: 'React Hooks POST Request Example' })
};
export async function authSignUp(user: User) {
	try{
		const res = await fetch("https://apim-nerd-olympics-dev.azure-api.net/users/registration" ,requestOptions);	
		if(res.status===200) {
			console.log( await res.json());
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