import * as SecureStore from "expo-secure-store";

const JWT_KEY = "JWT";

export const saveToken = async (jwtToken: string) => {
  await SecureStore.setItemAsync(JWT_KEY, jwtToken);
};

export const getToken = async (): Promise<string | null> => {
  return await SecureStore.getItemAsync(JWT_KEY);
};

export const clearTokens = async () => {
  await SecureStore.deleteItemAsync(JWT_KEY);
};
