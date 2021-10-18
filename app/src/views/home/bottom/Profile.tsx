import React from "react";
import { ScrollView, View } from "react-native";
import ProfileInfo from "../../../components/home/profile/ProfileInfo";
import ProfileSettings from "../../../components/home/profile/ProfileSettings";
import { Appbar, Portal } from "react-native-paper";
import { MaterialBottomTabNavigationProp } from "@react-navigation/material-bottom-tabs/lib/typescript/src/types";

interface ProfileProps {
  navigation: MaterialBottomTabNavigationProp<any>;
}

const Profile: React.FC<ProfileProps> = ({ navigation }) => {
  return (
    <View>
      <Appbar.Header style={{ backgroundColor: "#fff" }}>
        <Appbar.Content title="Profile" />
      </Appbar.Header>
      <ScrollView>
        <ProfileInfo />
        <ProfileSettings />
      </ScrollView>
    </View>
  );
};

export default Profile;
