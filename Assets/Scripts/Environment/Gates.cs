using UnityEngine;

public class Gates : MonoBehaviour
{
    [SerializeField] private Transform _upPosForGates;
    [SerializeField] private AudioClip _gatesOpening;

    private int counter = 0;

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
            counter++;

            if (counter > 1)
            {
                _gatesOpening = null;
            }
            SoundManager.instance.PlaySound(_gatesOpening);
            transform.position = Vector2.MoveTowards(transform.position, _moveTo, 1 * Time.deltaTime);
        }
    }
}
