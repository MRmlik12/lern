import React, { useEffect } from "react";
import { ScrollView, View } from "react-native";
import BasicInformation from "../../../../components/home/profile/settings/BasicInformation";
import { ActivityIndicator, Appbar } from "react-native-paper";
import PasswordChange from "../../../../components/home/profile/settings/PasswordChange";
import DeleteAccount from "../../../../components/home/profile/settings/DeleteAccount";
import { MaterialBottomTabNavigationProp } from "@react-navigation/material-bottom-tabs/lib/typescript/src/types";
import { UserInformationResponse } from "../../../../api/models/userInformationResponse";
import { userInfo } from "../../../../api/apiClient";

interface ProfileSettingsProps {
  navigation: MaterialBottomTabNavigationProp<any>;
}

const ProfileSettings: React.FC<ProfileSettingsProps> = ({ navigation }) => {
  const [profile, setProfile] = React.useState<UserInformationResponse>();
  const [isLoading, setIsLoading] = React.useState(true);

  const getProfile = async () => {
    const profile = await userInfo();
    setProfile(profile);
    setIsLoading(false);
  };

  useEffect(() => {
    getProfile().catch((err) => console.log(err));
  }, []);

  return (
    <View>
      <Appbar.Header style={{ backgroundColor: "#fff" }}>
        <Appbar.BackAction onPress={() => navigation.goBack()} />
        <Appbar.Content title="Profile Settings" />
      </Appbar.Header>
      <ScrollView>
        {isLoading ? (
          <ActivityIndicator animating={isLoading} />
        ) : (
          <BasicInformation name={profile?.name!} />
        )}
        <PasswordChange navigation={navigation} />
        <DeleteAccount navigation={navigation} />
      </ScrollView>
    </View>
  );
};

export default ProfileSettings;
