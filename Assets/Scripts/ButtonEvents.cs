using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class ButtonEvents : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("level 1");
    }

    public void QuitButton()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
