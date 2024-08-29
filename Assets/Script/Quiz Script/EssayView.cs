using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EssayView : MonoBehaviour
{
    public TMP_Text textField;
    public string SceneName;

    void Start()
    {
       
        string Essay = PlayerPrefs.GetString("Essay_" + SceneName);
        textField.text = Essay;

    }
    


}
