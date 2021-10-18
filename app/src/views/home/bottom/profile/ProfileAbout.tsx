import React from "react";
import { MaterialBottomTabNavigationProp } from "@react-navigation/material-bottom-tabs/lib/typescript/src/types";
import { ScrollView, View } from "react-native";
import { Appbar } from "react-native-paper";
import ProductInfo from "../../../../components/home/profile/about/ProductInfo";

interface ProfileAboutProps {
  navigation: MaterialBottomTabNavigationProp<any>;
}

const ProfileAbout: React.FC<ProfileAboutProps> = ({ navigation }) => {
  return (
    <View>
      <Appbar.Header style={{ backgroundColor: "#fff" }}>
        <Appbar.BackAction onPress={() => navigation.goBack()} />
        <Appbar.Content title="About" />
      </Appbar.Header>
      <ScrollView>
        <ProductInfo />
      </ScrollView>
    </View>
  );
};

export default ProfileAbout;
