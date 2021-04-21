using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    [Header("Handlers")]
    public LaneHandler laneHandler;
    public Image backgroundImage;

    [Header("Score UI")]
    public TextMeshProUGUI comboText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI multiplierText;
    public TextMeshProUGUI gradeText;

    [Header("End Game Screen")]
    public GameObject endGameCanvas;
    public TextMeshProUGUI finalScoreTextEnd;
    public TextMeshProUGUI largestComboTextEnd;
    public TextMeshProUGUI gradeTextEnd;
    public TextMeshProUGUI hitMissTextEnd;

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
    public int notesGenerated;
    public int notesProcessed;

    private int score;
    private int scoreOld;
    private int notesHit = 0;
    private int notesMissed = 0;
    private int combo = 0;
    private int largestCombo = 0;
    private int multiplier = 1;
    private float lastNoteTime;
    private string currentGrade;

    public TextMeshProUGUI pressAnyKey;
    public GameObject buttonControls;
    public Slider healthSlider;
    public bool isPaused;
    public bool songStarted;
    private bool setup;

    void Start()
    {
        this.gameInfo = FindObjectOfType<GameInfo>();
        if (gameInfo)
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
                healthSlider.maxValue = 40f;
                break;
            case Difficulty.Normal:
                difficultyScale = 2f;
                healthSlider.maxValue = 20f;
                break;
            case Difficulty.Hard:
                difficultyScale = 3f;
                healthSlider.maxValue = 10f;
                break;
        }

        laneHandler.AdjustDifficulty(difficultyScale);
        song.clip.LoadAudioData();

        if (gameInfo)
        {
            redButton.SetKey(gameInfo.GetButtonKeys()[0]);
            orangeButton.SetKey(gameInfo.GetButtonKeys()[1]);
            yellowButton.SetKey(gameInfo.GetButtonKeys()[2]);
            greenButton.SetKey(gameInfo.GetButtonKeys()[3]);
            blueButton.SetKey(gameInfo.GetButtonKeys()[4]);
            purpleButton.SetKey(gameInfo.GetButtonKeys()[5]);
        }
        else
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
        if (notesGenerated == notesProcessed)
        {
            EndGame();
        }
        if (started)
        {
            laneHandler.MoveBeats(new Vector3(0f, bps * Time.deltaTime * difficultyScale, 0f));
            if (!(score == scoreOld) || combo == 0)
            {
                UpdateScore();
            }
            if (songStarted)
            {
                if (!(song.isPlaying) && !(isPaused))
                {
                    song.Play();
                }
            }

            UpdateHealth(-0.5f * (bps * Time.deltaTime));
            if (healthSlider.value <= 0)
            {
                EndGame();
            }
        }
        else
        {
            if (!setup)
            {
                Start();
                setup = true;
            }
            if (Input.anyKeyDown)
            {
                pressAnyKey.gameObject.SetActive(false);
                buttonControls.SetActive(false);
                started = true;
                //song.PlayDelayed(bps);

            }
        }
    }

    public Button GetButton(GameHandler.Color color)
    {
        switch (color)
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
        notesProcessed++;
        if (Time.time - lastNoteTime <= 0.08f)
        {
            score += (points * multiplier) / 3;
            UpdateHealth(1.5f);
            return;
        }
        UpdateHealth(4.0f);
        healthSlider.value = healthSlider.value + 1;
        notesHit++;
        combo++;
        if (combo > largestCombo)
        {
            largestCombo = combo;
        }
        if (combo >= 25 && combo < 50)
        {
            multiplier = 2;
        }
        else if (combo >= 50 && combo < 75)
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

    private void UpdateHealth(float amount)
    {
        healthSlider.value = healthSlider.value + amount;
    }

    public void MissedNote()
    {
        UpdateHealth(-2.0f);
        notesProcessed++;
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
        string grade = GetGrade();
        comboText.SetText(combo + "");
        scoreText.SetText(score + "");
        multiplierText.SetText(multiplier + "x");
        gradeText.SetText(grade);
        scoreOld = score;
    }

    private string GetGrade()
    {
        int bronze = notesGenerated * 60;
        int silver = notesGenerated * 120;
        int gold = notesGenerated * 180;
        int platinum = notesGenerated * 240;

        if (score >= bronze && score < silver)
        {
            return "Bronze";
        }
        else if (score >= silver && score < gold)
        {
            return "Silver";
        }
        else if (score >= gold && score < platinum)
        {
            return "Gold";
        }
        else if (score >= platinum)
        {
            return "Platinum";
        }
        else
        {
            return "No Grade";
        }
    }

    private string GetGradeEnd()
    {
        int bronze = notesGenerated * 60;
        int silver = notesGenerated * 120;
        int gold = notesGenerated * 180;
        int platinum = notesGenerated * 240;

        if (score >= bronze && score < silver)
        {
            return "Bronze\nSilver in: " + (silver - score) + "pts";
        }
        else if (score >= silver && score < gold)
        {
            return "Silver\nGold in: " + (gold - score) + "pts";
        }
        else if (score >= gold && score < platinum)
        {
            return "Gold\nPlatinum in: " + (platinum - score) + "pts";
        }
        else if (score >= platinum)
        {
            return "Platinum";
        }
        else
        {
            return "None\nBronze in: " + (bronze - score) + "pts";
        }
    }

    public void EndGame()
    {
        finalScoreTextEnd.SetText("Final Score: " + score);
        largestComboTextEnd.SetText("Largest Combo: " + largestCombo);
        if (notesMissed > 0)
        {
            float totalNotes = notesMissed + notesHit;
            float percentage = (notesHit / totalNotes) * 100;
            string finalPercentage = percentage.ToString("0.00");
            hitMissTextEnd.SetText("Hit/Miss: " + notesHit + "/" + notesMissed + " | " + finalPercentage + "%");
        }
        else
        {
            hitMissTextEnd.SetText("Hit/Miss: " + 0 + "/" + 0 + " | " + 0 + "%");
        }
        gradeText.SetText("Grade: " + GetGradeEnd());
        endGameCanvas.SetActive(true);
    }

    public void SetNotesGenerated(int notesGenerated)
    {
        this.notesGenerated = notesGenerated;
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
