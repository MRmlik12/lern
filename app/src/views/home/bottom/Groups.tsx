// eslint-disable-next-line no-use-before-define
import React from "react";
import { Portal, Provider, FAB } from "react-native-paper";
import { NavigationProp } from "@react-navigation/native";

const GroupsFAB = () => {
  const [state, setState] = React.useState({ open: false });
  const onStateChange = ({ open }: any) => setState({ open });

  const fabActions = [
    {
      icon: "account-group-outline",
      label: "Create group",
      onPress: () => console.log(""),
    },
    {
      icon: "account-multiple-plus-outline",
      label: "Join to group",
      onPress: () => console.log(""),
    },
  ];

  return (
    <Provider>
      <Portal>
        <FAB.Group
          visible={true}
          open={state.open}
          icon={"plus"}
          actions={fabActions}
          onStateChange={onStateChange}
        />
      </Portal>
    </Provider>
  );
};

const Groups: React.FC = () => {
  return (
    <Provider>
      <GroupsFAB />
    </Provider>
  );
};

export default Groups;
