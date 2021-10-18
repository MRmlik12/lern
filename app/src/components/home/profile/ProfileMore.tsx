import React from "react";
import { StyleSheet } from "react-native";
import { Card, List } from "react-native-paper";
import { MaterialBottomTabNavigationProp } from "@react-navigation/material-bottom-tabs/lib/typescript/src/types";

const styles = StyleSheet.create({
  card: {
    width: "95%",
    margin: 5,
    alignSelf: "center",
  },
  logout: {
    color: "red",
  },
});

interface ProfileMoreProps {
  navigation: MaterialBottomTabNavigationProp<any>;
}

const ProfileMore: React.FC<ProfileMoreProps> = ({ navigation }) => {
  return (
    <Card style={styles.card}>
      <Card.Content>
        <>
          <List.Item
            title="User settings"
            left={(props) => <List.Icon {...props} icon="account-outline" />}
            onPress={() => navigation.navigate("ProfileSettings")}
          />
          <List.Item
            title="App settings"
            left={(props) => <List.Icon {...props} icon="cog-outline" />}
            onPress={() => console.log("Hello")}
          />
          <List.Item
            title="About"
            left={(props) => (
              <List.Icon {...props} icon="information-outline" />
            )}
            onPress={() => navigation.navigate("ProfileAbout")}
          />
          <List.Item
            title="Log out"
            left={(props) => <List.Icon {...props} icon="exit-to-app" />}
            onPress={() => console.log("Hello")}
          />
        </>
      </Card.Content>
    </Card>
  );
};

export default ProfileMore;
