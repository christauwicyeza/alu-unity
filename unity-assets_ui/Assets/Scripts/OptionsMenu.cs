using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles the options menu actions.
/// </summary>
public class OptionsMenu : MonoBehaviour
{
    /// <summary>
    /// Loads MainMenu scene.
    /// </summary>
    public void Back()
{
    SceneManager.LoadScene("MainMenu"); 
}
}