using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndingDialogue : MonoBehaviour
{
    [Header("Ending Lines")]
    [TextArea(2, 5)]
    public string[] lines;

    [Header("Typing Settings")]
    public float typingSpeed = 0.04f;

    [Header("UI")]
    public TextMeshProUGUI dialogueText;

    [Header("Next Scene")]
    public string finalEndingSceneName = "Ending";
    public float waitAfterTyping = 10f;

    void Start()
    {
        StartCoroutine(PlayEnding());
    }

    IEnumerator PlayEnding()
    {
        dialogueText.text = "";

        foreach (string line in lines)
        {
            foreach (char c in line)
            {
                dialogueText.text += c;
                yield return new WaitForSeconds(typingSpeed);
            }

            dialogueText.text += "\n";
            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(waitAfterTyping);
        SceneManager.LoadScene(finalEndingSceneName);
    }
}