// eslint-disable-next-line no-use-before-define
import React from "react";
import { View, StyleSheet } from "react-native";
import { NavigationProp } from "@react-navigation/native";
import RegisterForm from "../components/register/RegisterForm";
import RegisterDescription from "../components/register/RegisterDescription";

interface RegisterProps {
  navigation: NavigationProp<any>;
}

const Register: React.FC<RegisterProps> = ({ navigation }) => {
  const styles = StyleSheet.create({
    container: {
      marginTop: "50%",
    },
  });

  return (
    <View style={styles.container}>
      <RegisterDescription />
      <RegisterForm navigation={navigation} />
    </View>
  );
};

export default Register;
