using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject settingsMenu;
    public GameManager gameManager;
    [SerializeField] private string nextSceneName;
    public void StartGame()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Settings()
    {
        if (settingsMenu.activeSelf)
        {
            Time.timeScale = 1f;
            gameManager.GamePaused = false;
            settingsMenu.SetActive(false);
        }
        else
        {
            Time.timeScale = 0f;
            gameManager.GamePaused = true;
            settingsMenu.SetActive(true);
        }
    }

    public void ExitPanel() // Update for any other panels. General-purpose exit button function.
    {
        Time.timeScale = 1f;
        if (settingsMenu.activeSelf)
        {
            gameManager.GamePaused = false;
            settingsMenu.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
