using UnityEngine;
using System;

[Serializable]
public class ObjectData
{
    public string objectName;
    public Vector3 position;
    public Quaternion rotation;
    public bool isFound;
}

[Serializable]
public class GameStateData
{
    public ObjectData[] allObjects;
}

public class GameState : MonoBehaviour
{
    public GameObject[] hiddenObjects;
    public GameObject[] foundObjects;

    public const string PlayerPrefsKeyName = "SavedGameState";

    // Save game state to PlayerPrefs.
    public void SaveToPlayerPrefs()
    {
        GameStateData gameStateData = new GameStateData();
        gameStateData.allObjects = new ObjectData[hiddenObjects.Length + foundObjects.Length];
        for (int i = 0; i < hiddenObjects.Length; i++)
        {
            GameObject obj = hiddenObjects[i];
            ObjectData objectData = new ObjectData();
            objectData.objectName = obj.name;
            objectData.position = obj.transform.position;
            objectData.rotation = obj.transform.rotation;
            objectData.isFound = false; // Assuming hidden objects are not found yet
            gameStateData.allObjects[i] = objectData;
        }

        for (int i = 0; i < foundObjects.Length; i++)
        {
            GameObject obj = foundObjects[i];
            ObjectData objectData = new ObjectData();
            objectData.objectName = obj.name;
            objectData.position = obj.transform.position;
            objectData.rotation = obj.transform.rotation;
            objectData.isFound = true; // Assuming found objects are already found
            gameStateData.allObjects[hiddenObjects.Length + i] = objectData;
        }
        
        string json = JsonUtility.ToJson(gameStateData);

        PlayerPrefs.SetString(PlayerPrefsKeyName, json);
        PlayerPrefs.Save();
    }

    // Load game state from PlayerPrefs, return null if none exists.
    public static GameStateData LoadFromPlayerPrefs()
    {
        if (!PlayerPrefs.HasKey(PlayerPrefsKeyName))
        {
            return null;
        }

        string json = PlayerPrefs.GetString(PlayerPrefsKeyName);
        return JsonUtility.FromJson<GameStateData>(json);
    }
}
