using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform _pos1, _pos2;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _startPos;

    Vector3 nextPos;

    void Start()
    {
        nextPos = _startPos.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextPos, _speed* Time.deltaTime );
        
        if(transform.position == _pos1.position)
        {
            nextPos = _pos2.position;
        }
        else if(transform.position == _pos2.position)
        {
            nextPos = _pos1.position;
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
