using UnityEngine;

public class Gates : MonoBehaviour
{
    [SerializeField] private Transform _upPosForGates;
    Vector2 _moveTo;
    public bool Activated { get; set; }

    private void Start()
    {
        _moveTo = _upPosForGates.position;
    }
    private void Update()
    {
        if (Activated)
        {
            transform.position = Vector2.MoveTowards(transform.position, _moveTo, 1 * Time.deltaTime);
        }
    }
}
