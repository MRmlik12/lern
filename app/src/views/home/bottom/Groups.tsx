// eslint-disable-next-line no-use-before-define
import React from "react";
import { Portal, Provider, FAB } from "react-native-paper";
import { NavigationProp } from "@react-navigation/native";

interface GroupsProps {
  navigation: NavigationProp<any>;
}

const GroupsFAB: React.FC<GroupsProps> = ({ navigation }) => {
  const [state, setState] = React.useState({ open: false });
  const onStateChange = ({ open }: any) => setState({ open });

  const fabActions = [
    {
      icon: "account-group-outline",
      label: "Create group",
      onPress: () => navigation.navigate("CreateGroup"),
    },
    {
      icon: "account-multiple-plus-outline",
      label: "Join to group",
      onPress: () => navigation.navigate("JoinGroup"),
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

const Groups: React.FC<GroupsProps> = ({ navigation }) => {
  return (
    <Provider>
      <GroupsFAB navigation={navigation} />
    </Provider>
  );
};

export default Groups;
