using UnityEditor;
using UnityEngine;

public class JSONReader : MonoBehaviour
{
    public TextAsset jsonFile;
    public string newValue;

    void Start()
    {
        if(newValue == "")
        {
            Languages languagesInJson = JsonUtility.FromJson<Languages>(jsonFile.text);

            foreach (Language language in languagesInJson.languages)
            {
                Debug.Log("Found language: " + language.name + " " + language.paradigm);
            }
        }

        else
        {
            Languages languagesInJson = JsonUtility.FromJson<Languages>(jsonFile.text);
            languagesInJson.languages[0].name = newValue;
            newValue = JsonUtility.ToJson(languagesInJson);
            System.IO.File.WriteAllText(Application.dataPath + "/languages.JSON", newValue);
        }
    }
}