using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInfo : MonoBehaviour
{
    private static GameInfo _instance;
    
    public AudioClip music;
    public Texture2D[] beatMaps;
    public float bpm;
    public GameHandler.Difficulty difficulty;
    public float latencyModifier;
    public KeyCode[] buttonKeys;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        buttonKeys = new KeyCode[] {KeyCode.Q, KeyCode.W, KeyCode.E, KeyCode.I, KeyCode.O, KeyCode.P};
        difficulty = GameHandler.Difficulty.Normal;

        DontDestroyOnLoad(transform.gameObject);
    }

    // Setters
    public void SetMusic(AudioClip music)
    {
        this.music = music;
    }

    public void SetBeatMaps(Texture2D[] beatMaps)
    {
        this.beatMaps = beatMaps;
    }

    public void SetBPM(float bpm)
    {
        this.bpm = bpm;
    }

    public void SetDifficulty(int difficulty)
    {
        switch (difficulty)
        {
            case 0:
                this.difficulty = GameHandler.Difficulty.Easy;
                break;
            case 1:
                this.difficulty = GameHandler.Difficulty.Normal;
                break;
            case 2:
                this.difficulty = GameHandler.Difficulty.Hard;
                break;
        }
    }

    public void SetLatencyModifier(float latencyModifier)
    {
        this.latencyModifier = latencyModifier;
    }

    public void SetButtonKey(int keyIndex, KeyCode keyCode)
    {

    }

    // Getters
    public AudioClip GetMusic()
    {
        return music;
    }

    public Texture2D[] GetBeatMaps()
    {
        return beatMaps;
    }

    public float GetBPM()
    {
        return bpm;
    }

    public GameHandler.Difficulty GetDifficulty()
    {
        return difficulty;
    }

    public float GetLatencyModifier()
    {
        return latencyModifier;
    }

    public KeyCode[] GetButtonKeys()
    {
        return buttonKeys;
    }

    public static GameInfo Instance { get { return _instance; } }
}
