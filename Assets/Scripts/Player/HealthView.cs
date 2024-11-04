using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Image _fill;
    [SerializeField] private Gradient _gradient;

    public void SetMaxHp(int maxHp)
    {
        _slider.maxValue = maxHp;
        _slider.value = maxHp;
        _fill.color = _gradient.Evaluate(_slider.normalizedValue);
    }

    public void SetHp(int setHp)
    {
        _slider.value = setHp;
        _fill.color = _gradient.Evaluate(_slider.normalizedValue);
    }
}