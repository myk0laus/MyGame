using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform _pos1, _pos2;
    [SerializeField] private Transform _startPos;
    [SerializeField] private float _speed;
    Vector3 _nextPos;

    void Start()
    {
        _nextPos = _startPos.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _nextPos, _speed * Time.deltaTime);

        if (transform.position == _pos1.position)
        {
            _nextPos = _pos2.position;
        }
        else if (transform.position == _pos2.position)
        {
            _nextPos = _pos1.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}
