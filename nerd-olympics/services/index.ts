const baseURL = "https://apim-nerd-olympics-dev.azure-api.net";

const myHeaders = new Headers();
myHeaders.append("Content-Type", "application/json");
myHeaders.append(
	"Ocp-Apim-Subscription-Key",
	process.env.NEXT_PUBLIC_API_KEY as string
);

export { baseURL, myHeaders };
