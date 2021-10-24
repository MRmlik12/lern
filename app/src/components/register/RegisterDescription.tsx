// eslint-disable-next-line no-use-before-define
import React from "react";
import { View, StyleSheet } from "react-native";
import { Paragraph } from "react-native-paper";
import i18n from "i18n-js";

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
        {i18n.t("registerDescription")}
      </Paragraph>
    </View>
  );
};

export default RegisterDescription;
