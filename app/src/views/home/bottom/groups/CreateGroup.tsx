import React from "react";
import { ToastAndroid, View } from "react-native";
import {
  Button,
  Dialog,
  TextInput,
  Portal,
  Provider,
} from "react-native-paper";
import { isFalsy } from "utility-types";
import { createGroup } from "../../../../api/apiClient";

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
      ToastAndroid.show("Error", ToastAndroid.SHORT);
      return;
    }

    hideDialog();
  };

  return (
    <View>
      <Portal>
        <Dialog visible={visible} onDismiss={hideDialog}>
          <Dialog.Title>Create group</Dialog.Title>
          <Dialog.Content>
            <TextInput
              label="Name"
              value={groupName}
              error={isError}
              mode="outlined"
              onChangeText={(text) => setGroupName(text)}
            />
          </Dialog.Content>
          <Dialog.Actions>
            <Button onPress={hideDialog}>Cancel</Button>
            <Button onPress={handleCreateGroup}>Create</Button>
          </Dialog.Actions>
        </Dialog>
      </Portal>
    </View>
  );
};

export default CreateGroup;
