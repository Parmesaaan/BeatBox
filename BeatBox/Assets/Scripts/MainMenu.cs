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
        Application.ExternalEval("window.open(\"http://github.com/Parmesaaan/beatbox\")");
    }
}
