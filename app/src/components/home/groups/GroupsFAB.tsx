import React from "react";
import { FAB, Portal, Provider } from "react-native-paper";

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

export default GroupsFAB;
