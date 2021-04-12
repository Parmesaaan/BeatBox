using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

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

    public void SetVolumeMusic(float volume)
    {
        audioMixer.SetFloat("MusicVolumeParam", Mathf.Log10(volume) * 20f);
    }

    public void SetVolumeUI(float volume)
    {
        audioMixer.SetFloat("UIVolumeParam", Mathf.Log10(volume) * 20f);
    }

    public void SetLatencyModifier(float latencyModifier)
    {
        GameInfo gameInfo = FindObjectOfType<GameInfo>();
        gameInfo.SetPublicLatencyModifier(latencyModifier);
    }
}
