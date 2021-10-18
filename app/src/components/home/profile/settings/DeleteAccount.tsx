import React from "react";
import { StyleSheet, View } from "react-native";
import { Button, Dialog, List, Paragraph, Portal } from "react-native-paper";
import { deleteUser } from "../../../../api/apiClient";
import { MaterialBottomTabNavigationProp } from "@react-navigation/material-bottom-tabs/lib/typescript/src/types";
import { clearTokens } from "../../../../utils/tokenUtil";

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
      <List.Section title="Other operations">
        <Button
          style={styles.button}
          mode="contained"
          onPress={changeDialogState}
        >
          Delete account
        </Button>
      </List.Section>
      <Portal>
        <Dialog visible={showDialog}>
          <Dialog.Title>Delete account</Dialog.Title>
          <Dialog.Content>
            <Paragraph>
              Do you want delete account? This operation deletes your groups,
              sets and your personal information!
            </Paragraph>
          </Dialog.Content>
          <Dialog.Actions>
            <Button onPress={changeDialogState}>Cancel</Button>
            <Button onPress={handleDelete}>Yes I&apos;m confirm</Button>
          </Dialog.Actions>
        </Dialog>
      </Portal>
    </View>
  );
};

export default DeleteAccount;
