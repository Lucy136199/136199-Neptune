using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DialogueController : MonoBehaviour
{
    [Header("Dialogue Lines")]
    [TextArea(2, 5)]
    public string[] lines;

    [Header("Typing Settings")]
    public float typingSpeed = 0.04f;

    [Header("UI")]
    public TextMeshProUGUI dialogueText;
    public GameObject nextButton;
    public GameObject choiceButtonsGroup;

    [Header("Scene Names")]
    public string earthSceneName = "EarthEnding";
    public string eridSceneName = "EridEnding";

    private int currentLine = 0;
    private bool isTyping = false;

    void Start()
    {
        nextButton.SetActive(false);
        choiceButtonsGroup.SetActive(false);

        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char c in lines[currentLine])
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;

        if (currentLine < lines.Length - 1)
        {
            nextButton.SetActive(true);
        }
        else
        {
            choiceButtonsGroup.SetActive(true);
        }
    }

    public void OnNextClick()
    {
        if (isTyping) return;

        nextButton.SetActive(false);
        currentLine++;

        StartCoroutine(TypeLine());
    }

    public void OnChooseEarth()
    {
        SceneManager.LoadScene(earthSceneName);
    }

    public void OnChooseErid()
    {
        SceneManager.LoadScene(eridSceneName);
    }
}