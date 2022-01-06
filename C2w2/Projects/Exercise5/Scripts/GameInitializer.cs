using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    // Awake gets called when instantiated
    void Awake()
    {
        ScreenUtils.Initialize();
    }
}
