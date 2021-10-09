import { registerRootComponent } from "expo";
import { StatusBar } from "expo-status-bar";
// eslint-disable-next-line no-use-before-define
import React, { ReactElement } from "react";
import { StyleSheet, Text, View } from "react-native";

function App(): ReactElement {
  return (
    <View style={styles.container}>
      <Text>Open up App.tsx to start working on your app!</Text>
      <StatusBar style="auto" />
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: "#fff",
    alignItems: "center",
    justifyContent: "center",
  },
});

export default registerRootComponent(App);