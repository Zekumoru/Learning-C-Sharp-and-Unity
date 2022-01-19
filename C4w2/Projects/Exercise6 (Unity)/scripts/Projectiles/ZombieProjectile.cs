using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieProjectile : Projectile
{
    protected override void Start()
    {
        impulseForce.x = 9f;
        base.Start();
    }
}
