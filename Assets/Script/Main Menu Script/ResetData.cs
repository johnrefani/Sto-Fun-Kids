using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetData : MonoBehaviour
{
    public GameObject deletionFrame;
    public string SplashScreen = "Splash Screen";
    public void ResetPlayerPrefs()
    {
        PlayerPrefs.SetInt("OnboardingStatus", 0);

        PlayerPrefs.SetInt("Highscore_Loro Vocabulary", 0);
        PlayerPrefs.SetInt("Ratings_Loro Vocabulary", 0);

        PlayerPrefs.SetInt("Highscore_Loro Assessment", 0);
        PlayerPrefs.SetInt("Ratings_Loro Assessment", 0);

        PlayerPrefs.SetInt("Highscore_Makinang Vocabulary", 0);
        PlayerPrefs.SetInt("Ratings_Makinang Vocabulary", 0);

        PlayerPrefs.SetInt("Highscore_Makinang Assessment", 0);
        PlayerPrefs.SetInt("Ratings_Makinang Assessment", 0);





        PlayerPrefs.Save();
        PlayerPrefs.DeleteAll();
        deletionFrame.SetActive(true);
        Invoke("DeleteDataFrame", 5f);


    }

    void DeleteDataFrame()
    {
        SceneManager.LoadScene(SplashScreen);
    }

}
