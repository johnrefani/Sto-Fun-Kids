using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    
    public string OnboardingPage = "Character Creation";
    public string StartMenuPage = "MainMenu";
    public float delay = 4.5f;

    void Start()
    {

        int onboardingStatus = PlayerPrefs.GetInt("OnboardingStatus", 0);

        if (onboardingStatus == 0)
        {
     
            // Add a delay before logging
            Invoke("CharacterCreation", delay);
        }
        else if (onboardingStatus == 1)
        {
           
            // Add a delay before logging
            Invoke("MainMenu", delay);
        }
    }

    void CharacterCreation()
    {
        Debug.Log("Logged Intro after 5 seconds");
        // Add any additional code you want to execute after the delay

        SceneManager.LoadScene(OnboardingPage);
    }

    void MainMenu()
    {
        Debug.Log("Logged Intro after 5 seconds");
        // Add any additional code you want to execute after the delay

        SceneManager.LoadScene(StartMenuPage);
    }
}

