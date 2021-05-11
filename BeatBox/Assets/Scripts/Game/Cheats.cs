using UnityEngine;

public class Cheats : MonoBehaviour
{
    public GameHandler gameHandler;

    public void ToggleInfiniteHealth(bool isTicked)
    {
        gameHandler.infiniteHealth = isTicked;
    }

    public void TogglePermaMultiplier(bool isTicked)
    {
        gameHandler.cantMiss = isTicked;
    }

    public void EndGameWin()
    {
        gameHandler.EndGame();
    }

    public void EndGameLoss()
    {
        gameHandler.endGameLose = true;
        gameHandler.EndGame();
    }
}
