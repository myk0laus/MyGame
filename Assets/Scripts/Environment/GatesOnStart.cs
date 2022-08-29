using UnityEngine;

public class GatesOnStart : MonoBehaviour
{
    [SerializeField] private Transform _posToGo;
    [SerializeField] private float _speed;
    [SerializeField] private AudioClip _gatesOpening;

    private int counter = 0;
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
            counter++;
            SoundManager.instance.PlaySound(_gatesOpening);
            if (counter > 1)          
                _gatesOpening = null;
                        
            transform.position = Vector2.MoveTowards(transform.position, _moveTo, _speed * Time.deltaTime);
        }
    }
}
