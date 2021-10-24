import React from "react";
import { View, StyleSheet } from "react-native";
import { Card, List, Text } from "react-native-paper";
import Constants from "expo-constants";
import i18n from "i18n-js";

const styles = StyleSheet.create({
  card: {
    margin: 5,
  },
});

const ProductInfo: React.FC = () => {
  return (
    <View>
      <Card style={styles.card}>
        <Card.Content>
          <>
            <List.Item
              title={i18n.t("version")}
              left={(props) => <List.Icon {...props} icon="information" />}
              description={<Text>{Constants.manifest?.version}</Text>}
            />
            <List.Item
              title={i18n.t("expoVersion")}
              left={(props) => <List.Icon {...props} icon="engine" />}
              description={<Text>{Constants.expoVersion}</Text>}
            />
            <List.Item
              title={i18n.t("deviceName")}
              left={(props) => <List.Icon {...props} icon="cellphone" />}
              description={<Text>{Constants.deviceName}</Text>}
            />
          </>
        </Card.Content>
      </Card>
    </View>
  );
};

export default ProductInfo;
