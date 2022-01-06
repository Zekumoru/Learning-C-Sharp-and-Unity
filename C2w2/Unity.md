# Unity
## Get Mouse Position
To get the current position where the mouse is on the screen, we use:

```csharp
Vector3 position = Input.mousePosition;
```

`Input.mousePosition` is a static property that returns the current position of the mouse on the screen.

## Taking The Screen Size
To get the maximum width and height of the screen, we use `Screen.width` and `Screen.height`.\
Also, the screen starts at `x: 0` and `y: 0` in the lower left.

## Clamping A Game Object
We will be making a `ScreenUtils` and `GameInitializer` script to cache the world coordinates of the screen to improve performance then use these coordinates to clamp, or maintain, a game object within the screen.

### ScreenUtils
A static class we make to cache the world coordinates of the screen to avoid calculating them frame by frame.

```csharp
public static class ScreenUtils
{
    #region Fields

    // cached for efficient boundary checking
    static float screenLeft;
    static float screenRight;
    static float screenTop;
    static float screenBottom;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the left edge of the screen in world coordinates
    /// </summary>
    /// <value>left edge of the screen</value>
    public static float ScreenLeft
    {
        get { return screenLeft; }
    }

    /// <summary>
    /// Gets the right edge of the screen in world coordinates
    /// </summary>
    /// <value>right edge of the screen</value>
    public static float ScreenRight
    {
        get { return screenRight; }
    }

    /// <summary>
    /// Gets the top edge of the screen in world coordinates
    /// </summary>
    /// <value>top edge of the screen</value>
    public static float ScreenTop
    {
        get { return screenTop; }
    }

    /// <summary>
    /// Gets the bottom edge of the screen in world coordinates
    /// </summary>
    /// <value>bottom edge of the screen</value>
    public static float ScreenBottom
    {
        get { return screenBottom; }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Initializes the screen utilities
    /// </summary>
    public static void Initialize()
    {
        // initialize screen vertexes coordinates
        float screenZ = -Camera.main.transform.position.z;
        Vector3 lowerLeftCornerScreen = new Vector3(0, 0, screenZ);
        Vector3 upperRightCornerScreen = new Vector3(
            Screen.width, Screen.height, screenZ);

        // convert them to world coordinates
        Vector3 lowerLeftCornerWorld =
            Camera.main.ScreenToWorldPoint(lowerLeftCornerScreen);
        Vector3 upperRightCornerWorld =
            Camera.main.ScreenToWorldPoint(upperRightCornerScreen);

        // then assign them to cache
        screenLeft = lowerLeftCornerWorld.x;
        screenRight = upperRightCornerWorld.x;
        screenTop = upperRightCornerWorld.y;
        screenBottom = lowerLeftCornerWorld.y;
    }

    #endregion
}
```

### GameInitializer (for initializing ScreenUtils)
A class used to attach onto the main camera to load ScreenUtils.

```csharp
public class GameInitializer : MonoBehaviour
{
    // Awake is called before Start
    void Awake()
    {
        ScreenUtils.Initialize();
    }
}
```

`Awake()` is a method overridden from `MonoBehaviour` and it gets called first than `Start`.

### Clamping A Game Object
To make sure a game object stays on the screen, we can use the code below to do that:

```csharp
// saved for efficiency
float colliderHalfWidth;
float colliderHalfHeight;

// Awake is called when instantiated
void Awake()
{
    BoxCollider2D collider = GetComponent<BoxCollider2D>();
    colliderHalfWidth = collider.size.x / 2;
    colliderHalfHeight = collider.size.y / 2;
}

// maintain the game object within the screen
void ClampInScreen()
{
    // clamp position as necessary
    Vector3 position = transform.position;

    // check if it will exit the screen from the left
    if (position.x - colliderHalfWidth < ScreenUtils.ScreenLeft)
    {
        position.x = ScreenUtils.ScreenLeft + colliderHalfWidth;
    }
    // check if it will exit the screen from the right
    else if (position.x + colliderHalfWidth > ScreenUtils.ScreenRight)
    {
        position.x = ScreenUtils.ScreenRight - colliderHalfWidth;
    }

    // check if it will exit the screen from the top
    if (position.y + colliderHalfHeight > ScreenUtils.ScreenTop)
    {
        position.y = ScreenUtils.ScreenTop - colliderHalfHeight;
    }
    // check if it will exit the screen from the bottom
    else if (position.y - colliderHalfHeight < ScreenUtils.ScreenBottom)
    {
        position.y = ScreenUtils.ScreenBottom + colliderHalfHeight;
    }

    // finally, adjust position accordingly
    transform.position = position;
}
```

> This code was implemented with having in mind the game object following the mouse, if the mouse were to leave the screen, said game object must not leave the screen too. Hence the code above provides the functionality to _clamp_, in other words, maintain the game object inside the screen.

## Get Mouse Input
To check if a mouse input has occurred, we use `Input.GetMouseButtonDown(<int>)` or `Input.GetMouseButtonUp(<int>)`.

```csharp
if (Input.GetMouseButtonDown(0))
{
    print("Pressed left click!");
}
if (Input.GetMouseButtonDown(1))
{
    print("Pressed right click!");
}
if (Input.GetMouseButtonDown(2))
{
    print("Pressed middle click!");
}
```

Notice that we did not use `else if` so that we can process if multiple mouse buttons were pressed. Also, as you may have noticed, `0` means left, `1` means right, and `2` means the middle mouse button.

> A point to be aware of is that there is a method called `Input.GetMouseButton` which acts the same as `Input.GetMouseButtonDown` but will continuously return true while the given button is held. So caution not to confuse them.

## Additional Things Learned
### Accessing Methods Attached From A Game Object
Say we instantiated a new game object and we also had to call a method inside of that game object.\
First we take the script component that has that method we need then call it.

```csharp
GameObject gameObject = Instantiate<GameObject>(somePrefab, position, Quaternion.identity);
gameObject.GetComponent<TheScriptThatHasTheMethodWeNeed>().ThatMethod();
```

### Awake vs Start
It happened to me while experimenting that for some unknown reason, the `BoxCollider2D` field I have in a script was not initialized, in other words, it was still `null`. The problem was that it will be assigned when the `Start` method of `MonoBehaviour` gets called in the **next frame** hence when I needed that `BoxCollider2D` it was still `null` when I first instantiated the game object because it will be assigned in the next frame.

To solve this issue, rather than assigning it inside the `Start` method, we rather use the `Awake` method because it gets called when **the object first gets instantiated**.
