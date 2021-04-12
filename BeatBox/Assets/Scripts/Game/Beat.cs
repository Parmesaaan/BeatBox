using UnityEngine;

public class Beat : MonoBehaviour
{
    public GameHandler.Color color = GameHandler.Color.Red;
    public BeatType beatType = BeatType.Normal;
    private bool pressable;
    private Button button;
    private GameHandler gameHandler;

void Start()
    {
        pressable = false;
        gameHandler = FindObjectOfType<GameHandler>();

        switch(color)
        {
            case GameHandler.Color.Red:
                button = gameHandler.GetButton(GameHandler.Color.Red);
                break;
            case GameHandler.Color.Orange:
                button = gameHandler.GetButton(GameHandler.Color.Orange);
                break;
            case GameHandler.Color.Yellow:
                button = gameHandler.GetButton(GameHandler.Color.Yellow);
                break;
            case GameHandler.Color.Green:
                button = gameHandler.GetButton(GameHandler.Color.Green);
                break;
            case GameHandler.Color.Blue:
                button = gameHandler.GetButton(GameHandler.Color.Blue);
                break;
            case GameHandler.Color.Purple:
                button = gameHandler.GetButton(GameHandler.Color.Purple);
                break;
        }
    }

    void Update()
    {
        float gameStartOffset = ((float)gameHandler.bpm / 60f) * gameHandler.latencyModifier + difficultyAdjust(gameHandler.difficulty);
        if(gameObject.transform.position.y <= gameStartOffset)
        {
            if (!gameHandler.songStarted)
            {
                gameHandler.songStarted = true;
            }
        }

        if(gameObject.transform.position.y <= 1.5f)
        {
            pressable = true;
        }

        if(gameObject.transform.position.y <= -0.5f)
        {
            pressable = false;
        }

        if (pressable && button.isPressed())
        {
            int points = (int)((2f - Mathf.Abs(transform.position.y)) * 10);
            gameHandler.HitNote(points);
            gameObject.SetActive(false);
        }

        if (gameObject.transform.position.y <= -2f)
        {
            gameHandler.MissedNote();
            gameObject.SetActive(false);
        }
    }

    private float difficultyAdjust(GameHandler.Difficulty difficulty)
    {
        switch (difficulty)
        {
            case GameHandler.Difficulty.Easy:
                return -1f;
            case GameHandler.Difficulty.Normal:
                return 0f;
            case GameHandler.Difficulty.Hard:
                return 2.5f;
            default:
                return 0f;
        }
    }

    public enum BeatType
    {
        Normal,
        Sustained
    }
}
