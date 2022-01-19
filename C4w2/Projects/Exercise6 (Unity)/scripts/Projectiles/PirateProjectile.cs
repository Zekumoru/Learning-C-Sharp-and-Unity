using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateProjectile : Projectile
{
    protected override void Start()
    {
        impulseForce.x = 3f;
        base.Start();
    }
}
