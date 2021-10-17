// eslint-disable-next-line no-use-before-define
import React from "react";
import { StyleSheet, View } from "react-native";
import { Appbar, BottomNavigation, Provider } from "react-native-paper";
import Dashboard from "./bottom/Dashboard";
import Profile from "./bottom/Profile";
import Groups from "./bottom/Groups";
import { NavigationProp } from "@react-navigation/native";

const styles = StyleSheet.create({
  bar: {
    backgroundColor: "#fff",
  },
  appbar: {
    backgroundColor: "#fff",
  },
});

interface HomeProps {
  navigation: NavigationProp<any>;
}

const Home: React.FC<HomeProps> = ({ navigation }) => {
  const [index, setIndex] = React.useState(0);
  const [routes] = React.useState([
    { key: "dashboard", title: "Dashboard", icon: "view-dashboard" },
    { key: "groups", title: "Groups", icon: "account-group" },
    { key: "profile", title: "Profile", icon: "account" },
  ]);

  const renderScene = BottomNavigation.SceneMap({
    dashboard: Dashboard,
    groups: Groups({ navigation: navigation }),
    profile: Profile,
  });

  return (
    <Provider>
      <Appbar.Header style={styles.appbar}>
        <Appbar.Content title={routes[index].title} />
      </Appbar.Header>
      <BottomNavigation
        navigationState={{ index, routes }}
        activeColor="blue"
        barStyle={styles.bar}
        onIndexChange={setIndex}
        renderScene={renderScene}
      />
    </Provider>
  );
};

export default Home;
