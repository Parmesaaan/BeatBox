using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");

    }

    public void OpenLink()
    {
        Application.OpenURL("github.com/Parmesaaan/beatbox/");
    }
}
