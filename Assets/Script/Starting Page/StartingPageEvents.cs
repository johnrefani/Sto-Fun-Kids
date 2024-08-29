using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartingPageEvents : MonoBehaviour
{
    public GameObject startPage;
    public GameObject aboutPage;
    public GameObject settingsPage;
    public GameObject scorePage;
    public GameObject warning;
    public GameObject deletionFrame;
    private string AugmentedRealityScene = "AugmentedReality";
    private string LessonScene = "LessonScene";
    private string LessonLockedScene = "LessonSceneLocked";
    private string LoadingScene = "LoadingPage";
    void Start()
    {
        StartPageOpen();
    }

    public void LearnGame()
    {
        SceneManager.LoadScene(LessonScene);
    }

    public void LearnGameLocked()
    {
        SceneManager.LoadScene(LessonLockedScene);
    }

    public void DiscoverGame()
    {
        SceneManager.LoadScene(AugmentedRealityScene);
    }
    public void StartPageOpen()
    {
        startPage.SetActive(true);
        aboutPage.SetActive(false);
        scorePage.SetActive(false);
        settingsPage.SetActive(false);
        warning.SetActive(false);
        deletionFrame.SetActive(false);
    }

    public void AboutPageOpen()
    {
        startPage.SetActive(false);
        aboutPage.SetActive(true);
        scorePage.SetActive(false);
        settingsPage.SetActive(false);
        warning.SetActive(false);
        deletionFrame.SetActive(false);
    }

    public void SettingsPageOpen()
    {
        startPage.SetActive(true);
        aboutPage.SetActive(false);
        scorePage.SetActive(false);
        settingsPage.SetActive(true);
        warning.SetActive(false);
        deletionFrame.SetActive(false);
    }

    public void ScorePageOpen()
    {
        startPage.SetActive(false);
        aboutPage.SetActive(false);
        scorePage.SetActive(true);
        settingsPage.SetActive(false);
        warning.SetActive(false);
        deletionFrame.SetActive(false);
    }

    public void DeleteDataWarning()
    {
        startPage.SetActive(true);
        aboutPage.SetActive(false);
        scorePage.SetActive(false);
        settingsPage.SetActive(true);
        warning.SetActive(true);
        deletionFrame.SetActive(false);
    }

    public void ResetPlayerPrefs()
    {
        PlayerPrefs.SetInt("Highscore_FirstTimeQuiz", 0);
        PlayerPrefs.SetInt("Highscore_Quiz1", 0);
        PlayerPrefs.SetInt("Highscore_FlashQuiz", 0);
        PlayerPrefs.SetInt("Highscore_Riddle", 0);
        PlayerPrefs.SetInt("Highscore_Quiz4", 0);
        PlayerPrefs.SetInt("Highscore_FinalExam", 0);

        PlayerPrefs.Save();
        PlayerPrefs.DeleteAll();
        deletionFrame.SetActive(true);
        Invoke("DeleteDataFrame", 5f);


    }

    void DeleteDataFrame()
    {
        SceneManager.LoadScene(LoadingScene);
    }


    public void ApplicationClose()
    {
        Application.Quit();
    }


}
