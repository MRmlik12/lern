import React, { useEffect } from "react";
import { StyleSheet, View } from "react-native";
import {
  ActivityIndicator,
  Avatar,
  Caption,
  Card,
  Headline,
} from "react-native-paper";
import { FlatGrid } from "react-native-super-grid";
import { userInfo } from "../../../api/apiClient";
import i18n from "i18n-js";

const styles = StyleSheet.create({
  card: {
    width: "95%",
    margin: 10,
    alignSelf: "center",
  },
  title: {
    textAlign: "center",
    padding: 5,
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
  const [avatarUrl, setAvatarUrl] = React.useState("");
  const [username, setUsername] = React.useState("");
  const [items, setItems] = React.useState<any>();
  const [isLoading, setIsLoading] = React.useState(true);

  const getUserInformation = async () => {
    const user = await userInfo();
    setAvatarUrl(user.avatarUrl);
    setUsername(user.name);
    setItems([
      { name: i18n.t("groups"), value: user.groupsCount },
      { name: i18n.t("sets"), value: user.setCount },
    ]);
    setIsLoading(false);
  };

  useEffect(() => {
    getUserInformation().catch((err) => console.log(err));
  }, []);

  return (
    <Card style={styles.card}>
      {isLoading ? (
        <ActivityIndicator animating={isLoading} />
      ) : (
        <Card.Content>
          <Avatar.Image
            style={styles.avatar}
            size={160}
            source={{
              uri: avatarUrl,
            }}
          />
          <Headline style={styles.title}>{username}</Headline>
          <FlatGrid
            itemDimension={120}
            data={items}
            fixed={true}
            renderItem={(items) => (
              <View>
                <Caption style={styles.summaryText}>
                  <Headline style={styles.summaryText}>
                    {items.item.name}:
                  </Headline>{" "}
                  {items.item.value}
                </Caption>
              </View>
            )}
          />
        </Card.Content>
      )}
    </Card>
  );
};

export default ProfileInfo;
