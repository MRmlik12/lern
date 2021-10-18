import React from "react";
import { View, StyleSheet } from "react-native";
import { List, TextInput } from "react-native-paper";
import { changeUsername } from "../../../../api/apiClient";
import { isFalsy } from "utility-types";

const styles = StyleSheet.create({
  container: {
    width: "95%",
    alignSelf: "center",
  },
  inputs: {
    margin: 5,
  },
});

const BasicInformation: React.FC = () => {
  const [username, setUsername] = React.useState("");
  const [disable, setDisable] = React.useState(false);
  const [error, setError] = React.useState(false);

  const changeDisableValue = () => setDisable(!disable);
  const changeErrorValue = () => setError(!error);

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
        </View>
      </List.Section>
    </View>
  );
};

export default BasicInformation;
