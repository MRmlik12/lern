import React from "react";
import { StyleSheet, View } from "react-native";
import { Button, Dialog, List, Paragraph, Portal } from "react-native-paper";
import { deleteUser } from "../../../../api/apiClient";
import { MaterialBottomTabNavigationProp } from "@react-navigation/material-bottom-tabs/lib/typescript/src/types";
import { clearTokens } from "../../../../utils/tokenUtil";
import i18n from "i18n-js";

const styles = StyleSheet.create({
  button: {
    backgroundColor: "#e53935",
    width: "95%",
    alignSelf: "center",
    margin: 5,
  },
});

interface DeleteAccountProps {
  navigation: MaterialBottomTabNavigationProp<any>;
}

const DeleteAccount: React.FC<DeleteAccountProps> = ({ navigation }) => {
  const [showDialog, setShowDialog] = React.useState(false);

  const handleDelete = async () => {
    const response = await deleteUser();
    if (response) {
      await clearTokens();
      navigation.reset({
        index: 0,
        routes: [{ name: "Login" }],
      });
    }
  };

  const changeDialogState = () => setShowDialog(!showDialog);

  return (
    <View>
      <List.Section title={i18n.t("otherOperations")}>
        <Button
          style={styles.button}
          mode="contained"
          onPress={changeDialogState}
        >
          {i18n.t("deleteAccount")}
        </Button>
      </List.Section>
      <Portal>
        <Dialog visible={showDialog}>
          <Dialog.Title>{i18n.t("deleteAccount")}</Dialog.Title>
          <Dialog.Content>
            <Paragraph>
              {i18n.t("deleteAccountDescription")}
            </Paragraph>
          </Dialog.Content>
          <Dialog.Actions>
            <Button onPress={changeDialogState}>{i18n.t("cancel")}</Button>
            <Button onPress={handleDelete}>{i18n.t("yesConfirm")}</Button>
          </Dialog.Actions>
        </Dialog>
      </Portal>
    </View>
  );
};

export default DeleteAccount;
