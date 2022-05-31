using UnityEngine;
using UnityEngine.SceneManagement;

public class PouseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;

    public static bool GameIsPaused = false;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))                 
            if (GameIsPaused)           
                Resume();        
            else           
               Pause();               
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void GuitGame()
    {
        Application.Quit();
    }
}
 