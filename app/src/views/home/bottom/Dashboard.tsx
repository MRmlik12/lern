import React from "react";
import { View } from "react-native";
import { Appbar, Provider } from "react-native-paper";
import CreateSetFAB from "../../../components/home/dashboard/CreateSetFAB";
import { MaterialBottomTabNavigationProp } from "@react-navigation/material-bottom-tabs/lib/typescript/src/types";
import SetsCollection from "../../../components/home/dashboard/SetsCollection";

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
        <SetsCollection title="Your Sets" navigation={navigation} />
      </View>
      <CreateSetFAB navigation={navigation} />
    </Provider>
  );
};

export default Dashboard;
