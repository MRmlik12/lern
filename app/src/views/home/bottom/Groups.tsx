// eslint-disable-next-line no-use-before-define
import React from "react";
import { StyleSheet } from "react-native";
import { Portal, Provider, FAB, Text } from "react-native-paper";

const styles = StyleSheet.create({
  container: {
    alignItems: "center",
    flex: 1,
    justifyContent: "center",
  },
  fab: {
    position: "absolute",
    margin: 16,
    right: 0,
    bottom: 0,
  },
  noGroupsText: {
    textAlign: "center",
  },
});

const GroupsFAB: React.FC = () => {
  const [state, setState] = React.useState({ open: false });

  const onStateChange = ({ open }: any) => setState({ open });

  const fabActions = [
    {
      icon: "plus",
      label: "Create group",
      onPress: () => console.log("Clicked"),
    },
    {
      icon: "plus",
      label: "Join to group",
      onPress: () => console.log("Clicked"),
    },
  ];

  return (
    <Provider>
      <Portal>
        <FAB.Group
          visible={true}
          style={styles.fab}
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
        <Text style={styles.noGroupsText}>You have no groups :(</Text>
      </Provider>
  );
};

export default Groups;
