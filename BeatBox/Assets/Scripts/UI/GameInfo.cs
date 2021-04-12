using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInfo : MonoBehaviour
{
    private static GameInfo _instance;
    
    public AudioClip music;
    public Texture2D[] beatMaps;
    public float bpm;
    public GameHandler.Difficulty difficulty;
    public float fixedLatencyModifier;
    public float publicLatencyModifier = 0.0f;
    public float finalLatencyModifier;
    public Sprite backgroundImage;
    public KeyCode[] buttonKeys;

    private bool hasCustomControls;

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
        if(!hasCustomControls)
        {
            buttonKeys = new KeyCode[] { KeyCode.Q, KeyCode.W, KeyCode.E, KeyCode.I, KeyCode.O, KeyCode.P };
        }
    }

    private void Start()
    {
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
        this.fixedLatencyModifier = latencyModifier;
        this.finalLatencyModifier = this.fixedLatencyModifier + this.publicLatencyModifier;
    }

    public void SetPublicLatencyModifier(float latencyModifier)
    {
        this.publicLatencyModifier = latencyModifier/100f;
        this.finalLatencyModifier = this.fixedLatencyModifier + this.publicLatencyModifier;
    }

    public void SetBackgroundImage(Sprite backgroundImage)
    {
        this.backgroundImage = backgroundImage;
    }

    public void SetButtonKey(int keyIndex, KeyCode keyCode)
    {
        this.buttonKeys[keyIndex] = keyCode;
    }

    public void SetHasCustomControls(bool hasCustomControls)
    {
        this.hasCustomControls = hasCustomControls;
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
        return finalLatencyModifier;
    }

    public Sprite GetBackgroundImage()
    {
        return this.backgroundImage;
    }

    public KeyCode[] GetButtonKeys()
    {
        return buttonKeys;
    }

    public bool GetHasCustomControls()
    {
        return hasCustomControls;
    }

    public static GameInfo Instance { get { return _instance; } }
}
