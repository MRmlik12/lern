// eslint-disable-next-line no-use-before-define
import React, { ReactElement } from "react";
import Login from "./views/Login";
import { NavigationContainer } from "@react-navigation/native";
import { DefaultTheme, Provider as PaperProvider } from "react-native-paper";
import Register from "./views/Register";
import Home from "./views/home/Home";
import { RecoilRoot } from "recoil";
import { createNativeStackNavigator } from "@react-navigation/native-stack";
import ProfileSettings from "./views/home/bottom/profile/ProfileSettings";
import ProfileAbout from "./views/home/bottom/profile/ProfileAbout";

const theme = {
  ...DefaultTheme,
  colors: {
    ...DefaultTheme.colors,
    primary: "#4fc3f7",
    accent: "#4fc3f7",
  },
};

export default function App(): ReactElement {
  const Stack = createNativeStackNavigator();

  return (
    <NavigationContainer>
      <RecoilRoot>
        <PaperProvider theme={theme}>
          <Stack.Navigator initialRouteName="Home">
            <Stack.Screen
              name="Home"
              component={Home}
              options={{ title: "Home", headerShown: false }}
            />
            <Stack.Screen
              name="Login"
              component={Login}
              options={{ title: "Login", headerShown: false }}
            />
            <Stack.Screen
              name="Register"
              component={Register}
              options={{ title: "Register", headerShown: false }}
            />
            <Stack.Screen
              name="ProfileSettings"
              component={ProfileSettings}
              options={{ title: "ProfileSettings", headerShown: false }}
            />
            <Stack.Screen
              name="ProfileAbout"
              component={ProfileAbout}
              options={{ title: "ProfileAbout", headerShown: false }}
            />
          </Stack.Navigator>
        </PaperProvider>
      </RecoilRoot>
    </NavigationContainer>
  );
}
