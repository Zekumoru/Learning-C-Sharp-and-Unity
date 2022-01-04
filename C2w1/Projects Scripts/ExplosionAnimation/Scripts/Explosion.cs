using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // cached for efficiency
    Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    /// <summary>
    /// Update is called once per frame
    /// 
    /// The normalizedTime field is a float, where the integer part is
    /// the number of times the animation has looped and the fractional 
    /// part represents the percent progress in the current loop.
    /// 
    /// That means that when the normalizedTime hits 1, it has just 
    /// completed the first loop through the animation frames.
    /// </summary>
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            Destroy(gameObject);  
        }
    }
}
