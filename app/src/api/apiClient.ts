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

export const changePassword = async (
  oldPassword: string,
  newPassword: string
): Promise<boolean> => {
  const response = await axios.request<string>({
    method: "POST",
    baseURL: BASE_URL,
    url: "/user/ChangePassword",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${await getToken()}`,
    },
    data: {
      oldPassword: oldPassword,
      newPassword: newPassword,
    },
  });

  return response.status !== 200;
};

export const changeUsername = async (newUsername: string): Promise<boolean> => {
  const response = await axios.request<string>({
    method: "PUT",
    baseURL: BASE_URL,
    url: "/user/ChangeUsername",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${await getToken()}`,
    },
    data: {
      newUsername: newUsername,
    },
  });

  return response.status !== 200;
};

export const deleteUser = async (): Promise<boolean> => {
  const response = await axios.request<string>({
    method: "PUT",
    baseURL: BASE_URL,
    url: "/user/DeleteUser",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${await getToken()}`,
    },
  });

  return response.status !== 200;
};

export const createGroup = async (groupName: string): Promise<string> => {
  const response = await axios.request<string>({
    method: "POST",
    baseURL: BASE_URL,
    url: "/group/CreateGroup",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${await getToken()}`,
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
    url: "/group/user/UserJoin",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${await getToken()}`,
    },
    data: {
      code: code,
    },
  });

  return response.status === 200;
};

export const createSet = async (
  title: string,
  language: string,
  tags: Array<string>,
  items: Array<Object>
): Promise<boolean> => {
  const response = await axios.request<string>({
    method: "POST",
    baseURL: BASE_URL,
    url: "/set/CreateSet",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${await getToken()}`,
    },
    data: {
      title: title,
      language: language,
      tags: tags,
      items: items,
    },
  });

  return response.status === 200;
};
