import React, { useEffect } from "react";
import { MaterialBottomTabNavigationProp } from "@react-navigation/material-bottom-tabs/lib/typescript/src/types";
import { ActivityIndicator, Appbar } from "react-native-paper";
import { View, StyleSheet } from "react-native";
import { getSet } from "../../../../api/apiClient";
import { GetSetResponse } from "../../../../api/models/getSetResponse";
import LearnCard from "../../../../components/home/dashboard/learn/LearnCard";
import { RouteProp } from "@react-navigation/native";

interface LearnModeProps {
  navigation: MaterialBottomTabNavigationProp<any>;
  route: RouteProp<{ params: { setId: ""; title: "" } }, "params">;
}
const styles = StyleSheet.create({
  container: {},
  indicator: {
    position: "absolute",
    bottom: 0,
    top: 0,
    left: 0,
    right: 0,
  },
});

const LearnMode: React.FC<LearnModeProps> = ({ navigation, route }) => {
  const [setInfo, setSetInfo] = React.useState<GetSetResponse>();
  const [isLoading, setIsLoading] = React.useState(true);

  const getSetInformation = async () => {
    const set = await getSet(route.params.setId);
    setSetInfo(set);
    setIsLoading(false);
  };

  useEffect(() => {
    getSetInformation().catch((err) => console.log(err));
  }, []);

  return (
    <View style={styles.container}>
      <Appbar.Header style={{ backgroundColor: "#fff" }}>
        <Appbar.BackAction onPress={() => navigation.goBack()} />
        <Appbar.Content title={route.params.title} />
      </Appbar.Header>
      <View>
        <ActivityIndicator animating={isLoading} />
        {isLoading ? null : <LearnCard items={setInfo?.items!} />}
      </View>
    </View>
  );
};

export default LearnMode;
