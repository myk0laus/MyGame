using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }

    private AudioSource source;

    private void Awake()
    {       
        source = GetComponent<AudioSource>();

        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != null && instance != this) 
        {
            Destroy(gameObject);
        }
        
    }

    public void PlaySound(AudioClip audioClip)
    {
        source.PlayOneShot(audioClip);
    }
}
