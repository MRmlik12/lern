import React from "react";
import { View, StyleSheet, ScrollView } from "react-native";
import { Button, Divider, List, TextInput } from "react-native-paper";
import { isFalsy } from "utility-types";
import { createSet } from "../../../../api/apiClient";
import { MaterialBottomTabNavigationProp } from "@react-navigation/material-bottom-tabs/lib/typescript/src/types";
import Icon from "react-native-vector-icons/MaterialCommunityIcons";

type Phrases = {
  primaryWord: string;
  translatedWord: string;
};

interface CreateSetFormProps {
  navigation: MaterialBottomTabNavigationProp<any>;
}

const styles = StyleSheet.create({
  inputs: {
    margin: 10,
  },
  input: {
    marginTop: 5,
    marginBottom: 5,
  },
  phraseView: {
    flex: 1,
    flexDirection: "row",
    marginVertical: 10,
    alignSelf: "center",
  },
  phraseInputs: {
    width: "40%",
    marginLeft: 20,
    marginRight: 20,
  },
  icon: {
    marginRight: 10,
  },
});

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

  return (
    <View>
      <View style={styles.inputs}>
        <TextInput
          label="Title"
          mode="outlined"
          style={styles.input}
          value={title}
          onChangeText={(text) => setTitle(text)}
        />
        <TextInput
          label="Primary language"
          mode="outlined"
          style={styles.input}
          value={primaryLanguage}
          onChangeText={(text) => setPrimaryLanguage(text)}
        />
        <TextInput
          label="Tags"
          mode="outlined"
          placeholder="foo bar"
          style={styles.input}
          value={tags}
          onChangeText={(text) => setTags(text)}
        />
      </View>
      <List.Section>
        <View>
          <List.Subheader
            onPress={() => {
              const phraseItem = {
                primaryWord: "",
                translatedWord: "",
              };
              setPhrases([...phrases, phraseItem]);
            }}
          >
            Phrases{"  "}
            <Icon name="plus-circle-outline" size={20} />
          </List.Subheader>
        </View>
        <ScrollView>
          {phrases.map((item, index) => {
            return (
              <View style={styles.phraseView} key={index}>
                <Divider />
                <TextInput
                  style={styles.phraseInputs}
                  label="Primary phrase"
                  mode="outlined"
                  onChangeText={(text) => (item.primaryWord = text)}
                />
                <Icon
                  style={{ marginTop: "6%" }}
                  name="arrow-right-thick"
                  size={20}
                  color="gray"
                />
                <TextInput
                  style={styles.phraseInputs}
                  label="Secondary phrase"
                  mode="outlined"
                  onChangeText={(text) => (item.translatedWord = text)}
                />
              </View>
            );
          })}
        </ScrollView>
      </List.Section>
      <Button mode="contained" onPress={handleCreateSet}>
        Create
      </Button>
    </View>
  );
};

export default CreateSetForm;
