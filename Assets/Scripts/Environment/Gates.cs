using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates : MonoBehaviour
{
    [SerializeField] private Transform _upPosForGates;
    public bool Activated { get; set; }
    Vector2 moveTo;

    private void Start()
    {
        moveTo = _upPosForGates.position;
    }
    private void Update()
    {
        if (Activated)
        {
            transform.position = Vector2.MoveTowards(transform.position, moveTo, 1 * Time.deltaTime); 
        }
    }
}
