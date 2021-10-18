import React from "react";
import { Appbar, Provider } from "react-native-paper";
import GroupsFAB from "../../../components/home/groups/GroupsFAB";

const Groups: React.FC = () => {
  return (
    <Provider>
      <Appbar.Header style={{ backgroundColor: "#fff" }}>
        <Appbar.Content title="Groups" />
      </Appbar.Header>
      <GroupsFAB />
    </Provider>
  );
};

export default Groups;
