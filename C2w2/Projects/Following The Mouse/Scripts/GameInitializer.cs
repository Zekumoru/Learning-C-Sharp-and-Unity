using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    // Awake is called before Start
    void Awake()
    {
        // initialize screen utils
        ScreenUtils.Initialize();
    }
}
