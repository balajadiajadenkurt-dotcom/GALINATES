using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject optionsPanel;

    private bool isPaused = false;

    public void TogglePause()
    {
        isPaused = !isPaused;

        optionsPanel.SetActive(isPaused);

        if (isPaused)
        {
            Time.timeScale = 0f; // ⏸ Pause game
        }
        else
        {
            Time.timeScale = 1f; // ▶ Resume game
        }
    }
}