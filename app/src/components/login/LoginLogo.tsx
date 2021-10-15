// eslint-disable-next-line no-use-before-define
import React, { ReactElement } from "react";
import { View, StyleSheet } from "react-native";
import { Text } from "react-native-paper";

export default function LoginLogo(): ReactElement {
  const styles = StyleSheet.create({
    logo: {
      fontSize: 56,
      textAlign: "center",
    },
  });

  return (
    <View>
      <Text style={styles.logo}>Lern</Text>
    </View>
  );
}
