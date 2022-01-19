using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateLauncher : Launcher
{
    protected override void Start()
    {
        cooldownSeconds = 1f;
        base.Start();
    }
}
