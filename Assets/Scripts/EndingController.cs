using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingController : MonoBehaviour
{
    public void OnClickHome()
    {
        SceneManager.LoadScene("Starting");
    }

    public void OnExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}