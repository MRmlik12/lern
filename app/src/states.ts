import { atom } from "recoil";

export const dashboardUserCollectionRefresh = atom({
  key: "dashboardUserCollectionRefresh",
  default: true,
});

export const dashboardUserCollectionPage = atom({
  key: "dashboardUserCollectionPage",
  default: 1,
});
