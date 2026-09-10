using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;

public class UIController : MonoBehaviour
{
    
    void Start()
    {

    }

    void Update()
    {
        
    }

    public void RestartGame()
    {
        Debug.Log("Restart Game");
        Time.timeScale = 1f; // Resume the game if it was paused
        PlayerPrefs.DeleteKey(GameState.PlayerPrefsKeyName);
        PlayerPrefs.Save();

        /*if (GameManager.Instance != null)
        {
            GameManager.Instance.currentData = null; // Clear the current game state
            GameManager.Instance.InitializeNewGame(); // Reinitialize the game state
        }*/

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Credits()
    {
        Debug.Log("Credits");
        SceneManager.LoadScene("Credits");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
