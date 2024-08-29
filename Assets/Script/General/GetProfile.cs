using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GetProfile : MonoBehaviour
{
    public TMP_Text CharacterName;
    public Image Icon;
    public Image IconA, IconB, IconC, IconD;
    void Start()
    {
        GetNameAndIcon();
    }

    public void GetNameAndIcon()
    {
        string CharacterNameDisplay = PlayerPrefs.GetString("CharacterName");
        string CharacterIcon = PlayerPrefs.GetString("CharacterIcon");

        CharacterName.SetText(CharacterNameDisplay);

        if (CharacterIcon == "IconA")
        {
            Icon.sprite = IconA.sprite;
        }
        else if (CharacterIcon == "IconB")
        {
            Icon.sprite = IconB.sprite;
        }
        else if (CharacterIcon == "IconC")
        {
            Icon.sprite = IconC.sprite;
        }
        else if (CharacterIcon == "IconD")
        {
            Icon.sprite = IconD.sprite;
        }
    }
}
