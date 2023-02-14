export async function error(func: Promise<T>) {
	try {
		const data = await func;
		return [data, null];
	} catch (error) {
		console.error(error);
		return [null, error];
	}
}
