import { SetItems } from "./setItems";

export interface GetSetResponse {
  title: string;
  language: string;
  tags: Array<string>;
  items: Array<SetItems>;
  createdAt: Date;
  userId: string;
}
