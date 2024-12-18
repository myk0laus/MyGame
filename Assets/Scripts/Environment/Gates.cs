using UnityEngine;

public class Gates : MonoBehaviour
{
    [SerializeField] private Transform _upPosForGates;
    [SerializeField] private AudioClip _gatesOpening;
    [SerializeField] private Lever _lever;
    [SerializeField] private int _speed;

    private Vector2 _moveTo;
    private bool _activated;

    private void OnEnable()
    {
        _lever.LeverTurned += OpenGates;
    }

    private void Start()
    {
        _moveTo = _upPosForGates.position;
    }
    private void Update()
    {
        if (_activated)           
            transform.position = Vector2.MoveTowards(transform.position, _moveTo, _speed * Time.deltaTime);
    }

    private void OpenGates()
    {
        _activated = true;
        SoundManager.instance.PlaySound(_gatesOpening);
        _lever.LeverTurned -= OpenGates;
    }
}
