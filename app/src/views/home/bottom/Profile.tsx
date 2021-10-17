import React from "react";
import { ScrollView } from "react-native";
import ProfileInfo from "../../../components/home/profile/ProfileInfo";
import ProfileSettings from "../../../components/home/profile/ProfileSettings";

const Profile: React.FC = () => {
  return (
    <ScrollView>
      <ProfileInfo />
      <ProfileSettings />
    </ScrollView>
  );
};

export default Profile;
