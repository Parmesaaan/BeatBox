using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused;

    public GameObject pauseMenuUI;
    public AudioSource audioSource;
    public GameHandler gameHandler;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        gameHandler.isPaused = false;
        audioSource.UnPause();
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        gameHandler.isPaused = true;
        audioSource.Pause();
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        //GameInfo gameInfo = FindObjectOfType<GameInfo>();
        //GameObject gameInfoParent = gameInfo.gameObject;
        //if(gameInfo)
        //{
        //    Destroy(gameInfo);
        //    Destroy(gameInfoParent);
        //}
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
        gameHandler.isPaused = false;
        gameHandler.Reset();
        GameIsPaused = false;
    }
}
