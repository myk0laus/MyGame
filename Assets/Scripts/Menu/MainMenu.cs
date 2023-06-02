using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private CardForPlayer _card;
    [SerializeField] private AudioMixerGroup Mixer;

    public void PlayGame()
    {
        _card.SetCountChoosedZero();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + LevelManager.instance.levelUnlock);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ChangeVolume(float volume)
    {
        Mixer.audioMixer.SetFloat("Volume", Mathf.Lerp(-80, 20, volume));
    }
}