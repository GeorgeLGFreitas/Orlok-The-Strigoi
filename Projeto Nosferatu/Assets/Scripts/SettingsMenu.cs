using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer musicMixer;
    public AudioMixer sfxMixer;

    public Dropdown resolutionDropdown;

    Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;

            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width & resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];

        Screen.SetResolution(resolution.height, resolution.width, Screen.fullScreen);
    }
    public void SetFullscrean(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public void SetMusicVolume(float volume)
    {
        musicMixer.SetFloat("MyExposedParam", volume);
    }
    public void SetSoundEffectsVolume(float volume)
    {
        sfxMixer.SetFloat("MyExposedParam", volume);
    }
}
