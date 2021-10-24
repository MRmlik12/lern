import React from "react";
import { StyleSheet } from "react-native";
import { Card, List } from "react-native-paper";
import { MaterialBottomTabNavigationProp } from "@react-navigation/material-bottom-tabs/lib/typescript/src/types";
import { clearTokens } from "../../../utils/tokenUtil";
import i18n from "i18n-js";

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
  const handleLogout = async () => {
    await clearTokens();
    navigation.reset({
      index: 0,
      routes: [{ name: "Home" }],
    });
  };

  return (
    <Card style={styles.card}>
      <Card.Content>
        <>
          <List.Item
            title={i18n.t("profileSettings")}
            left={(props) => <List.Icon {...props} icon="account-outline" />}
            onPress={() => navigation.navigate("ProfileSettings")}
          />
          <List.Item
            title={i18n.t("about")}
            left={(props) => (
              <List.Icon {...props} icon="information-outline" />
            )}
            onPress={() => navigation.navigate("ProfileAbout")}
          />
          <List.Item
            title={i18n.t("logout")}
            left={(props) => <List.Icon {...props} icon="exit-to-app" />}
            onPress={handleLogout}
          />
        </>
      </Card.Content>
    </Card>
  );
};

export default ProfileMore;
