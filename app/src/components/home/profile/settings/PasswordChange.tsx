import React from "react";
import { View, StyleSheet } from "react-native";
import { Button, List, TextInput } from "react-native-paper";
import { isFalsy } from "utility-types";
import { changePassword } from "../../../../api/apiClient";
import { clearTokens } from "../../../../utils/tokenUtil";
import { MaterialBottomTabNavigationProp } from "@react-navigation/material-bottom-tabs/lib/typescript/src/types";

const styles = StyleSheet.create({
  container: {
    width: "95%",
    alignSelf: "center",
  },
  inputs: {
    margin: 5,
  },
});

interface PasswordChangeProps {
  navigation: MaterialBottomTabNavigationProp<any>;
}

const PasswordChange: React.FC<PasswordChangeProps> = ({ navigation }) => {
  const [currentPassword, setCurrentPassword] = React.useState("");
  const [repeatedPassword, setRepeatedPassword] = React.useState("");
  const [newPassword, setNewPassword] = React.useState("");
  const [disable, setDisable] = React.useState(false);

  const changeDisableValue = () => setDisable(!disable);

  const handleResetPassword = async () => {
    changeDisableValue();
    if (isFalsy(newPassword)) {
      console.log(newPassword);
      changeDisableValue();
      return;
    }

    if (currentPassword !== repeatedPassword) {
      changeDisableValue();
      return;
    }

    const response = await changePassword(currentPassword, newPassword);

    if (response) {
      setDisable(false);
      await clearTokens();
      navigation.reset({
        index: 0,
        routes: [{ name: "Login" }],
      });
    }

    changeDisableValue();
  };

  return (
    <View>
      <List.Section title="Change password">
        <View style={styles.container}>
          <TextInput
            style={styles.inputs}
            label="Current password"
            value={currentPassword}
            disabled={disable}
            secureTextEntry
            onChangeText={(text) => setCurrentPassword(text)}
          />
          <TextInput
            style={styles.inputs}
            label="Repeat current password"
            value={repeatedPassword}
            disabled={disable}
            secureTextEntry
            onChangeText={(text) => setRepeatedPassword(text)}
          />
          <TextInput
            style={styles.inputs}
            label="New password"
            value={newPassword}
            disabled={disable}
            secureTextEntry
            onChangeText={(text) => setNewPassword(text)}
          />
          <Button
            style={styles.inputs}
            mode="contained"
            disabled={disable}
            onPress={handleResetPassword}
          >
            Change password
          </Button>
        </View>
      </List.Section>
    </View>
  );
};

export default PasswordChange;
