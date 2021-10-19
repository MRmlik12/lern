import React from "react";
import { ScrollView, View } from "react-native";
import { Appbar } from "react-native-paper";
import { MaterialBottomTabNavigationProp } from "@react-navigation/material-bottom-tabs/lib/typescript/src/types";
import CreateSetForm from "./CreateSetForm";

interface CreateSetProps {
  navigation: MaterialBottomTabNavigationProp<any>;
}

const CreateSet: React.FC<CreateSetProps> = ({ navigation }) => {
  return (
    <View>
      <Appbar.Header style={{ backgroundColor: "#fff" }}>
        <Appbar.BackAction onPress={() => navigation.goBack()} />
        <Appbar.Content title="Create set" />
      </Appbar.Header>
      <ScrollView>
        <CreateSetForm />
      </ScrollView>
    </View>
  );
};

export default CreateSet;
