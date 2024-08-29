using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownloadCardsOnline : MonoBehaviour
{
    public GameObject warningPanel;

    public void OpenCardSite()
    {
        Application.OpenURL("https://www.figma.com/file/4gNIq6UDlPXil3CDQeD4CN/Cards?type=design&node-id=0%3A1&mode=design&t=uA14z8VVFu2ZiRii-1");
    }

    void Start()
    {
        CloseWarningPanel();
    }

    public void OpenWarningPanel()
    {
        warningPanel.SetActive(true);
    }

    public void CloseWarningPanel()
    {
        warningPanel.SetActive(false);
    }
}
