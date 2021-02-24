using UnityEngine;
using TMPro;

public class GameHandler : MonoBehaviour
{
    [Header("Handlers")]
    public LaneHandler laneHandler;
    public ButtonHandler buttonHandler;
    public TextMeshProUGUI scoreText;

    [Header("Controls")]
    public KeyCode red;
    public KeyCode orange;
    public KeyCode yellow;
    public KeyCode green;
    public KeyCode blue;
    public KeyCode purple;

    [Header("Game")]
    public AudioSource song;
    public AudioSource countInSound;
    public Difficulty difficulty = Difficulty.Normal;
    public float bpm;


    private float bps;
    private bool started;
    private float difficultyScale;
    private int score;
    private int scoreOld;

    void Start()
    {
        score = 0;
        scoreOld = 0;
        bps = bpm / 60f;
        switch (difficulty)
        {
            case Difficulty.Normal:
                difficultyScale = 1f;
                break;
            case Difficulty.Hard:
                difficultyScale = 2f;
                break;
            case Difficulty.Insane:
                difficultyScale = 3f;
                break;
        }
    }

    void Update()
    {

        if (started)
        {
            laneHandler.MoveBeats(new Vector3(0f, bps * Time.deltaTime * difficultyScale, 0f));
            if(!(score == scoreOld))
            {
                UpdateScore();
            }
        }
        else
        {
            if (Input.anyKeyDown)
            {
                song.PlayDelayed(bps);
                laneHandler.AdjustDifficulty(difficultyScale);
                started = true;
            }
        }
    }

    public KeyCode[] GetKeyCodes()
    {
        KeyCode[] keyCodes = {red, orange, yellow, green, blue, purple};
        return keyCodes;
    }

    public void AddPoints(float y)
    {
        score += (int) ((2f - Mathf.Abs(y)) * 100);
    }

    private void UpdateScore()
    {
        scoreText.SetText("Score: " + score);
        scoreOld = score;
    }

    public enum Difficulty
    {
        Normal,
        Hard,
        Insane
    }

}
