import axios from "axios";
import { saveToken } from "../utils/tokenUtil";

const BASE_URL = "http://192.168.1.212:5000";

export const login = async (
  email: string,
  password: string
): Promise<boolean> => {
  const response = await axios.request<string>({
    method: "POST",
    baseURL: BASE_URL,
    url: "/user/LoginUser",
    headers: {
      "Content-Type": "application/json",
    },
    data: {
      email: email,
      password: password,
    },
  });

  if (response.data === "") return false;
  await saveToken(response.data);

  return true;
};

export const register = async (
  username: string,
  email: string,
  password: string
): Promise<boolean> => {
  const response = await axios.request<string>({
    method: "POST",
    baseURL: BASE_URL,
    url: "/user/RegisterUser",
    headers: {
      "Content-Type": "application/json",
    },
    data: {
      username: username,
      email: email,
      password: password,
    },
  });

  if (response.data === "") return false;
  await saveToken(response.data);

  return true;
};
