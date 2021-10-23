// eslint-disable-next-line no-use-before-define
import React from "react";
import { View, StyleSheet } from "react-native";
import LoginForm from "../components/login/LoginForm";
import LoginLogo from "../components/login/LoginLogo";
import { NavigationProp } from "@react-navigation/native";

interface LoginProps {
  navigation: NavigationProp<any>;
}

const Login: React.FC<LoginProps> = ({ navigation }) => {
  const styles = StyleSheet.create({
    container: {
      marginTop: "40%",
    },
  });

  return (
    <View style={styles.container}>
      <LoginLogo />
      <LoginForm navigation={navigation} />
    </View>
  );
};

export default Login;
