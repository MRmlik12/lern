// eslint-disable-next-line no-use-before-define
import React from "react";
import { View, StyleSheet, ToastAndroid } from "react-native";
import { TextInput, Button } from "react-native-paper";
import { login } from "../../api/apiClient";
import { NavigationProp } from "@react-navigation/native";
import i18n from "../../localization";

interface LoginProps {
  navigation: NavigationProp<any>;
}

const LoginForm: React.FC<LoginProps> = ({ navigation }) => {
  const [email, setEmail] = React.useState("");
  const [password, setPassword] = React.useState("");

  const handleLogin = async () => {
    const isLogged = await login(email, password);

    if (isLogged) {
      navigation.reset({
        index: 0,
        routes: [{ name: "Home" }],
      });

      return;
    }

    ToastAndroid.show("Error", ToastAndroid.SHORT);
  };

  const handleRegister = () => {
    navigation.navigate("Register");
  };

  const styles = StyleSheet.create({
    container: {
      margin: 10,
    },
    emailInput: {
      margin: 5,
    },
    passwordInput: {
      margin: 5,
    },
    loginButton: {
      margin: 5,
    },
    registerButton: {
      margin: 5,
    },
  });

  return (
    <View style={styles.container}>
      <TextInput
        style={styles.emailInput}
        label={i18n.t("email")}
        mode="outlined"
        placeholder="example@example.com"
        value={email}
        onChangeText={(text) => setEmail(text)}
      />
      <TextInput
        style={styles.passwordInput}
        label={i18n.t("password")}
        mode="outlined"
        secureTextEntry={true}
        value={password}
        onChangeText={(text) => setPassword(text)}
      />
      <Button style={styles.loginButton} onPress={handleLogin} mode="contained">
        {i18n.t("login")}
      </Button>
      <Button
        style={styles.registerButton}
        onPress={handleRegister}
        mode="contained"
      >
        {i18n.t("registerNow")}
      </Button>
    </View>
  );
};

export default LoginForm;
