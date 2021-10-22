import React from "react";
import { View, StyleSheet, ToastAndroid } from "react-native";
import { Button, List, TextInput } from "react-native-paper";
import { changeAvatar, changeUsername } from "../../../../api/apiClient";
import { isFalsy } from "utility-types";
import { getPhoto } from "../../../../utils/imagePickerUtil";

const styles = StyleSheet.create({
  container: {
    width: "95%",
    alignSelf: "center",
  },
  inputs: {
    margin: 5,
  },
});

interface BasicInformationProps {
  name: string;
}

const BasicInformation: React.FC<BasicInformationProps> = ({ name }) => {
  const [username, setUsername] = React.useState(name);
  const [disable, setDisable] = React.useState(false);
  const [error, setError] = React.useState(false);

  const changeDisableValue = () => setDisable(!disable);
  const changeErrorValue = () => setError(!error);

  const handleChangeAvatar = async () => {
    const avatar = await getPhoto();
    if (avatar?.cancelled) return;

    const formData = new FormData();
    formData.append("file", {
      uri: avatar?.uri,
      filename: "avatar.jpeg",
      type: "image/jpg",
    });

    const response = await changeAvatar(formData);

    if (response) {
      ToastAndroid.show("Uploaded!", ToastAndroid.SHORT);
    }
  };

  const handleChangeUsername = async () => {
    changeDisableValue();
    if (isFalsy(username)) {
      changeDisableValue();
      return;
    }

    const response = await changeUsername(username);

    if (response) {
      changeDisableValue();
      changeErrorValue();
    }

    changeDisableValue();
  };

  return (
    <View>
      <List.Section title="Basic information">
        <View style={styles.container}>
          <TextInput
            label="Username"
            style={styles.inputs}
            value={username}
            onChangeText={(text) => setUsername(text)}
            disabled={disable}
            error={error}
            right={
              <TextInput.Icon
                name="content-save"
                onPress={handleChangeUsername}
              />
            }
          />
          <Button
            style={styles.inputs}
            mode="contained"
            disabled={disable}
            onPress={handleChangeAvatar}
          >
            Change avatar
          </Button>
        </View>
      </List.Section>
    </View>
  );
};

export default BasicInformation;
