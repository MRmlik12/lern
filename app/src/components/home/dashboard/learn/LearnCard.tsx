import React from "react";
import { StyleSheet, View } from "react-native";
import { Card, Paragraph } from "react-native-paper";
import CardStack from "react-native-card-stack-swiper";
import { SetItems } from "../../../../api/models/setItems";

const styles = StyleSheet.create({
  container: {
    flex: 1,
    flexDirection: "column",
    backgroundColor: "#f2f2f2",
  },
  content: {
    alignItems: "center",
    justifyContent: "flex-start",
  },
  card: {
    width: 320,
    height: 470,
    backgroundColor: "#fff",
    borderRadius: 5,
    shadowColor: "rgba(0,0,0,0.5)",
    shadowOffset: {
      width: 0,
      height: 1,
    },
    shadowOpacity: 0.5,
  },
});

interface LearnCardProps {
  items: Array<SetItems>;
}

const LearnCard: React.FC<LearnCardProps> = ({ items }) => {
  return (
    <CardStack style={styles.content}>
      {items.map((item, index) => {
        return (
          <Card key={index} style={styles.card}>
            <View style={styles.content}>
              <Paragraph style={styles.content}>{item.primaryWord}</Paragraph>
              <Paragraph style={styles.content}>
                {item.translatedWord}
              </Paragraph>
            </View>
          </Card>
        );
      })}
    </CardStack>
  );
};

export default LearnCard;
