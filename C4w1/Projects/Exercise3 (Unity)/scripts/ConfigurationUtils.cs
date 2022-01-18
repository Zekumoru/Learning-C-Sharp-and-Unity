﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    // Fields
    static ConfigurationData configData;

    /// <summary>
    /// Gets the teddy bear move units per second
    /// </summary>
    /// <value>teddy bear move units per second</value>
    public static float TeddyBearMoveUnitsPerSecond
    {
        get { return configData.TeddyBearMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the cooldown seconds for shooting
    /// </summary>
    /// <value>cooldown seconds</value>
    public static float CooldownSeconds
    {
        get { return configData.CooldownSeconds; }    
    }

    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        configData = new ConfigurationData();
    }
}
