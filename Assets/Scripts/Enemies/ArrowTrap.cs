using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    [SerializeField] private float _attackCoolDown;
    [SerializeField] private Transform _firtePoint;
    [SerializeField] private GameObject[] _arrows;
    private float coolDownTimer;

    private void Attack()
    {
        coolDownTimer = 0;

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
        coolDownTimer += Time.deltaTime;

        if (coolDownTimer >= _attackCoolDown)
            Attack();
    }
}
