import React from "react";
import { ScrollView, StyleSheet, ToastAndroid } from "react-native";
import { Card, Paragraph } from "react-native-paper";
import Icon from "react-native-vector-icons/MaterialCommunityIcons";
import { GroupCollectionItem } from "../../../api/models/groupCollectionItem";

const styles = StyleSheet.create({
  card: {
    margin: 10,
  },
  icon: {
    marginRight: 10,
  },
});

interface GroupCollectionProps {
  items: Array<GroupCollectionItem>;
}

const GroupCollection: React.FC<GroupCollectionProps> = ({ items }) => {
  return (
    <ScrollView>
      {items.map((item, index) => {
        return (
          <Card style={styles.card} key={index}>
            <Card.Title title={item.name} />
            <Card.Content>
              <Paragraph>
                <Icon
                  name="account-group"
                  size={20}
                  color="gray"
                  onPress={() =>
                    ToastAndroid.show("Members", ToastAndroid.SHORT)
                  }
                />
                {item.userCount}
                <Icon
                  style={styles.icon}
                  name="account"
                  size={20}
                  color="gray"
                  onPress={() => ToastAndroid.show("Owner", ToastAndroid.SHORT)}
                />
                {item.ownerUsername}
              </Paragraph>
            </Card.Content>
          </Card>
        );
      })}
    </ScrollView>
  );
};

export default GroupCollection;
