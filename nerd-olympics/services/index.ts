import axios from "axios";

const api = axios.create({
    baseURL: "https://apim-nerd-olympics-dev.azure-api.net",
    headers: {"Ocp-Apim-Subscription-Key": process.env.API_KEY, }

});

export default api;
