// eslint-disable-next-line no-use-before-define
import React from "react";
import { View, StyleSheet } from "react-native";
import { Paragraph } from "react-native-paper";

const RegisterDescription: React.FC = () => {
  const styles = StyleSheet.create({
    descriptionText: {
      textAlign: "center",
      fontSize: 16,
    },
  });

  return (
    <View>
      <Paragraph style={styles.descriptionText}>
        To register account, please fill the all fields
      </Paragraph>
    </View>
  );
};

export default RegisterDescription;
