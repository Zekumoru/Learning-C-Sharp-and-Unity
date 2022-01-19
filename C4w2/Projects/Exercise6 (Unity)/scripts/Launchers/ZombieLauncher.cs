using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieLauncher : Launcher
{
    protected override void Start()
    {
        cooldownSeconds = 0.5f;
        base.Start();
    }
}
