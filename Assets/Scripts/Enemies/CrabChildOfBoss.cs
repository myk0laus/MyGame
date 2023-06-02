using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabChildOfBoss : PatrolingCrab
{
    public static int countOfCrabs;

    void Start()
    {
        base.Start();
        countOfCrabs++;
    }
    private void Update()
    {
        base.Update();
    }
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        countOfCrabs--;
    }
}
