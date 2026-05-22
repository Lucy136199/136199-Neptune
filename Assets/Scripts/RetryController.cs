using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryController : MonoBehaviour
{
    public void OnClickRetry()
    {
        string lastScene =
            PlayerPrefs.GetString("LastScene", "Stage1");

        SceneManager.LoadScene(lastScene);
    }

    public void OnExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}