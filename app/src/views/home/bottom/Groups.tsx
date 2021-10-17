import React from "react";
import { Provider } from "react-native-paper";
import GroupsFAB from "../../../components/home/groups/GroupsFAB";

const Groups: React.FC = () => {
  return (
    <Provider>
      <GroupsFAB />
    </Provider>
  );
};

export default Groups;
