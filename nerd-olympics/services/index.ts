const baseURL = "https://nerd-olympics-api-dev.azurewebsites.net";

const myHeaders = new Headers();
myHeaders.append("Content-Type", "application/json");
myHeaders.append(
	"Ocp-Apim-Subscription-Key",
	process.env.NEXT_PUBLIC_API_KEY as string
);

export { baseURL, myHeaders };
