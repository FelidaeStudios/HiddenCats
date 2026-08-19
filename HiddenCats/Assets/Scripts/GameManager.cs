using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    // Stores persistent data across scenes
    // Objects found vs not found, hints used, time spent

    public GameStateData currentData;

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        var loadedState = GameState.LoadFromPlayerPrefs();
        if (loadedState != null)
        {
            currentData = loadedState;
            RestoreSceneState();
        }
        /*else
        {
            InitializeNewGame(); // Later implementation for starting a new game if no saved state exists
        }*/
    }

    public void MarkObjectAsFound(string objectName)
    {
        foreach (var obj in currentData.allObjects)
        {
            if (obj.objectName == objectName)
            {
                obj.isFound = true;
                break;
            }
        }
        SaveGameState();
    }

    public void OnObjectFound(string objectName)
    {
        foreach (var obj in currentData.allObjects)
        {
            if (obj.objectName == objectName)
            {
                obj.isFound = true;
                break;
            }
        }
        SaveGameState();
    }

    private void UpdateObjectLists()
    {
        var hidden = System.Array.FindAll(currentData.allObjects, obj => !obj.isFound);
        var found = System.Array.FindAll(currentData.allObjects, obj => obj.isFound);

        // Pass info to UI
    }

    void SaveGameState()
    {
        string json = JsonUtility.ToJson(currentData);
        PlayerPrefs.SetString(GameState.PlayerPrefsKeyName, json);
        PlayerPrefs.Save();
    }

    void RestoreSceneState()
    {
        foreach (var data in currentData.allObjects)
        {
            GameObject obj = GameObject.Find(data.objectName);
            if (obj != null)
            {
                var controller = obj.GetComponent<ObjectController>();
                if (data.isFound)
                {
                    controller.isFound = true;
                    obj.GetComponent<SpriteRenderer>().sprite = controller.filledSprite;
                }
            }
        }
    }

    void InitializeNewGame()
    {
        // Initialize currentData with default values for a new game
        // This could involve setting up the list of objects, their initial states, etc.
    }
}
