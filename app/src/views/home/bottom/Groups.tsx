import React, { useEffect } from "react";
import { Appbar } from "react-native-paper";
import { getGroups } from "../../../api/apiClient";
import { GroupCollectionItem } from "../../../api/models/groupCollectionItem";
import GroupCollection from "../../../components/home/groups/GroupCollection";
import { ActivityIndicator } from "react-native-paper";
import { ScrollView, View } from "react-native";
import CreateGroup from "./groups/CreateGroup";
import JoinGroup from "./groups/JoinGroup";

const Groups: React.FC = () => {
  const [groups, setGroups] = React.useState<Array<GroupCollectionItem>>();
  const [createGroupVisible, setCreateGroupVisible] = React.useState(false);
  const [joinGroupVisible, setJoinGroupVisible] = React.useState(false);
  const [isLoading, setIsLoading] = React.useState(true);

  const groupUserCollection = async () => {
    const groups = await getGroups();
    setGroups(groups);
    setIsLoading(false);
  };

  useEffect(() => {
    groupUserCollection().catch((err) => console.log(err));
  }, []);

  return (
    <View>
      <Appbar.Header style={{ backgroundColor: "#fff" }}>
        <Appbar.Content title="Groups" />
        <Appbar.Action
          icon="account-group-outline"
          onPress={() => setCreateGroupVisible(true)}
        />
        <Appbar.Action
          icon="account-multiple-plus-outline"
          onPress={() => setJoinGroupVisible(true)}
        />
      </Appbar.Header>
      <View>
        {createGroupVisible ? <CreateGroup /> : null}
        {joinGroupVisible ? <JoinGroup /> : null}
        <ScrollView>
          {isLoading ? (
            <ActivityIndicator animating={isLoading} />
          ) : (
            <GroupCollection items={groups!} />
          )}
        </ScrollView>
      </View>
    </View>
  );
};

export default Groups;
