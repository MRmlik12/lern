// eslint-disable-next-line no-use-before-define
import React, { ReactElement } from "react";
import { View, StyleSheet } from "react-native";
import { Text } from "react-native-paper";
import { useFonts } from "@expo-google-fonts/kaushan-script";

export default function LoginLogo(): ReactElement {
  useFonts({
    KaushanScript: require("@expo-google-fonts/kaushan-script"),
  });

  const styles = StyleSheet.create({
    logo: {
      fontSize: 56,
      textAlign: "center",
      fontFamily: "KaushanScript",
    },
  });

  return (
    <View>
      <Text style={styles.logo}>Lern</Text>
    </View>
  );
}
