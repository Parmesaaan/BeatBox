using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    [Header("Handlers")]
    public LaneHandler laneHandler;
    public TextMeshProUGUI scoreText;
    public Image backgroundImage;

    [Header("Buttons")]
    public Button redButton;
    public Button orangeButton;
    public Button yellowButton;
    public Button greenButton;
    public Button blueButton;
    public Button purpleButton;

    [Header("Controls")]
    public KeyCode red;
    public KeyCode orange;
    public KeyCode yellow;
    public KeyCode green;
    public KeyCode blue;
    public KeyCode purple;

    [Header("Game")]
    public AudioSource song;
    public Difficulty difficulty = Difficulty.Easy;
    public float bpm;
    public float latencyModifier = 0.75f;

    private GameInfo gameInfo;
    private float bps;
    private bool started;
    private float difficultyScale;

    private int score;
    private int scoreOld;
    private int notesHit = 0;
    private int notesMissed = 0;
    private int combo = 0;
    private int multiplier = 1;
    private float lastNoteTime;

    public TextMeshProUGUI pressAnyKey;
    public bool isPaused;
    public bool songStarted;
    private bool setup;

    void Start()
    {
        this.gameInfo = FindObjectOfType<GameInfo>();
        if(gameInfo)
        {
            song.clip = gameInfo.GetMusic();
            bpm = gameInfo.GetBPM();
            difficulty = gameInfo.GetDifficulty();
            latencyModifier = gameInfo.GetLatencyModifier();
            backgroundImage.sprite = gameInfo.GetBackgroundImage();
        }

        songStarted = false;
        score = 0;
        scoreOld = 0;
        bps = bpm / 60f;

        switch (difficulty)
        {
            case Difficulty.Easy:
                difficultyScale = 1f;
                break;
            case Difficulty.Normal:
                difficultyScale = 2f;
                break;
            case Difficulty.Hard:
                difficultyScale = 3f;
                break;
        }

        laneHandler.AdjustDifficulty(difficultyScale);
        song.clip.LoadAudioData();

        if(gameInfo)
        {
            redButton.SetKey(gameInfo.GetButtonKeys()[0]);
            orangeButton.SetKey(gameInfo.GetButtonKeys()[1]);
            yellowButton.SetKey(gameInfo.GetButtonKeys()[2]);
            greenButton.SetKey(gameInfo.GetButtonKeys()[3]);
            blueButton.SetKey(gameInfo.GetButtonKeys()[4]);
            purpleButton.SetKey(gameInfo.GetButtonKeys()[5]);
        } else
        {
            redButton.SetKey(red);
            orangeButton.SetKey(orange);
            yellowButton.SetKey(yellow);
            greenButton.SetKey(green);
            blueButton.SetKey(blue);
            purpleButton.SetKey(purple);
        }

        setup = true;
    }

    void Update()
    {

        if (started)
        {
            laneHandler.MoveBeats(new Vector3(0f, bps * Time.deltaTime * difficultyScale, 0f));
            if(!(score == scoreOld) || combo == 0)
            {
                UpdateScore();
            }
            if(songStarted)
            {
                if(!(song.isPlaying) && !(isPaused))
                {
                    song.Play();
                }
            }
        }
        else
        {
            if(!setup)
            {
                Start();
                setup = true;
            }
            if (Input.anyKeyDown)
            {
                pressAnyKey.gameObject.SetActive(false);
                started = true;
                //song.PlayDelayed(bps);
                
            }
        }
    }

    public Button GetButton(GameHandler.Color color)
    {
        switch(color)
        {
            case Color.Red:
                return redButton;
            case Color.Orange:
                return orangeButton;
            case Color.Yellow:
                return yellowButton;
            case Color.Green:
                return greenButton;
            case Color.Blue:
                return blueButton;
            case Color.Purple:
                return purpleButton;
            default:
                return null;
        }
    }

    public void HitNote(int points)
    {
        if(Time.time - lastNoteTime <= 0.08f)
        {
            score += (points * multiplier) / 3;
            return;
        }
        notesHit++;
        combo++;
        if(combo >= 25 && combo < 50)
        {
            multiplier = 2;
        }
        else if(combo >= 50 && combo < 75)
        {
            multiplier = 3;
        }
        else if (combo >= 75 && combo < 100)
        {
            multiplier = 4;
        }
        else if (combo >= 100)
        {
            multiplier = 5;
        }
        score += points * multiplier;
        lastNoteTime = Time.time;
    }

    public void MissedNote()
    {
        combo = 0;
        multiplier = 1;
        notesMissed++;
    }

    public void Reset()
    {
        song.Stop();
        started = false;
        setup = false;
        laneHandler.Reset();
    }

    private void UpdateScore()
    {
        scoreText.SetText("Score: " + score + "\nCombo: " + combo + "\nMultiplier: " + multiplier + "x");
        scoreOld = score;
    }

    public enum Difficulty
    {
        Easy,
        Normal,
        Hard
    }

    public enum Color
    {
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Purple
    }

}
