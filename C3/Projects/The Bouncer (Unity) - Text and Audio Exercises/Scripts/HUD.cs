using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    Text bounceText;
    int totalBounces = 0;
    const string BounceTextPrefix = "# of bounces: ";

    // Start is called before the first frame update
    void Start()
    {
        AddBounce(0);
    }

    // Add bounce
    public void AddBounce(int numberOfBounce)
    {
        totalBounces += numberOfBounce;
        bounceText.text = BounceTextPrefix + totalBounces.ToString();
    }
}
