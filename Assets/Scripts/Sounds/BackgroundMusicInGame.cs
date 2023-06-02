using UnityEngine;

public class BackgroundMusicInGame : MonoBehaviour
{
    [SerializeField] private GameObject _winSound;
    [SerializeField] private CheckPoint _checkpoint;

    void Update()
    {
        if (_checkpoint.Finished)
        {
            gameObject.SetActive(false);
            _winSound.SetActive(true);
        }
    }
}
