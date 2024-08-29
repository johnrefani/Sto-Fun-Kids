using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLibrary : MonoBehaviour
{

    public void SetToDefault()
    {
        PlayerPrefs.SetInt("BookStatus", 0);
    }

    public void SetToBook1()
    {
        PlayerPrefs.SetInt("BookStatus", 1);
    }

    public void SetToBook2()
    {
        PlayerPrefs.SetInt("BookStatus", 2);
    }

}
