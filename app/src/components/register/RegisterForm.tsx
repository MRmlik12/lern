// eslint-disable-next-line no-use-before-define
import React from "react";
import { View, StyleSheet, ToastAndroid } from "react-native";
import { TextInput, Button } from "react-native-paper";
import { register } from "../../api/apiClient";
import { NavigationProp } from "@react-navigation/native";

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
        label="Username"
        mode="outlined"
        placeholder="example"
        value={username}
        onChangeText={(text) => setUsername(text)}
      />
      <TextInput
        style={styles.formItems}
        label="Email"
        mode="outlined"
        placeholder="example@example.com"
        value={email}
        onChangeText={(text) => setEmail(text)}
      />
      <TextInput
        style={styles.formItems}
        label="Password"
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
        Register
      </Button>
    </View>
  );
};

export default RegisterForm;
