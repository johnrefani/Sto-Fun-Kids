using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSet : MonoBehaviour
{
    public TMP_InputField inputField;

    
    public TMP_Text CharacterName;
    public Image ImgIconA, ImgIconB, ImgIconC, ImgIconD;

    public Image Icon;
    public GameObject IconA, IconB, IconC, IconD;

    public GameObject CharacterNamePanel, CharacterIconPanel;
    void Start()
    {
        OpenCharacterName();
    }

    void Update()
    {
        GetNameAndIcon();
    }

    public void OpenScene() 
    {
        PlayerPrefs.SetInt("OnboardingStatus", 1);
        SceneManager.LoadScene("MainMenu");
    }


    public void OpenCharacterName()
    {
        CharacterNamePanel.SetActive(true);
        CharacterIconPanel.SetActive(false);
    }

    public void OpenCharacterIcon()
    {
        CharacterNamePanel.SetActive(false);
        CharacterIconPanel.SetActive(true);
    }

    public void SetName()
    {
        string name = inputField.text;
        PlayerPrefs.SetString("CharacterName", name);
    }

    public void SetIconA()
    {
        IconA.transform.localScale = new Vector2(1.1f, 1.1f);
        IconB.transform.localScale = new Vector2(1, 1);
        IconC.transform.localScale = new Vector2(1, 1);
        IconD.transform.localScale = new Vector2(1, 1);
        PlayerPrefs.SetString("CharacterIcon", "IconA");
    }

    public void SetIconB()
    {
        IconA.transform.localScale = new Vector2(1, 1);
        IconB.transform.localScale = new Vector2(1.1f, 1.1f);
        IconC.transform.localScale = new Vector2(1, 1);
        IconD.transform.localScale = new Vector2(1, 1);
        PlayerPrefs.SetString("CharacterIcon", "IconB");
    }

    public void SetIconC()
    {
        IconA.transform.localScale = new Vector2(1, 1);
        IconB.transform.localScale = new Vector2(1, 1);
        IconC.transform.localScale = new Vector2(1.1f, 1.1f);
        IconD.transform.localScale = new Vector2(1, 1);
        PlayerPrefs.SetString("CharacterIcon", "IconC");
    }
    public void SetIconD()
    {
        IconA.transform.localScale = new Vector2(1, 1);
        IconB.transform.localScale = new Vector2(1, 1);
        IconC.transform.localScale = new Vector2(1, 1);
        IconD.transform.localScale = new Vector2(1.1f, 1.1f);
        PlayerPrefs.SetString("CharacterIcon", "IconD");
    }

    public void Proceed() 
    {
        PlayerPrefs.SetInt("OnboardingStatus", 1);
    }
    public void GetNameAndIcon()
    {
        string CharacterNameDisplay = PlayerPrefs.GetString("CharacterName");
        string CharacterIcon = PlayerPrefs.GetString("CharacterIcon");

        CharacterName.SetText(CharacterNameDisplay);

        if (CharacterIcon == "IconA")
        {
            Icon.sprite = ImgIconA.sprite;
        }
        else if (CharacterIcon == "IconB")
        {
            Icon.sprite = ImgIconB.sprite;
        }
        else if (CharacterIcon == "IconC")
        {
            Icon.sprite = ImgIconC.sprite;
        }
        else if (CharacterIcon == "IconD")
        {
            Icon.sprite = ImgIconD.sprite;
        }
    }

    
}
