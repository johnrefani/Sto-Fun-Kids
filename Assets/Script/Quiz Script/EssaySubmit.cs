using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EssaySubmit : MonoBehaviour
{
    public TMP_InputField inputField;
    public GameObject Notify;

    void Start()
    {
        Notify.SetActive(false);
        string Essay = PlayerPrefs.GetString("Essay_" + SceneManager.GetActiveScene().name);
        inputField.text = Essay;

    }
    public void SubmitEssay()
    {
        string essay = inputField.text;

        PlayerPrefs.SetString("Essay_" + SceneManager.GetActiveScene().name, essay);
        PlayerPrefs.SetInt("StoryStatus_" + SceneManager.GetActiveScene().name, 1);
        Notify.SetActive(true);

    }


}
