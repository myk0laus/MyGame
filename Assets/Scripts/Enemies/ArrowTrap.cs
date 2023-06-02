using UnityEngine;
using System.Collections.Generic;

public class ArrowTrap : MonoBehaviour
{
    [SerializeField] private float _attackCoolDown;
    [SerializeField] private Transform _firtePoint;
    [SerializeField] private GameObject[] _arrows;
    private float _coolDownTimer;

    private void Attack()
    {
        _coolDownTimer = 0;

        _arrows[FindFireball()].transform.position = _firtePoint.position;
        _arrows[FindFireball()].GetComponent<EnemyProjectile>().ActivateProjectile();
    }

    private int FindFireball()
    {
        for (int i = 0; i < _arrows.Length; i++)
        {
            if (!_arrows[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

    private void Update()
    {
        _coolDownTimer += Time.deltaTime;

        if (_coolDownTimer >= _attackCoolDown)
            Attack();
    }
}
