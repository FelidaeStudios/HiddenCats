using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    // Stores persistent data across scenes
    // Objects found vs not found, hints used, time spent
    public GameObject endScreen;
    public GameStateData currentData;

    /*public static GameManager Instance;

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
    }*/

    void Start()
    {
        PlayerPrefs.DeleteKey(GameState.PlayerPrefsKeyName); // For testing purposes, remove this line in production
        Debug.Log("GameObjects in scene with tag 'Object': " + GameObject.FindGameObjectsWithTag("Object").Length);
        var loadedState = GameState.LoadFromPlayerPrefs();
        if (loadedState != null)
        {
            currentData = loadedState;
            RestoreSceneState();
        }
        else
        {
            InitializeNewGame();
        }
    }

    void Update()
    {
        EndGame();
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
                    obj.GetComponent<SpriteRenderer>().sprite = controller.foundSprite;
                }
            }
        }

        Debug.Log("Game state restored from PlayerPrefs. Object array length: " + currentData.allObjects.Length);
    }

    void ResetSceneState()
    {
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Object");

        foreach (GameObject obj in allObjects)
        {
            var controller = obj.GetComponent<ObjectController>();
            if (controller != null)
            {
                controller.isFound = false;
                if (controller.hiddenSprite != null)
                {
                    obj.GetComponent<SpriteRenderer>().sprite = controller.hiddenSprite;
                }
            }
        }
    }

    public void InitializeNewGame()
    {
        // Initialize currentData with all objects in the scene using names, positions, and isFound = false.
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Object");

        currentData = new GameStateData();
        currentData.allObjects = new ObjectData[allObjects.Length];

        for (int i = 0; i < allObjects.Length; i++)
        {
            GameObject obj = allObjects[i];
            ObjectData objectData = new ObjectData();
            objectData.objectName = obj.name;
            objectData.position = obj.transform.position;
            objectData.rotation = obj.transform.rotation;
            objectData.isFound = false; // All objects are initially not found
            currentData.allObjects[i] = objectData;
        }
        ResetSceneState();
        SaveGameState();

        Debug.Log("No save found. New game initialized. Object array length: " + currentData.allObjects.Length);
    }

    void EndGame()
    {
        if (currentData.allObjects != null && currentData.allObjects.Length > 0 && Array.TrueForAll(currentData.allObjects, obj => obj.isFound == true))
        {
            endScreen.SetActive(true);
            Time.timeScale = 0f; // Pause the game
            Debug.Log("All objects found! Game Over!");
            // Implement end game logic here, such as showing a victory screen or resetting the game.
        }
    }
}
