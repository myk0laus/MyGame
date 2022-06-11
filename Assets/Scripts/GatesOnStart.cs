using UnityEngine;

public class GatesOnStart : MonoBehaviour
{
    [SerializeField] private Transform _posToGo;
    [SerializeField] private float _speed;
    Vector2 _moveTo;

    public bool CanMoveUp { get; set; }

    private void Start()
    {
        _moveTo = _posToGo.position;
    }

    private void Update()
    {
        if (CanMoveUp)
        {
            transform.position = Vector2.MoveTowards(transform.position, _moveTo, _speed * Time.deltaTime);
        }
    }
}
