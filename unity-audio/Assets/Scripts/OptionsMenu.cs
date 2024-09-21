using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

/// <summary>
/// Handles options menu.
/// </summary>
public class OptionsMenu : MonoBehaviour
{
    public Toggle invertYToggle;
    public Slider bgmSlider;  // Reference to the BGM Slider
    public AudioMixer audioMixer;  // Reference to the AudioMixer
    private bool originalInvertedState;
    private float originalBGMVolume;

    /// <summary>
    /// Loads Invert Y-Axis state and BGM volume.
    /// </summary>
    private void Start()
    {
        // Load Invert Y-Axis settings
        originalInvertedState = PlayerPrefs.GetInt("isInverted", 0) == 1;
        invertYToggle.isOn = originalInvertedState;

        // Load BGM volume settings
        float savedBGMVolume = PlayerPrefs.GetFloat("BGMVolume", 0.75f); // Default to 75% volume
        bgmSlider.value = savedBGMVolume;
        SetBGMVolume(savedBGMVolume);
        originalBGMVolume = savedBGMVolume;  // Store original volume

        // Add listener for the slider to change volume in real-time
        bgmSlider.onValueChanged.AddListener(SetBGMVolume);
    }

    /// <summary>
    /// Saves settings and returns.
    /// </summary>
    public void Apply()
    {
        // Save Invert Y-Axis settings
        bool isInverted = invertYToggle.isOn;
        PlayerPrefs.SetInt("isInverted", isInverted ? 1 : 0);

        // Save BGM volume settings
        PlayerPrefs.SetFloat("BGMVolume", bgmSlider.value);
        PlayerPrefs.Save();

        // Return to the previous scene
        string previousScene = PlayerPrefs.GetString("previousScene", "MainMenu");
        SceneManager.LoadScene(previousScene);
    }

    /// <summary>
    /// Discards changes and returns.
    /// </summary>
    public void Back()
    {
        // Reset to the original state if changes are discarded
        invertYToggle.isOn = originalInvertedState;
        bgmSlider.value = originalBGMVolume;
        SetBGMVolume(originalBGMVolume);

        // Return to the previous scene
        string previousScene = PlayerPrefs.GetString("previousScene", "MainMenu");
        SceneManager.LoadScene(previousScene);
    }

    /// <summary>
    /// Sets the BGM volume in the Audio Mixer.
    /// </summary>
    /// <param name="sliderValue">Value from the slider (0 to 1).</param>
    public void SetBGMVolume(float sliderValue)
    {
        // Convert the slider value (0 to 1) to decibels for the AudioMixer
        float dBValue = Mathf.Log10(sliderValue) * 20;
        audioMixer.SetFloat("BGMVolume", dBValue);
    }
}
