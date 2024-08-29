using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoreDisplay : MonoBehaviour
{
    public TMP_Text preTestScore;
    public TMP_Text quiz1Score;
    public TMP_Text quiz2Score;
    public TMP_Text quiz3Score;
    public TMP_Text quiz4Score;

    public TMP_Text postTestScore;

    public TMP_Text pretestAttempt;
    public TMP_Text quiz1Attempt;
    public TMP_Text quiz2Attempt;
    public TMP_Text quiz3Attempt;
    public TMP_Text quiz4Attempt;

    public TMP_Text postTestAttempt;



    void Start()
    {
        // Display the highscore from each scene
        DisplayHighscores();
    }

    void DisplayHighscores()
    {
        // Retrieve and display highscores and attempts for each scene
        DisplayScoreForScene(preTestScore, pretestAttempt, "FirstTimeQuiz");
        DisplayScoreForScene(quiz1Score, quiz1Attempt, "Quiz1");
        DisplayScoreForScene(quiz2Score, quiz2Attempt, "FlashQuiz");
        DisplayScoreForScene(quiz3Score, quiz3Attempt, "Riddle");
        DisplayScoreForScene(quiz4Score, quiz4Attempt, "Quiz4");
        DisplayScoreForScene(postTestScore, postTestAttempt, "FinalExam");

    }

    void DisplayScoreForScene(TMP_Text scoreText, TMP_Text attemptText, string sceneName)
    {
        // Retrieve the highscore and attempt count for the given scene
        int highscore = PlayerPrefs.GetInt("Highscore_" + sceneName, 0);
        int attempts = PlayerPrefs.GetInt("Attempts_" + sceneName, 0);

        // Update the UI text with the highscore and attempts
        scoreText.text = highscore.ToString();
        attemptText.text = attempts.ToString();
    }
}

