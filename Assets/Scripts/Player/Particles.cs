using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    private void Update()
    {
        Destroy(gameObject, 0.5f);
    }
}
