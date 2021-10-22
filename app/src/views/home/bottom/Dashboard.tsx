import React, { useEffect } from "react";
import { View } from "react-native";
import { ActivityIndicator, Appbar, Provider } from "react-native-paper";
import CreateSetFAB from "../../../components/home/dashboard/CreateSetFAB";
import { MaterialBottomTabNavigationProp } from "@react-navigation/material-bottom-tabs/lib/typescript/src/types";
import SetsCollection from "../../../components/home/dashboard/SetsCollection";
import { getUserSetCollection } from "../../../api/apiClient";
import { SetCollectionResponse } from "../../../api/models/setCollectionResponse";

interface DashboardProps {
  navigation: MaterialBottomTabNavigationProp<any>;
}

const Dashboard: React.FC<DashboardProps> = ({ navigation }) => {
  const [userSetCollection, setUserSetCollection] = React.useState<
    Array<SetCollectionResponse>
  >([]);
  const [isLoading, setIsLoading] = React.useState(false);
  let [page, setPage] = React.useState(1);

  const getSetCollection = async () => {
    const sets = await getUserSetCollection(page);
    const concatSets = userSetCollection.concat(sets);
    setUserSetCollection(concatSets);
    setIsLoading(false);
    setPage(page++);
  };

  useEffect(() => {
    getSetCollection().catch((err) => console.log(err));
  }, []);

  return (
    <Provider>
      <Appbar.Header style={{ backgroundColor: "#fff" }}>
        <Appbar.Content title="Dashboard" />
      </Appbar.Header>
      <View>
        <ActivityIndicator animating={isLoading} />
        {isLoading ? null : (
          <SetsCollection title="Your Sets" items={userSetCollection} />
        )}
      </View>
      <CreateSetFAB navigation={navigation} />
    </Provider>
  );
};

export default Dashboard;
