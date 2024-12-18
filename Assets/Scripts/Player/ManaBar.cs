using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    [SerializeField] private Slider _manaBarslider;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Image _fillingImage;

    public void SetMaxMana(int manaAmount)
    {
        _manaBarslider.maxValue = manaAmount;
        _manaBarslider.value = manaAmount;
        _fillingImage.color = _gradient.Evaluate(_manaBarslider.normalizedValue);
    }

    public void SetMana(int manaAmount)
    {
        _manaBarslider.value = manaAmount;
        _fillingImage.color = _gradient.Evaluate(_manaBarslider.normalizedValue);
    }
}