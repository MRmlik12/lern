import React from "react";
import { View } from "react-native";
import { Appbar, Provider, Text } from "react-native-paper";
import CreateSetFAB from "../../../components/home/dashboard/CreateSetFAB";
import { MaterialBottomTabNavigationProp } from "@react-navigation/material-bottom-tabs/lib/typescript/src/types";

interface DashboardProps {
  navigation: MaterialBottomTabNavigationProp<any>;
}

const Dashboard: React.FC<DashboardProps> = ({ navigation }) => {
  return (
    <Provider>
      <Appbar.Header style={{ backgroundColor: "#fff" }}>
        <Appbar.Content title="Dashboard" />
      </Appbar.Header>
      <View>
        <Text>Dashboard</Text>
      </View>
      <CreateSetFAB navigation={navigation} />
    </Provider>
  );
};

export default Dashboard;
