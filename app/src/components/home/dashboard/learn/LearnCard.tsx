import React from "react";
import { StyleSheet, View } from "react-native";
import { Button, Paragraph, Text } from "react-native-paper";
import CardStack, { Card } from "react-native-card-stack-swiper";
import { SetItems } from "../../../../api/models/setItems";
import { MaterialBottomTabNavigationProp } from "@react-navigation/material-bottom-tabs/lib/typescript/src/types";
import HiddenText from "./HiddenText";

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
  text: {
    fontSize: 22,
  },
  label: {
    lineHeight: 150,
    textAlign: "center",
    fontSize: 55,
    fontFamily: "System",
    backgroundColor: "transparent",
  },
  button: {
    marginBottom: "10%",
  },
});

interface LearnCardProps {
  navigation: MaterialBottomTabNavigationProp<any>;
  items: Array<SetItems>;
}

const LearnCard: React.FC<LearnCardProps> = ({ items, navigation }) => {
  const [points, setPoints] = React.useState(0);

  const calcPercent = (): number => Math.round((100 * points) / items.length);
  const onBackToDashboardPressed = () => navigation.goBack();

  return (
    <CardStack
      onSwipedRight={() => setPoints(points + 1)}
      renderNoMoreCards={() => (
        <View>
          <Text style={styles.label}>
            {points}/{items.length} {calcPercent()}%
          </Text>
          <Button mode="contained" onPress={onBackToDashboardPressed}>
            Back to dashboard
          </Button>
        </View>
      )}
      style={styles.content}
    >
      {items.map((item, index) => {
        return (
          <Card key={index} style={styles.card}>
            <View>
              <View style={styles.content}>
                <Paragraph style={styles.label}>{item.primaryWord}</Paragraph>
                <HiddenText textToHide={item.translatedWord} />
              </View>
            </View>
          </Card>
        );
      })}
    </CardStack>
  );
};

export default LearnCard;
