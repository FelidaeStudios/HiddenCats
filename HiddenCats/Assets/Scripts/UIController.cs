using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;

public class UIController : MonoBehaviour
{
    public GameObject hintButton;
    public GameObject settingsButton;
    public GameObject settingsMenu;
    public TMP_Text countText;

    void Start()
    {

    }

    void Update()
    {
        //DisplayCount();
    }

    public void ToggleSettings()
    {
        if (settingsMenu.activeSelf)
        {
            settingsMenu.SetActive(false);
        }
        else
        {
            settingsMenu.SetActive(true);
        }
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

    /*public void DisplayCount()
    {
        // Update countText with number of found versus total objects.
        countText.GetComponent<TMP_Text>().text = GameManager.GetFoundObjectCount() + " / " + GameManager.GetTotalObjectCount();
    }*/
}
