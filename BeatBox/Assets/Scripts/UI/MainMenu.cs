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
        audioMixer.SetFloat("MusicVolumeParam", volume * 2f);
    }

    public void SetVolumeUI(float volume)
    {
        audioMixer.SetFloat("UIVolumeParam", volume * 2f);
    }
}
