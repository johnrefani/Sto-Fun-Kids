using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuEvenSystem : MonoBehaviour
{

    public GameObject MainMenuPanel, ScorePanel, SettingsPanel;

    void Start()
    {
        MainMenuOpen();
    }

    public void MainMenuOpen()
    {
        MainMenuPanel.SetActive(true);
        ScorePanel.SetActive(false);
        SettingsPanel.SetActive(false);
    }

    public void ScoreOpen()
    {
        MainMenuPanel.SetActive(false);
        ScorePanel.SetActive(true);
        SettingsPanel.SetActive(false);
    }

    public void SettingsOpen()
    {
        MainMenuPanel.SetActive(true);
        ScorePanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }

    public void ApplicationClose()
    {
        Application.Quit();
    }


}
