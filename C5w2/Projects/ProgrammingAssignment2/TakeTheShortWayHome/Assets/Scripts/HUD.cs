using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The HUD
/// </summary>
public class HUD : MonoBehaviour
{
    [SerializeField]
    Text pathLengthText;

    const string PathLenghtTextPrefix = "Path Length: ";

	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Awake()
	{
        EventManager.AddPathFoundListener(SetPathLength);
	}

    /// <summary>
    /// Sets the path length in the hud
    /// </summary>
    /// <param name="length">path length</param>
    void SetPathLength(float length)
    {
        if (length == float.MaxValue)
        { 
            pathLengthText.text = "Path not found!";
            return;
        }
        pathLengthText.text = PathLenghtTextPrefix + length.ToString();
    }
}
