using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FinishPlate : MonoBehaviour
{
    [SerializeField] private TMP_Text _finishValue;
    [SerializeField] private GameTimer _gameTimer;
    //[SerializeField] private CardForPlayer _card;

    private void Update()
    {
        _finishValue.text = Mathf.Round(_gameTimer.FinishValue).ToString();
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        //_card.SetCountChoosedZero();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        //_card.SetCountChoosedZero();
    }
}
