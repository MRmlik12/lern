import React from "react";
import { StyleSheet } from "react-native";
import { FAB, Portal, Provider } from "react-native-paper";
import { MaterialBottomTabNavigationProp } from "@react-navigation/material-bottom-tabs/lib/typescript/src/types";

interface CreateSetFABProps {
  navigation: MaterialBottomTabNavigationProp<any>;
}

const styles = StyleSheet.create({
  fab: {
    position: "absolute",
    margin: 16,
    right: 0,
    bottom: 0,
  },
});

const CreateSetFAB: React.FC<CreateSetFABProps> = ({ navigation }) => {
  return (
    <Provider>
      <Portal>
        <FAB
          style={styles.fab}
          icon="plus"
          onPress={() =>
            navigation.navigate("CreateSet", {
              phrases: [],
            })
          }
        />
      </Portal>
    </Provider>
  );
};

export default CreateSetFAB;
