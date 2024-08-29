using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAnswer> QA;
    public GameObject[] options;
    public int currentQuestion;

    public TMP_Text QuestionText;

    public GameObject gameOver;
    public GameObject quizPanel;

    public GameObject gameOverZeroStar;
    public GameObject gameOverOneStar;
    public GameObject gameOverTwoStar;
    public GameObject gameOverThreeStar;


    public TMP_Text ScoreText;
    public TMP_Text PageNumberText;

    public int scoreCount;
    int totalQuestions = 0;
    public int answeredQuestions;

    int ratings;

    private bool optionsInteractable = true;

    public float timerDuration = 180f; // 3 minutes
    private float timer;
    public TMP_Text TimerText;

    public string Library = "Library Menu";

    public AudioSource AudioCorrect;
    public AudioSource AudioWrong;

    void Start()
    {
        // Retrieve the attempt count from PlayerPrefs
        ratings = PlayerPrefs.GetInt("Ratings_" + SceneManager.GetActiveScene().name);

        totalQuestions = QA.Count;
        gameOver.SetActive(false);
        answeredQuestions = 0; // Initialize current question to the first question
        generateQuestion();

        timer = timerDuration;
        StartCoroutine(StartTimer());

    }

    void Update()
    {
        // Update the timer
        timer -= Time.deltaTime;

        // Update the TimerText
        UpdateTimerText();

        // Check if the timer has reached zero
        if (timer <= 0)
        {
            GameOver(); // End the game when the timer is up
        }

    }

    IEnumerator StartTimer()
    {
        while (timer > 0)
        {
            yield return null;
        }

        GameOver(); // End the game when the timer is up
    }

    public void UpdateTimerText()
    {
        // Format the time as minutes and seconds
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);

        // Update the TimerText with the formatted time
        TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void correct()
    {

        AudioCorrect.Play();
        scoreCount += 1;
        QA.RemoveAt(currentQuestion);
        StartCoroutine(WaitForNext());


    }

    public void wrong()
    {
        AudioWrong.Play();
        QA.RemoveAt(currentQuestion);
        StartCoroutine(WaitForNext());

    }

    IEnumerator WaitForNext()
    {
        SetOptionsInteractable(false); // Disable options immediately

        yield return new WaitForSeconds(3);

        if (QA.Count > 0)
        {
            answeredQuestions++;
            generateQuestion();
        }
        else
        {
            GameOver(); // No more questions, end the game
        }

        yield return new WaitForSeconds(0.1f); // Small delay to ensure the new question is generated

        SetOptionsInteractable(true); // Enable options after generating the new question
    }

    void SetOptionsInteractable(bool interactable)
    {
        foreach (var option in options)
        {
            option.GetComponent<Button>().interactable = interactable;
        }
    }

    public void Retry()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void GameOver()
    {
        quizPanel.SetActive(false);
        gameOver.SetActive(true);

        
        ScoreText.text = scoreCount + " / " + totalQuestions;

        // Save the current score to PlayerPrefs with a unique key based on the scene
        PlayerPrefs.SetInt("Highscore_" + SceneManager.GetActiveScene().name, scoreCount);


        // Determine the star rating based on score
        if (scoreCount >= -1 && scoreCount <= 3)
        {
            gameOverOneStar.SetActive(true);
            // Save the updated ratings to PlayerPrefs
            PlayerPrefs.SetInt("Ratings_" + SceneManager.GetActiveScene().name, 1);
        }
        else if (scoreCount >= 4 && scoreCount <= 6)
        {
            gameOverTwoStar.SetActive(true);
            // Save the updated ratings to PlayerPrefs
            PlayerPrefs.SetInt("Ratings_" + SceneManager.GetActiveScene().name, 2);
        }
        else if (scoreCount >= 7 && scoreCount <= totalQuestions)
        {
            gameOverThreeStar.SetActive(true);
            // Save the updated ratings to PlayerPrefs
            PlayerPrefs.SetInt("Ratings_" + SceneManager.GetActiveScene().name, 3);
        }
        else if (scoreCount == 0 && scoreCount <= totalQuestions)
        {
            int fail = 0;
            gameOverZeroStar.SetActive(true);
            // Save the updated ratings to PlayerPrefs
            PlayerPrefs.SetInt("Ratings_" + SceneManager.GetActiveScene().name, fail);
        }

        // Deactivate any unused Game Over panels
        gameOverZeroStar.SetActive(gameOverOneStar.activeInHierarchy && scoreCount == 0 && scoreCount < 1);
        gameOverOneStar.SetActive(gameOverOneStar.activeInHierarchy && scoreCount >= 1 && scoreCount <= 3);
        gameOverTwoStar.SetActive(gameOverTwoStar.activeInHierarchy && scoreCount >= 4 && scoreCount <= 6);
        gameOverThreeStar.SetActive(gameOverThreeStar.activeInHierarchy && scoreCount >= 7 && scoreCount <= totalQuestions);
    }
    void SetAnswer()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Button>().interactable = optionsInteractable; // Set interactable based on the flag

            options[i].GetComponent<AnswersScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = QA[currentQuestion].Answers[i];


            //Changing color when get clicked.
            options[i].GetComponent<Image>().color = options[i].GetComponent<AnswersScript>().startColor;

            if (QA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswersScript>().isCorrect = true;
            }
        }

        UpdatePageNumber();

    }

    public void generateQuestion()
    {
        if (QA.Count > 0)
        {
            currentQuestion = Random.Range(0, QA.Count);

            QuestionText.text = QA[currentQuestion].Question;
            SetAnswer();
        }
        else
        {
            Debug.Log("Out of questions");
            GameOver();
        }


    }

    void UpdatePageNumber()
    {
        PageNumberText.text = "Question " + (answeredQuestions + 1) + " / " + totalQuestions;
    }

    public void ExitToLibrary()
    {
        SceneManager.LoadScene(Library);
    }

}