using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages pausing and resuming the game.
/// </summary>
public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas; // Reference to the PauseCanvas
    private bool isPaused = false;

    /// <summary>
    /// Pauses the game and shows the pause menu.
    /// </summary>
    public void Pause()
    {
        isPaused = true;
        pauseCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    /// <summary>
    /// Resumes the game and hides the pause menu.
    /// </summary>
    public void Resume()
    {
        isPaused = false;
        pauseCanvas.SetActive(false);
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
}