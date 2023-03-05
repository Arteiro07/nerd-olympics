import CryptoJS from "crypto-js";

export default function encrypt(password: string) {
	var secretKey = CryptoJS.lib.WordArray.random(128 / 8).toString(
		CryptoJS.enc.Hex
	);

	var encrypt = CryptoJS.AES.encrypt(password, secretKey).toString();

	return encrypt;
}
