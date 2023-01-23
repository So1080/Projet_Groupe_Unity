using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class MainMenuController : MonoBehaviour
{
    [Header("Réglages des Volumes")] 
    [SerializeField] private TMP_Text volumeEffetsTextvalue = null;
    [SerializeField] private Slider volumeEffetSlider = null;

    [SerializeField] private GameObject comfirmationPromt = null;
    [SerializeField] private float defaultVolume = 50f;
    
    
    
    
    [Header("Lancement de Jeu")] 
    public string _lancerJeu;



    [Header("Graphismes")] 
    private int _qualityLevel;

    [SerializeField] private TMP_Dropdown qualityDropdown;


    [Header("Resolution")] 
    public TMP_Dropdown resolutionDropdown;
    private Resolution[] resolutions;

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
            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
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
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void LancerJeu()
    {
        SceneManager.LoadScene(_lancerJeu);
    }


    public void ExitButton()
    {
        Application.Quit();
    }

    public void SetQuality(int qualityIndex)
    {
        _qualityLevel = qualityIndex;
    }


    public void GraphicsApply()
    {
        PlayerPrefs.SetFloat("masterQuality", _qualityLevel);
        QualitySettings.SetQualityLevel((_qualityLevel));
        StartCoroutine(ConfirmationBox());
    }
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        volumeEffetsTextvalue.text = volume.ToString("N");
    }

    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume",AudioListener.volume);
        StartCoroutine(ConfirmationBox());
    }

    public void ResetButton(string MenuType)
    {
        if (MenuType == "Audio")
        {
            AudioListener.volume = defaultVolume;
            volumeEffetSlider.value = defaultVolume;
            volumeEffetsTextvalue.text = defaultVolume.ToString("N");
            VolumeApply();
        }
        
        if (MenuType == "Graphics")
        {
            qualityDropdown.value = 1;
            QualitySettings.SetQualityLevel(1);
            GraphicsApply();

            Resolution currentResolution = Screen.currentResolution;
            Screen.SetResolution(currentResolution.width, currentResolution.height, Screen.fullScreen);
            resolutionDropdown.value = resolutions.Length;
            GraphicsApply();
        }
            
    }
    
    
    public IEnumerator ConfirmationBox()
    {
        comfirmationPromt.SetActive(true);
        yield return new WaitForSeconds(2);
        comfirmationPromt.SetActive(false);
    }
}
