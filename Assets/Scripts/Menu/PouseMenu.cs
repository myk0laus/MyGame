using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PouseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private AudioMixer _mixer;

    public static bool GameIsPaused = false;

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //    if (GameIsPaused)
        //        Resume();
        //    else
        //        Pause();
    }

    public void OpenPausePanel()
    {
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

    public void ChangeVolume(float volume)
    {
        _mixer.SetFloat("Volume", Mathf.Lerp(-80, 20, volume));
    }

    public void GuitGame()
    {
        Application.Quit();
    }
}
