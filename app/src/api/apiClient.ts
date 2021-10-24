import axios from "axios";
import { getToken, saveToken } from "../utils/tokenUtil";
import { SetCollectionResponse } from "./models/setCollectionResponse";
import { GetSetResponse } from "./models/getSetResponse";
import { UserInformationResponse } from "./models/userInformationResponse";
import { GroupCollectionItem } from "./models/groupCollectionItem";

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

export const changeAvatar = async (avatar: string): Promise<boolean> => {
  const response = await axios.request<string>({
    method: "POST",
    baseURL: BASE_URL,
    url: "/user/settings/UploadUserAvatar",
    data: {
      avatarData: avatar,
    },
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${await getToken()}`,
    },
  });

  return response.status === 200;
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

export const userInfo = async (): Promise<UserInformationResponse> => {
  const response = await axios.request<UserInformationResponse>({
    method: "GET",
    baseURL: BASE_URL,
    url: "/user/GetUserInformation",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${await getToken()}`,
    },
  });

  if (response.status !== 200) {
    throw new Error("Couldn't get user data");
  }

  return response.data;
};

export const getGroups = async (): Promise<Array<GroupCollectionItem>> => {
  const response = await axios.request<Array<GroupCollectionItem>>({
    method: "GET",
    baseURL: BASE_URL,
    url: "/user/group/GetUserGroupCollection",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${await getToken()}`,
    },
  });

  if (response.status !== 200) {
    throw new Error("Couldn't get data");
  }

  return response.data;
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

export const getUserSetCollection = async (
  page: number
): Promise<Array<SetCollectionResponse>> => {
  const response = await axios.request<Array<SetCollectionResponse>>({
    method: "GET",
    baseURL: BASE_URL,
    url: "/user/set/GetUserSetCollection",
    params: {
      page: page,
    },
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${await getToken()}`,
    },
  });

  if (response.status !== 200) {
    throw new Error("Couldn't get user data");
  }

  return response.data;
};

export const getSet = async (setId: string): Promise<GetSetResponse> => {
  const response = await axios.request<GetSetResponse>({
    method: "GET",
    baseURL: BASE_URL,
    url: "/set/GetSet",
    params: {
      setId: setId,
    },
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${await getToken()}`,
    },
  });

  if (response.status !== 200) {
    throw new Error("Couldn't get user data");
  }

  return response.data;
};

export const getLatestSet = async (): Promise<Array<SetCollectionResponse>> => {
  const response = await axios.request<Array<SetCollectionResponse>>({
    method: "GET",
    baseURL: BASE_URL,
    url: "/set/GetLatestAddedSets",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${await getToken()}`,
    },
  });

  if (response.status !== 200) {
    throw new Error("Couldn't get sets data");
  }

  return response.data;
};
