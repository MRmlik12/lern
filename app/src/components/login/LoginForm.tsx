// eslint-disable-next-line no-use-before-define
import React from "react";
import { View, StyleSheet, ToastAndroid } from "react-native";
import { TextInput, Button } from "react-native-paper";
import { login } from "../../api/apiClient";
import { NavigationProp } from "@react-navigation/native";

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
        label="Email"
        mode="outlined"
        placeholder="example@example.com"
        value={email}
        onChangeText={(text) => setEmail(text)}
      />
      <TextInput
        style={styles.passwordInput}
        label="Password"
        mode="outlined"
        secureTextEntry={true}
        value={password}
        onChangeText={(text) => setPassword(text)}
      />
      <Button style={styles.loginButton} onPress={handleLogin} mode="contained">
        Login
      </Button>
      <Button
        style={styles.registerButton}
        onPress={handleRegister}
        mode="contained"
      >
        Register Now
      </Button>
    </View>
  );
};

export default LoginForm;
