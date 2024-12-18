using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private TMP_Text _timerText;
    private float _timerTime;
    public float FinishValue => _timerTime;

    void Start()
    {
        _timerTime = 0;
    }

    void Update()
    {
        _timerTime += Time.deltaTime;
        _timerText.text = Mathf.Round(_timerTime).ToString();
    }
}
