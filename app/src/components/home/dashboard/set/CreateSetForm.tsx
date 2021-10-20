import React, { useEffect } from "react";
import { View, StyleSheet } from "react-native";
import { Button, Divider, List, TextInput } from "react-native-paper";
import { isFalsy } from "utility-types";
import { createSet } from "../../../../api/apiClient";
import { MaterialBottomTabNavigationProp } from "@react-navigation/material-bottom-tabs/lib/typescript/src/types";

type Phrases = {
  primaryWord: string;
  translatedWord: string;
};

interface CreateSetFormProps {
  navigation: MaterialBottomTabNavigationProp<any>;
}

interface PhrasesProps {
  phrases: Array<Phrases>;
}

const styles = StyleSheet.create({
  phraseView: {
    flex: 1,
    flexDirection: "row",
    marginVertical: 40,
    alignSelf: "center",
  },
  phraseCreateButton: {
    alignSelf: "flex-end",
  },
  phraseInputs: {
    width: "40%",
    marginLeft: 20,
    marginRight: 20,
  },
});

// eslint-disable-next-line no-redeclare
const Phrases: React.FC<PhrasesProps> = ({ phrases }) => {
  return (
    <View>
      {phrases.map((item, index) => {
        return (
          <View style={styles.phraseView} key={index}>
            <Divider />
            <TextInput
              style={styles.phraseInputs}
              label="Primary phrase"
              value={item.primaryWord}
              mode="outlined"
              onChangeText={(text) => (item.primaryWord = text)}
            />
            <TextInput
              style={styles.phraseInputs}
              label="Secondary phrase"
              value={item.translatedWord}
              mode="outlined"
              onChangeText={(text) => (item.translatedWord = text)}
            />
          </View>
        );
      })}
    </View>
  );
};

const CreateSetForm: React.FC<CreateSetFormProps> = ({ navigation }) => {
  const [title, setTitle] = React.useState("");
  const [primaryLanguage, setPrimaryLanguage] = React.useState("");
  const [tags, setTags] = React.useState("");
  const [phrases, setPhrases] = React.useState<Array<Phrases>>([
    {
      primaryWord: "",
      translatedWord: "",
    },
  ]);

  let phrase = Phrases({
    phrases: phrases,
  });

  const handleCreateSet = async () => {
    if (isFalsy(title)) return;
    if (isFalsy(primaryLanguage)) return;
    if (isFalsy(tags)) return;

    const response = await createSet(
      title,
      primaryLanguage,
      tags.split(" "),
      phrases
    );

    if (!response) {
      return;
    }

    navigation.reset({
      index: 0,
      routes: [{ name: "Home" }],
    });
  };

  useEffect(() => {
    phrase = Phrases({
      phrases: phrases,
    });
  }, [phrases]);

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
        label="Tags"
        placeholder="foo bar"
        value={tags}
        onChangeText={(text) => setTags(text)}
      />
      <List.Section>
        <View>
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
            }}
          >
            Add
          </Button>
        </View>
        {phrase}
      </List.Section>
      <Button mode="contained" onPress={handleCreateSet}>
        Create
      </Button>
    </View>
  );
};

export default CreateSetForm;
