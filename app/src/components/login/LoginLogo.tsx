// eslint-disable-next-line no-use-before-define
import React, { ReactElement } from "react";
import { View, StyleSheet } from "react-native";
import { Text } from "react-native-paper";
import {
  useFonts,
  // eslint-disable-next-line camelcase
  KaushanScript_400Regular,
} from "@expo-google-fonts/kaushan-script";

export default function LoginLogo(): ReactElement {
  useFonts({
    KaushanScript_400Regular,
  });

  const styles = StyleSheet.create({
    logo: {
      fontSize: 56,
      textAlign: "center",
      fontFamily: "KaushanScript_400Regular",
    },
  });

  return (
    <View>
      <Text style={styles.logo}>Lern</Text>
    </View>
  );
}
