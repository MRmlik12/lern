import React from "react";
import { StyleSheet, View } from "react-native";
import { Button, Paragraph } from "react-native-paper";

const styles = StyleSheet.create({
  label: {
    lineHeight: 150,
    textAlign: "center",
    fontSize: 20,
    fontFamily: "System",
    backgroundColor: "transparent",
  },
  button: {
    marginBottom: "10%",
  },
});

interface HiddenTextProps {
  textToHide: string;
}

const HiddenText: React.FC<HiddenTextProps> = ({ textToHide }) => {
  const [hidden, setHidden] = React.useState(true);

  return (
    <View>
      <Paragraph style={[styles.label]}>{hidden ? null : textToHide}</Paragraph>
      {hidden ? (
        <Button
          style={styles.button}
          mode="outlined"
          onPress={() => {
            setHidden(false);
          }}
        >
          Show word
        </Button>
      ) : null}
    </View>
  );
};

export default HiddenText;
