using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{  
    [SerializeField] private Button[] _levels;
    public static LevelManager instance;
    public int levelUnlock;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        levelUnlock = PlayerPrefs.GetInt("levels", 1);

        for (int i = 0; i < _levels.Length; i++)
        {
            _levels[i].interactable = false;
        }

        for (int i = 0; i < levelUnlock; i++)
        {
            _levels[i].interactable = true;
        }
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
}
