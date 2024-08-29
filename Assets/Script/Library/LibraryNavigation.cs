using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryNavigation : MonoBehaviour
{
    public GameObject MainLibrary, Story1Panel, Story2Panel; 
    void Start()
    {
        
        int BookNumber = PlayerPrefs.GetInt("BookStatus", 0);

        if (BookNumber == 0)
        {
            OpenMainLibrary();
        } 
        else if (BookNumber == 1)
        {
            OpenStory1();
        }
        else if (BookNumber == 2)
        {
            OpenStory2();
        }

    }

    public void OpenMainLibrary()
    {
        MainLibrary.SetActive(true);
        Story1Panel.SetActive(false);
        Story2Panel.SetActive(false);
    }

    public void OpenStory1()
    {
        MainLibrary.SetActive(false);
        Story1Panel.SetActive(true);
        Story2Panel.SetActive(false);
    }

    public void OpenStory2()
    {
        MainLibrary.SetActive(false);
        Story1Panel.SetActive(false);
        Story2Panel.SetActive(true);
    }

}
