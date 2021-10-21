import React from "react";
import { View } from "react-native";
import { Appbar } from "react-native-paper";
import { MaterialBottomTabNavigationProp } from "@react-navigation/material-bottom-tabs/lib/typescript/src/types";
import { MaterialBottomTabScreenProps } from "@react-navigation/material-bottom-tabs/src/types";

interface SetLearnProps {
  navigation: MaterialBottomTabScreenProps<any>;
}

const SetLearn: React.FC<SetLearnProps> = ({ navigation }) => {
  console.log(navigation.route.params?.setId);

  return (
    <View>
      <Appbar.Header style={{ backgroundColor: "#fff" }}>
        <Appbar.BackAction onPress={() => navigation.navigation.goBack()} />
        <Appbar.Content title="Learning" />
      </Appbar.Header>
    </View>
  );
};

export default SetLearn;
