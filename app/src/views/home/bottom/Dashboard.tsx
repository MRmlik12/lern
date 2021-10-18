import React from "react";
import { View } from "react-native";
import { Appbar, Text } from "react-native-paper";

const Dashboard: React.FC = () => {
  return (
    <View>
      <Appbar.Header style={{ backgroundColor: "#fff" }}>
        <Appbar.Content title="Dashboard" />
      </Appbar.Header>
      <Text>Dashboard</Text>
    </View>
  );
};

export default Dashboard;
