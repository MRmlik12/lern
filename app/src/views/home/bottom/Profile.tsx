import React from "react";
import { ScrollView, View } from "react-native";
import ProfileInfo from "../../../components/home/profile/ProfileInfo";
import { Appbar } from "react-native-paper";
import { MaterialBottomTabNavigationProp } from "@react-navigation/material-bottom-tabs/lib/typescript/src/types";
import ProfileMore from "../../../components/home/profile/ProfileMore";

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
        <ProfileMore navigation={navigation} />
      </ScrollView>
    </View>
  );
};

export default Profile;
