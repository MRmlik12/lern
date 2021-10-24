import React, { useEffect } from "react";
import { ToastAndroid, View } from "react-native";
import { ActivityIndicator, Appbar, Provider } from "react-native-paper";
import CreateSetFAB from "../../../components/home/dashboard/CreateSetFAB";
import { MaterialBottomTabNavigationProp } from "@react-navigation/material-bottom-tabs/lib/typescript/src/types";
import SetsCollection from "../../../components/home/dashboard/SetsCollection";
import {
  getLatestSet,
  getTextFromImage,
  getUserSetCollection,
} from "../../../api/apiClient";
import { SetCollectionResponse } from "../../../api/models/setCollectionResponse";
import { getPhoto } from "../../../utils/imagePickerUtil";
import i18n from "i18n-js";

interface DashboardProps {
  navigation: MaterialBottomTabNavigationProp<any>;
}

const Dashboard: React.FC<DashboardProps> = ({ navigation }) => {
  const [userSetCollection, setUserSetCollection] = React.useState<
    Array<SetCollectionResponse>
  >([]);
  const [latestAdded, setLatestAdded] = React.useState<
    Array<SetCollectionResponse>
  >([]);
  const [isLoading, setIsLoading] = React.useState(false);
  let [page, setPage] = React.useState(1);

  const getSetCollection = async () => {
    const sets = await getUserSetCollection(page);
    const latestSets = await getLatestSet();
    const concatSets = userSetCollection.concat(sets);

    setUserSetCollection(concatSets);
    setLatestAdded(latestSets);

    setIsLoading(false);
    setPage(page++);
  };

  const handleReadImageText = async () => {
    const image = await getPhoto();
    if (image?.cancelled) return;

    ToastAndroid.show(
      "This operation may take 30s, please be patient",
      ToastAndroid.LONG
    );
    const response = await getTextFromImage(image?.base64!);

    if (response) {
      console.log(response, "------");
      navigation.navigate("CreateSet", {
        phrases: response,
      });
      return;
    }

    ToastAndroid.show("Error", ToastAndroid.SHORT);
  };

  useEffect(() => {
    getSetCollection().catch((err) => console.log(err));
  }, []);

  return (
    <Provider>
      <Appbar.Header style={{ backgroundColor: "#fff" }}>
        <Appbar.Content title={i18n.t("dashboard")} />
        <Appbar.Action icon="image-plus" onPress={handleReadImageText} />
      </Appbar.Header>
      <View>
        {isLoading ? (
          <ActivityIndicator animating={isLoading} />
        ) : (
          <SetsCollection
            navigation={navigation}
            title={i18n.t("yourSets")}
            items={userSetCollection}
          />
        )}
        {isLoading ? (
          <ActivityIndicator animating={isLoading} />
        ) : (
          <SetsCollection
            navigation={navigation}
            title={i18n.t("latestAdded")}
            items={latestAdded}
          />
        )}
      </View>
      <CreateSetFAB navigation={navigation} />
    </Provider>
  );
};

export default Dashboard;
