// eslint-disable-next-line no-use-before-define
import React from "react";
import { View, StyleSheet, ToastAndroid } from "react-native";
import { TextInput, Button } from "react-native-paper";
import { register } from "../../api/apiClient";
import { NavigationProp } from "@react-navigation/native";
import i18n from "i18n-js";

interface RegisterProps {
  navigation: NavigationProp<any>;
}

const RegisterForm: React.FC<RegisterProps> = ({ navigation }) => {
  const [username, setUsername] = React.useState("");
  const [email, setEmail] = React.useState("");
  const [password, setPassword] = React.useState("");

  const handleRegister = async () => {
    const isRegistered = await register(username, email, password);

    if (isRegistered) {
      navigation.reset({
        index: 0,
        routes: [{ name: "Home" }],
      });

      return;
    }

    ToastAndroid.show("Error", ToastAndroid.SHORT);
  };

  const styles = StyleSheet.create({
    container: {
      margin: 10,
    },
    formItems: {
      margin: 5,
    },
  });

  return (
    <View style={styles.container}>
      <TextInput
        style={styles.formItems}
        label={i18n.t("username")}
        mode="outlined"
        placeholder="example"
        value={username}
        onChangeText={(text) => setUsername(text)}
      />
      <TextInput
        style={styles.formItems}
        label={i18n.t("email")}
        mode="outlined"
        placeholder="example@example.com"
        value={email}
        onChangeText={(text) => setEmail(text)}
      />
      <TextInput
        style={styles.formItems}
        label={i18n.t("password")}
        mode="outlined"
        secureTextEntry={true}
        value={password}
        onChangeText={(text) => setPassword(text)}
      />
      <Button
        style={styles.formItems}
        onPress={handleRegister}
        mode="contained"
      >
        {i18n.t("register")}
      </Button>
    </View>
  );
};

export default RegisterForm;
