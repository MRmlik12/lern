import React from "react";
import { StyleSheet, ScrollView, View } from "react-native";
import { Card, Paragraph, Title } from "react-native-paper";
import { SetCollectionResponse } from "../../../api/models/setCollectionResponse";
import { MaterialBottomTabNavigationProp } from "@react-navigation/material-bottom-tabs/lib/typescript/src/types";

const styles = StyleSheet.create({
  container: {
    margin: 10,
  },
  card: {
    marginRight: 5,
    marginLeft: 5,
    width: "15%",
  },
});

interface SetsCollectionProps {
  navigation: MaterialBottomTabNavigationProp<any>;
  title: string;
  items: Array<SetCollectionResponse>;
}

const SetsCollection: React.FC<SetsCollectionProps> = ({
  navigation,
  title,
  items,
}) => {
  const onCardPress = (item: SetCollectionResponse) => {
    navigation.navigate("LearnMode", {
      title: item.title,
      setId: item.id,
    });
  };

  return (
    <View style={styles.container}>
      <Title>{title}</Title>
      <ScrollView horizontal={true} showsHorizontalScrollIndicator={false}>
        {items.map((item, index) => {
          return (
            <Card
              style={styles.card}
              key={index}
              onPress={() => onCardPress(item)}
            >
              <Card.Title title={item.title} />
              <Card.Content>
                <Paragraph>{item.language}</Paragraph>
                <Paragraph>{item.tags.join(" ")}</Paragraph>
                <Paragraph>{item.userName}</Paragraph>
              </Card.Content>
            </Card>
          );
        })}
      </ScrollView>
    </View>
  );
};

export default SetsCollection;
