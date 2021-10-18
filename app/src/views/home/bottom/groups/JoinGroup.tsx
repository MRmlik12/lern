import React from "react";
import { ToastAndroid, View } from "react-native";
import { Button, Dialog, Portal, Provider, Text, TextInput } from "react-native-paper";
import { joinGroup } from "../../../../api/apiClient";
import { isFalsy } from "utility-types";

const JoinGroup: React.FC = () => {
  const [visible, setVisible] = React.useState(true);
  const [isError, setIsError] = React.useState(false);
  const [groupCode, setGroupCode] = React.useState("");

  const hideDialog = () => setVisible(false);

  const handleJoinGroup = async () => {
    if (isFalsy(groupCode)) {
      setIsError(true);
      return;
    }

    const isJoined = await joinGroup(groupCode);
    if (isJoined) {
      hideDialog();
      return;
    }

    ToastAndroid.show("Invalid message", ToastAndroid.SHORT);
  };

  return (
    <Provider>
      <View>
        <Portal>
          <Dialog visible={visible} onDismiss={hideDialog}>
            <Dialog.Title>Join to group</Dialog.Title>
            <Dialog.Content>
              <TextInput
                label="Code"
                value={groupCode}
                error={isError}
                mode="outlined"
                maxLength={10}
                onChangeText={(text) => setGroupCode(text)}
              />
            </Dialog.Content>
            <Dialog.Actions>
              <Button onPress={hideDialog}>Cancel</Button>
              <Button onPress={handleJoinGroup}>Join</Button>
            </Dialog.Actions>
          </Dialog>
        </Portal>
      </View>
    </Provider>
  );
};

export default JoinGroup;
