// eslint-disable-next-line no-use-before-define
import React, { ReactElement, useEffect } from "react";
import { View, StyleSheet } from "react-native";
import { Text } from "react-native-paper";
import * as Font from "expo-font";

export default function LoginLogo(): ReactElement {
  useEffect(() => {
    (async () =>
      await Font.loadAsync({
        KaushanScript_400Regular: require("@expo-google-fonts/kaushan-script"),
      }))();
  }, []);

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
