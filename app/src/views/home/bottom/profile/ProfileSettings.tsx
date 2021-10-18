import React from "react";
import { ScrollView, View } from "react-native";
import BasicInformation from "../../../../components/home/profile/settings/BasicInformation";
import { Appbar } from "react-native-paper";
import PasswordChange from "../../../../components/home/profile/settings/PasswordChange";
import DeleteAccount from "../../../../components/home/profile/settings/DeleteAccount";
import { MaterialBottomTabNavigationProp } from "@react-navigation/material-bottom-tabs/lib/typescript/src/types";

interface ProfileSettingsProps {
  navigation: MaterialBottomTabNavigationProp<any>;
}

const ProfileSettings: React.FC<ProfileSettingsProps> = ({ navigation }) => {
  return (
    <View>
      <Appbar.Header style={{ backgroundColor: "#fff" }}>
        <Appbar.BackAction onPress={() => navigation.goBack()} />
        <Appbar.Content title="Profile Settings" />
      </Appbar.Header>
      <ScrollView>
        <BasicInformation />
        <PasswordChange navigation={navigation} />
        <DeleteAccount />
      </ScrollView>
    </View>
  );
};

export default ProfileSettings;
