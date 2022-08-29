using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private TMP_Text _timerText;
    private float timerTime;
    public float FinishValue => timerTime;

    void Start()
    {
        timerTime = 0;
    }

    void Update()
    {
        timerTime += Time.deltaTime;
        _timerText.text = Mathf.Round(timerTime).ToString();
    }
}
