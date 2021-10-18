import React, { useEffect } from "react";
import { FAB, Portal, Provider } from "react-native-paper";
import CreateGroup from "../../../views/home/bottom/groups/CreateGroup";

const GroupsFAB = () => {
  const [state, setState] = React.useState({ open: false });
  const [createGroupVisible, setCreateGroupVisible] = React.useState(false);
  const onStateChange = ({ open }: any) => setState({ open });

  const fabActions = [
    {
      icon: "account-group-outline",
      label: "Create group",
      onPress: () => setCreateGroupVisible(true),
    },
    {
      icon: "account-multiple-plus-outline",
      label: "Join to group",
      onPress: () => console.log(""),
    },
  ];

  return (
      <Provider>
        {createGroupVisible ? <CreateGroup /> : null}
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

export default GroupsFAB;
