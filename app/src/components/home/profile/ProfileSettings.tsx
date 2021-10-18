import React from "react";
import { FlatList, StyleSheet } from "react-native";
import { Card, List } from "react-native-paper";

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

const ProfileSettings: React.FC = () => {
  return (
    <Card style={styles.card}>
      <Card.Content>
        <>
          <List.Item
            title="User settings"
            left={(props) => <List.Icon {...props} icon="account-outline" />}
            onPress={() => console.log("Hello")}
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
            onPress={() => console.log("Hello")}
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

export default ProfileSettings;
