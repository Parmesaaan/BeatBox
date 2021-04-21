using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

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

    public void SetDifficulty(int difficulty)
    {
        GameInfo gameInfo = FindObjectOfType<GameInfo>();
        gameInfo.SetDifficulty(difficulty);
    }

    public void SetLatencyModifier(float latencyModifier)
    {
        GameInfo gameInfo = FindObjectOfType<GameInfo>();
        gameInfo.SetPublicLatencyModifier(latencyModifier);
    }
}
