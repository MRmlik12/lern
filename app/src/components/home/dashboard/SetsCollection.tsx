import React from "react";
import {
  StyleSheet,
  ScrollView,
  View,
  NativeSyntheticEvent,
  NativeScrollEvent,
  NativeScrollSize,
  NativeScrollPoint,
} from "react-native";
import { ActivityIndicator, Card, Paragraph, Title } from "react-native-paper";
import { getUserSetCollection } from "../../../api/apiClient";
import { SetCollectionResponse } from "../../../api/models/setCollectionResponse";

const styles = StyleSheet.create({
  container: {
    margin: 10,
  },
  card: {
    marginRight: 5,
    marginLeft: 5,
  },
});

interface SetsCollectionProps {
  title: string;
}

const SetsCollection: React.FC<SetsCollectionProps> = ({ title }) => {
  const [items, setItem] = React.useState<Array<SetCollectionResponse>>([]);
  const [loading, setLoading] = React.useState(true);
  let [page, setPage] = React.useState(1);
  let firstLaunch = true;

  const getSetCollection = async () => {
    const sets = await getUserSetCollection(page);
    const concatSets = items.concat(sets);
    setItem(concatSets);
    setLoading(false);
    setPage(page++);
  };

  const isCloseToBottom = (
    layoutMeasurement: NativeScrollSize,
    contentOffset: NativeScrollPoint,
    contentSize: NativeScrollSize
  ) => {
    const paddingToBottom = 20;
    return (
      layoutMeasurement.height + contentOffset.y >=
      contentSize.height - paddingToBottom
    );
  };

  const onScroll = async (
    nativeEvent: NativeSyntheticEvent<NativeScrollEvent>
  ) => {
    const isReachingEnd = isCloseToBottom(
      nativeEvent.nativeEvent.layoutMeasurement,
      nativeEvent.nativeEvent.contentOffset,
      nativeEvent.nativeEvent.contentSize
    );

    if (isReachingEnd) {
      await getSetCollection();
    }
  };

  const onStart = async () => {
    if (firstLaunch) {
      await getSetCollection();
      firstLaunch = false;
    }
  };

  onStart().catch((err) => console.log(err));

  return (
    <View style={styles.container}>
      <Title>{title}</Title>
      <ActivityIndicator animating={loading} />
      <ScrollView horizontal={true} onScroll={onScroll}>
        {items.map((item, index) => {
          return (
            <Card style={styles.card} key={index}>
              <Card.Title title={item.title} />
              <Card.Content>
                <Paragraph>Language: {item.language}</Paragraph>
                <Paragraph>Tags: {item.tags.join(" ")}</Paragraph>
              </Card.Content>
            </Card>
          );
        })}
      </ScrollView>
    </View>
  );
};

export default SetsCollection;
