using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StoryNavigation : MonoBehaviour
{
    public GameObject Story_Panel;
    public Image[] Story_imageSet;
    public Image Story_image;
    public TMP_Text Story_Text;
    public Button previousButton;
    public Button nextButton;
    private int Story_currentIndex = 0;

    public string[] Story_textSet;

    public int BookNumber;

    public TMP_Text PageNumber;
    void Start()
    {
        Story_Panel.SetActive(true);
        Story_UpdateText(0); // Show the initial help message when the scene starts.
        previousButton.interactable = false; // Disable the previous button initially.
    }

    void Update()
    {
        UpdatePageNumber();
    }

    void UpdatePageNumber()
    {
        PageNumber.text = "Page: " + (Story_currentIndex + 1) + " of " + Story_imageSet.Length;
    }

    public void Story_OpenHelp()
    {
        Story_Panel.SetActive(true);
        Story_currentIndex = 0; // Reset the current index to 0 when opening the help panel.
        Story_UpdateText(Story_currentIndex); // Update the help text to show the content at index 0.
        previousButton.interactable = false; // Disable the previous button when starting at index 0.
    }


    public void Story_NextContent()
    {
        if (Story_currentIndex < Story_imageSet.Length - 1)
        {
            Story_currentIndex++;
            Story_UpdateText(Story_currentIndex);
            previousButton.interactable = true; // Enable the previous button when not in the first index.
            

        }

        else
        {
            PlayerPrefs.SetInt("BookStatus", BookNumber);
            SceneManager.LoadScene("Library Menu");
        }
    }

    public void Story_PreviousContent()
    {
        if (Story_currentIndex > 0)
        {
            Story_currentIndex--;
            Story_UpdateText(Story_currentIndex);
            if (Story_currentIndex == 0)
            {
                previousButton.interactable = false; // Disable the previous button when in the first index.
            }
        }
    }

    // Function to update the help text and image based on the current index.
    private void Story_UpdateText(int index)
    {
        if (index >= 0 && index < Story_imageSet.Length)
        {
            Story_Text.text = Story_GetText(index);
            Story_image.sprite = Story_imageSet[index].sprite;
        }
    }



    // Define your help text here based on the index.
    private string Story_GetText(int index)
    {
        // Ensure the index is within the bounds of the array
        if (index >= 0 && index < Story_textSet.Length)
        {
            return Story_textSet[index];
        }
        else
        {
            // Handle the case where the index is out of bounds (optional)
            return "Invalid index"; // Or return an empty string
        }
    }
}
