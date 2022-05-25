using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuUI : MonoBehaviour
{
    public static bool gameIsPaused = false;
    private string MenuScene = "MenuScene";
    private string GameScene = "GameScene";
    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == GameScene &&  Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void LoadMenuScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(MenuScene);
    }

    public void LoadGameScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(GameScene);
    }

    public void LoadSettings()
    {
        settingsMenuUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        Debug.Log("Load Settings ...");
    }

    public void BackToPauseMenu()
    {
        settingsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        Debug.Log("Load Settings ...");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game ...");
        Application.Quit();
    }
}