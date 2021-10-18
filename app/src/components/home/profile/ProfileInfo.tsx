import React from "react";
import { StyleSheet, View } from "react-native";
import { Avatar, Caption, Card, Headline } from "react-native-paper";
import { FlatGrid } from "react-native-super-grid";

const styles = StyleSheet.create({
  card: {
    width: "95%",
    margin: 5,
    alignSelf: "center",
  },
  title: {
    textAlign: "center",
    padding: 10,
    fontSize: 30,
  },
  avatar: {
    alignSelf: "center",
  },
  summary: {
    flexDirection: "row",
    flexWrap: "wrap",
    textAlign: "center",
  },
  summaryText: {
    justifyContent: "space-between",
    fontSize: 18,
  },
});

const ProfileInfo: React.FC = () => {
  const [items] = React.useState([
    { name: "Groups", value: 0 },
    { name: "Sets", value: 0 },
    { name: "Created at", value: "2021/10/17" },
  ]);

  return (
    <Card style={styles.card}>
      <Card.Content>
        <Avatar.Image
          style={styles.avatar}
          size={160}
          source={{
            uri: "https://earncashto.com/wp-content/uploads/2021/06/495-4952535_create-digital-profile-icon-blue-user-profile-icon.png",
          }}
        />
        <Headline style={styles.title}>Example</Headline>
        <FlatGrid
          itemDimension={120}
          data={items}
          fixed={true}
          renderItem={(items) => (
            <View>
              <Caption style={styles.summaryText}>
                <Headline>{items.item.name}:</Headline> {items.item.value}
              </Caption>
            </View>
          )}
        />
      </Card.Content>
    </Card>
  );
};

export default ProfileInfo;
