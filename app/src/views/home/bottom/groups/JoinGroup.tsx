import React from "react";
import { ToastAndroid, View } from "react-native";
import { Button, Dialog, Portal, TextInput } from "react-native-paper";
import { joinGroup } from "../../../../api/apiClient";
import { isFalsy } from "utility-types";
import i18n from "i18n-js";

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

    ToastAndroid.show(i18n.t("invalidMessage"), ToastAndroid.SHORT);
  };

  return (
    <View>
      <Portal>
        <Dialog visible={visible} onDismiss={hideDialog}>
          <Dialog.Title>{i18n.t("joinToGroup")}</Dialog.Title>
          <Dialog.Content>
            <TextInput
              label={i18n.t("code")}
              value={groupCode}
              error={isError}
              mode="outlined"
              maxLength={10}
              onChangeText={(text) => setGroupCode(text)}
            />
          </Dialog.Content>
          <Dialog.Actions>
            <Button onPress={hideDialog}>{i18n.t("cancel")}</Button>
            <Button onPress={handleJoinGroup}>{i18n.t("join")}</Button>
          </Dialog.Actions>
        </Dialog>
      </Portal>
    </View>
  );
};

export default JoinGroup;
