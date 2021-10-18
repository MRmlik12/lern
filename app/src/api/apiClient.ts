import axios from "axios";
import { getToken, saveToken } from "../utils/tokenUtil";

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

export const createGroup = async (groupName: string): Promise<string> => {
  const response = await axios.request<string>({
    method: "POST",
    baseURL: BASE_URL,
    url: "group/CreateGroup",
    headers: {
      "Content-Type": "application/json",
      Authentication: `Bearer ${await getToken()}`,
    },
    data: {
      name: groupName,
    },
  });

  if (response.status === 200) return response.data;

  return "";
};

export const joinGroup = async (code: string): Promise<boolean> => {
  const response = await axios.request<string>({
    method: "POST",
    baseURL: BASE_URL,
    url: "group/user/UserJoin",
    headers: {
      "Content-Type": "application/json",
      Authentication: `Bearer ${await getToken()}`,
    },
    data: {
      code: code,
    },
  });

  return response.status === 200;
};
