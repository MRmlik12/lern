import React from "react";
import { View, StyleSheet } from "react-native";
import { Button, Divider, List, TextInput } from "react-native-paper";

type Phrases = {
  primaryWord: string;
  translatedWord: string;
};

const styles = StyleSheet.create({
  phraseTitleSection: {},
  phraseCreateButton: {
    alignSelf: "flex-end",
  },
});

const CreateSetForm = () => {
  const [title, setTitle] = React.useState("");
  const [primaryLanguage, setPrimaryLanguage] = React.useState("");
  const [secondaryLanguage, setSecondaryLanguage] = React.useState("");
  const [phrases, setPhrases] = React.useState<Array<Phrases>>([
    {
      primaryWord: "",
      translatedWord: "",
    },
  ]);

  return (
    <View>
      <TextInput
        label="Title"
        value={title}
        onChangeText={(text) => setTitle(text)}
      />
      <TextInput
        label="Primary language"
        value={primaryLanguage}
        onChangeText={(text) => setPrimaryLanguage(text)}
      />
      <TextInput
        label="Secondary language"
        value={secondaryLanguage}
        onChangeText={(text) => setSecondaryLanguage(text)}
      />
      <List.Section>
        <View style={styles.phraseTitleSection}>
          <List.Subheader>Phrases</List.Subheader>
          <Button
            style={styles.phraseCreateButton}
            icon="plus-circle-outline"
            onPress={() => {
              phrases.push({
                primaryWord: "",
                translatedWord: "",
              });
              setPhrases(phrases);
              console.log(phrases.length);
            }}
          />
        </View>
        {phrases.map((item, index) => {
          return (
            <View key={item.translatedWord}>
              <Divider />
              <TextInput
                label="Primary phrase"
                value={item.primaryWord}
                onChangeText={(text) => (item.primaryWord = text)}
              />
              <TextInput
                label="Secondary phrase"
                value={item.translatedWord}
                onChangeText={(text) => (item.translatedWord = text)}
              />
              <Divider />
            </View>
          );
        })}
      </List.Section>
    </View>
  );
};

export default CreateSetForm;
