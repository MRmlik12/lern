import React from "react";
import { MaterialBottomTabNavigationProp } from "@react-navigation/material-bottom-tabs/lib/typescript/src/types";
import { ScrollView, View } from "react-native";
import { Appbar } from "react-native-paper";
import ProductInfo from "../../../../components/home/profile/about/ProductInfo";
import i18n from "i18n-js";

interface ProfileAboutProps {
  navigation: MaterialBottomTabNavigationProp<any>;
}

const ProfileAbout: React.FC<ProfileAboutProps> = ({ navigation }) => {
  return (
    <View>
      <Appbar.Header style={{ backgroundColor: "#fff" }}>
        <Appbar.BackAction onPress={() => navigation.goBack()} />
        <Appbar.Content title={i18n.t("about")} />
      </Appbar.Header>
      <ScrollView>
        <ProductInfo />
      </ScrollView>
    </View>
  );
};

export default ProfileAbout;
