using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingMace : MonoBehaviour
{
    [SerializeField] private float _smooth;
    Vector3 _rotateTo;
    void Start()
    {
        _rotateTo = new Vector3(0, 0, 80);
    }

    void Update()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(_rotateTo), _smooth);

        if(transform.rotation == Quaternion.Euler(_rotateTo))
        {
            _rotateTo = _rotateTo * -1;
        }
        else if (transform.rotation == Quaternion.Euler(_rotateTo * -1))
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(_rotateTo), _smooth);
        }
    }
}
