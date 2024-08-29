using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public GameObject LoroStory, MakinangStory;

    public TMP_Text LoroVocabulary, LoroAssessment;
    public TMP_Text MakinangVocabulary, MakinangAssessment;


    public Image MakinangVocabularyRatings, MakinangAssessmentRatings;
    public Image LoroVocabularyRatings, LoroAssessmentRatings;
    public Image ZeroStar, OneStar, TwoStar, ThreeStar;
    // Start is called before the first frame update
    void Start()
    {

        DisplayScoresAndRatings();
    }

    void DisplayScoresAndRatings()
    {
        
        DisplayScoreForScene(LoroVocabulary, LoroVocabularyRatings, "Loro Vocabulary");
        DisplayScoreForScene(LoroAssessment, LoroAssessmentRatings, "Loro Assessment");

        DisplayScoreForScene(MakinangVocabulary, MakinangVocabularyRatings, "Makinang Vocabulary");
        DisplayScoreForScene(MakinangAssessment, MakinangAssessmentRatings, "Makinang Assessment");

        DisplayStoryButton(LoroStory, "Loro Essay");
        DisplayStoryButton(MakinangStory, "Makinang Essay");

    }

    void DisplayScoreForScene(TMP_Text scoreText, Image ratingsImage, string sceneName)
    {
        // Retrieve the highscore and attempt count for the given scene
        int highscore = PlayerPrefs.GetInt("Highscore_" + sceneName, 0);
        int ratings = PlayerPrefs.GetInt("Ratings_" + sceneName, 0);

        // Update the UI text with the highscore and attempts
        scoreText.text = highscore.ToString();

        
        if (ratings == 1)
        {
            ratingsImage.sprite = OneStar.sprite;
        }
        else if (ratings == 2)
        {
            ratingsImage.sprite = TwoStar.sprite;
        }
        else if (ratings == 3)
        {
            ratingsImage.sprite = ThreeStar.sprite;
        }
        else if (ratings == 0)
        {
            ratingsImage.sprite = ZeroStar.sprite;
        }
        else 
        {
            ratingsImage.sprite = ZeroStar.sprite;
        }
    }


    void DisplayStoryButton(GameObject storybutton,string sceneName)
    {
        
        int storyStatus = PlayerPrefs.GetInt("StoryStatus_" + sceneName);
        


        if (storyStatus == 0)
        {
            storybutton.gameObject.SetActive(false);
        }
        else if (storyStatus == 1)
        {
            storybutton.gameObject.SetActive(true);
        }
    }
}
