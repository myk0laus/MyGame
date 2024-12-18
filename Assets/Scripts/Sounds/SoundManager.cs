using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource _source;

    public static SoundManager instance { get; private set; }
    public AudioSource Source => _source;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip audioClip)
    {
        _source.PlayOneShot(audioClip);
    }
}
