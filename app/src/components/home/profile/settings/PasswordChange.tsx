import React from "react";
import { View, StyleSheet } from "react-native";
import { Button, List, TextInput } from "react-native-paper";
import { isFalsy } from "utility-types";
import { changePassword } from "../../../../api/apiClient";
import { clearTokens } from "../../../../utils/tokenUtil";
import { MaterialBottomTabNavigationProp } from "@react-navigation/material-bottom-tabs/lib/typescript/src/types";
import i18n from "i18n-js";

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
      <List.Section title={i18n.t("changePassword")}>
        <View style={styles.container}>
          <TextInput
            style={styles.inputs}
            label={i18n.t("currentPassword")}
            value={currentPassword}
            disabled={disable}
            secureTextEntry
            onChangeText={(text) => setCurrentPassword(text)}
          />
          <TextInput
            style={styles.inputs}
            label={i18n.t("repeatCurrentPassword")}
            value={repeatedPassword}
            disabled={disable}
            secureTextEntry
            onChangeText={(text) => setRepeatedPassword(text)}
          />
          <TextInput
            style={styles.inputs}
            label={i18n.t("newPassword")}
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
            {i18n.t("changePassword")}
          </Button>
        </View>
      </List.Section>
    </View>
  );
};

export default PasswordChange;
