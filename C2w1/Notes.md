# Notes
## Contents
[Tags](#tags)
  - [Making a new tag](#making-a-new-tag)
  - [Adding a tag to a game object](#adding-a-tag-to-a-game-object)

[Animated Sprites](#animated-sprites)
  - [Setting up the sprites](#setting-up-the-sprites)
  - [Setting up the Animator component](#setting-up-the-animator-component)
  - [Setting up the script](#setting-up-the-script)

## Tags
_"A Tag is a reference word which you can assign to one or more GameObjects. Tags help you identify GameObjects for scripting purposes"_ (From the Scripting API, [Tags](https://docs.unity3d.com/Manual/Tags.html))

### Making a new tag
- Select a game object in the `Hierarchy` window
- Click the drop-down list near the `Tag` text just below the game object's name
- Click `Add Tag`, this will open up the `Tags & Layers` window
- Click the `+` button under `Tags` to add a new tag
- Name this tag and save

### Adding a tag to a game object
- Select a game object in the `Hierarchy` window
- Click the drop-down list near the `Tag` text just below the game object's name
- Select a tag to attach to the game object

> For code/script related, refer to the Unity.md file.

## Animated Sprites
The steps to make an animated explosion will be discussed here.

### Setting up the sprites
1. Select the explosion sprite in the `Sprites` folder and set the `Sprite Mode` to `Multiple` in the `Inspector` window.
2. Open up the `Sprite Editor` from the `Inspector` window then select `Slice`
3. From the `Slice` popup window, specify here how the sprites should be "spliced" then apply and close the `Sprite Editor`

### Setting up the Animator component
4. Drag the explosion sprite (not the individual ones) onto the `Hierarchy` window and change the name of the new game object to _Explosion_
5. Add an `Animator` component by clicking the `Add Component` button then selecting `Miscellaneous` > `Animator` (NOT `Animation`!)
6. Create `Animations` and `Controllers` folders in the `Project` window
7. Right click the new `Controller` folder then select `Create` > `Animator Controller` and name the new controller _explosionController_
8. Select the _Explosion_ game object in the `Hierarchy` window and drag the _explosionController_ from the `Controllers` folder in the `Project` window onto the `Controller` field of the `Animator` component in the `Inspector` window
9. Double click the _explosionController_ in the `Controllers` folder (this will open up a tab called `Animator`, also make sure you are on the `Animator` tab) then open up the `Animation` window by selecting `Window` > `Animation` > `Animation`
10. Select the _Explosion_ game object from the `Hierarchy` window then in the `Animation` window, click the `Create` button to create a new animation clip
11. In the file navigation popup, select the `Animations` folder, navigate into that folder, change the file name to _Exploding_ then click `Save`
12. Expand the explosion sprite from the `Sprites` folder in the `Project` window and select all the children and drag them into the `Animation` window
13. Adjust the frames from the `Sample` text box (if this is hidden, click on the three vertical dots just below the `X` on the upper right and select `Show Sample Rate`) then close the `Animation` window and the `Animator` tab

At this point, if we try and play, the game object will explode recursively so to prevent this, we can attach a script to tell the game object to destroy itself after playing the animation

### Setting up the script
14. Create a new script called _Explosion_ in the `Scripts` folder in the `Project` window and also drag this script to the _Explosion_ game object to attach it
15. Open the _Explosion_ script to edit and paste the code below

```csharp
public class Explosion : MonoBehaviour
{
    // cached for efficiency
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            Destroy(gameObject);  
        }
    }
}
```

[GetCurrentAnimatorStateInfo](https://docs.unity3d.com/ScriptReference/Animator.GetCurrentAnimatorStateInfo.html) takes in a `layerIndex` then returns an [AnimatorStateInfo](https://docs.unity3d.com/ScriptReference/AnimatorStateInfo.html) which tells the current or next state of the animation.

The `layerIndex` is _"actually the index of Layer in Animator Tab. Base Layer is default in Animator which is counted as 0 as a Layer Index. If you have more Layers then add up the indexes according to that."_ [source](https://answers.unity.com/questions/1428729/anyone-could-explain-for-me-animatorgetcurrentanim.html)

The `normalizedTime` field is a float, where the integer part is the number of times the animation has looped and the fractional part represents the percent progress in the current loop.\
That means that when the `normalizedTime` hits `1`, it has just completed the first loop through the animation frames.

16. Save the script, watch that it works then drag this game object to the `Prefabs` folder in the `Project` window
17. Delete the game object and now we can use the prefab version of it to dynamically attach it to game objects in runtime
