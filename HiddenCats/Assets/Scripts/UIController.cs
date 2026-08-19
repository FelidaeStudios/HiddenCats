using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject hintButton;
    public GameObject settingsButton;
    public GameObject settingsMenu;

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

    public void Hint()
    {
        // Implement hint functionality here.
        Debug.Log("Hint");
    }
}
