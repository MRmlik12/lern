// eslint-disable-next-line no-use-before-define
import React from "react";
import { Provider } from "react-native-paper";
import Dashboard from "./bottom/Dashboard";
import Profile from "./bottom/Profile";
import Groups from "./bottom/Groups";
import { NavigationProp } from "@react-navigation/native";
import { createMaterialBottomTabNavigator } from "@react-navigation/material-bottom-tabs";
import MaterialCommunityIcons from "react-native-vector-icons/MaterialCommunityIcons";

interface HomeProps {
  navigation: NavigationProp<any>;
}

const Tab = createMaterialBottomTabNavigator();

const Home: React.FC<HomeProps> = ({ navigation }) => {
  return (
    <Provider>
      <Tab.Navigator
        initialRouteName="Home"
        activeColor="blue"
        barStyle={{ backgroundColor: "#fff" }}
      >
        <Tab.Screen
          name="dashboard"
          component={Dashboard}
          options={{
            tabBarLabel: "Dashboard",
            tabBarIcon: ({ color }) => (
              <MaterialCommunityIcons
                name="view-dashboard"
                color={color}
                size={26}
              />
            ),
          }}
        />
        <Tab.Screen
          name="groups"
          component={Groups}
          options={{
            tabBarLabel: "Groups",
            tabBarIcon: ({ color }) => (
              <MaterialCommunityIcons
                name="account-group"
                color={color}
                size={26}
              />
            ),
          }}
        />
        <Tab.Screen
          name="profile"
          component={Profile}
          options={{
            tabBarLabel: "Profile",
            tabBarIcon: ({ color }) => (
              <MaterialCommunityIcons name="account" color={color} size={26} />
            ),
          }}
        />
      </Tab.Navigator>
    </Provider>
  );
};

export default Home;
