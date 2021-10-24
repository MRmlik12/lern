import * as ImagePicker from "expo-image-picker";
import { Platform } from "react-native";

export const getPhoto =
  async (): Promise<ImagePicker.ImagePickerResult | null> => {
    if (Platform.OS !== "web") {
      const { status } =
        await ImagePicker.requestMediaLibraryPermissionsAsync();
      if (status !== "granted") {
        return null;
      }
    }

    return await ImagePicker.launchImageLibraryAsync({
      mediaTypes: ImagePicker.MediaTypeOptions.Images,
      allowsEditing: true,
      aspect: [4, 3],
      base64: true,
      quality: 1,
    });
  };
