import React from "react";
import { ToastAndroid, View } from "react-native";
import { Button, Dialog, TextInput, Portal } from "react-native-paper";
import { isFalsy } from "utility-types";
import { createGroup } from "../../../../api/apiClient";
import i18n from "i18n-js";

const CreateGroup: React.FC = () => {
  const [visible, setVisible] = React.useState(true);
  const [isError, setIsError] = React.useState(false);
  const [groupName, setGroupName] = React.useState("");

  const hideDialog = () => setVisible(false);

  const handleCreateGroup = async () => {
    if (isFalsy(groupName)) {
      setIsError(true);
      return;
    }

    const code = await createGroup(groupName);
    if (isFalsy(code)) {
      ToastAndroid.show(i18n.t("error"), ToastAndroid.SHORT);
      return;
    }

    hideDialog();
  };

  return (
    <View>
      <Portal>
        <Dialog visible={visible} onDismiss={hideDialog}>
          <Dialog.Title>{i18n.t("createGroup")}</Dialog.Title>
          <Dialog.Content>
            <TextInput
              label={i18n.t("name")}
              value={groupName}
              error={isError}
              mode="outlined"
              onChangeText={(text) => setGroupName(text)}
            />
          </Dialog.Content>
          <Dialog.Actions>
            <Button onPress={hideDialog}>{i18n.t("cancel")}</Button>
            <Button onPress={handleCreateGroup}>{i18n.t("create")}</Button>
          </Dialog.Actions>
        </Dialog>
      </Portal>
    </View>
  );
};

export default CreateGroup;
