// eslint-disable-next-line no-use-before-define
import React from "react";
import { View, StyleSheet } from "react-native";
import { Text } from "react-native-paper";

const RegisterDescription: React.FC = () => {
  const styles = StyleSheet.create({
    descriptionText: {
      textAlign: "center",
      fontSize: 16,
    },
  });

  return (
    <View>
      <Text style={styles.descriptionText}>
        To register account, please fill the all fields
      </Text>
    </View>
  );
};

export default RegisterDescription;
