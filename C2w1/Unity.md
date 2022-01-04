# Unity
## Contents
[Time.deltaTime](#timedeltatime)

[Fluctuating Game Object's Size](#fluctuating-game-objects-size)

[Timer Implementation](#timer-implementation)

[Attaching Component Dynamically](#attaching-component-dynamically)

[Time.time](#timetime)

[Spawning A Game Object](#spawning-a-game-object)

[Tags](#tags)
  - [Find A Game Object](#find-a-game-object)
  - [Find How Many Game Objects In Scene](#find-how-many-game-objects-in-scene)

[OnBecameInsivisible](#onbecameinsivisible)

## Time.deltaTime
From exercise 1.\
`Time.deltaTime` returns _"the interval in seconds from the last frame to the current one"_. (From the Scripting API, [Time.deltaTime](https://docs.unity3d.com/ScriptReference/Time-deltaTime.html))

The code below calculates how much time have passed rendering _x_ frames.\
If it then already took a second, it will print a message.

```csharp
float totalElapsedTime = 0;
void Update()
{
    totalElapsedTime += Time.deltaTime;
    if (totalElapsedTime >= 1f)
    {
        print("A second has passed!");
        totalElapsedTime = 0;
    }
}
```

Basically what's happening (as how I understand it currently), each frame will take some tiny, tiny, tiny second to render then afterward it will move to the next frame. This tiny, tiny, tiny second is what we call `deltaTime`.\

Why do we need to add `deltaTime`? So that we will know, if a second has
passed, 2 seconds, a minute, etc. Since computers may be slow or fast, how much time they take to render one frame will always vary. Hence, if we then take this to our advantage, we can know how much in total have passed rendering _x_ frames if we put it in a variable.

## Fluctuating Game Object's Size
The code snippet of the `Resizer` class below implements the behavior that grows then shrinks a game object recursively.

```csharp
public class Resizer : MonoBehaviour
{
    // Timer support
    const float TotalResizeSeconds = 5f;
    float elapsedResizeSeconds = 0f;

    // Resizing control
    const float ScaleFactorPerSecond = 1f;
    int scaleFactorSignMultiplier = 1;

    // Update is called once per frame
    void Update()
    {
        // resize
        Vector3 newScale = transform.localScale;
        newScale.x += scaleFactorSignMultiplier * ScaleFactorPerSecond * Time.deltaTime;
        newScale.y += scaleFactorSignMultiplier * ScaleFactorPerSecond * Time.deltaTime;
        transform.localScale = newScale;

        // timer
        elapsedResizeSeconds += Time.deltaTime;
        if (elapsedResizeSeconds >= TotalResizeSeconds)
        {
            elapsedResizeSeconds = 0f;
            scaleFactorSignMultiplier *= -1;
        }
    }
}
```

## Timer Implementation
This is the implementation of the `Timer` class made by the instructor.

```csharp
public class Timer : MonoBehaviour
{
    #region Fields

    // timer duration
    float totalSeconds = 0f;

    // timer execution
    float elapsedSeconds = 0f;
    bool running = false;

    // support for Finished property
    bool started = false;

    #endregion

    #region Properties

    /// <summary>
    /// Sets the duration of the timer.
    /// The duration can only be set if the timer is not currently running.
    /// </summary>
    /// <value>duration</value>
    public float Duration
    {
        set { if (!running) totalSeconds = value; }
    }

    /// <summary>
    /// Gets the state of the timer if it is finished or not.
    /// Also, returns false if the timer has not started yet.
    /// </summary>
    /// <value>true if finished; otherwise, false.</value>
    public bool Finished
    {
        get { return started && !running; }
    }

    /// <summary>
    /// Gets the state of the timer if it is still running or not.
    /// </summary>
    /// <value>true if running; otherwise, false.</value>
    public bool Running
    {
        get { return running; }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Update is called once per frame.
    /// Also, this updates the timer and ends after it is finished.
    /// </summary>
    void Update()
    {
        if (running)
        {
            elapsedSeconds += Time.deltaTime;
            if (elapsedSeconds >= totalSeconds)
            {
                running = false;
            }
        }
    }

    /// <summary>
    /// Runs the timer.
    /// Only run the timer if the duration set is above 0.
    /// </summary>
    public void Run()
    {
        if (totalSeconds > 0)
        {
            started = true;
            running = true;
            elapsedSeconds = 0f;
        }
    }

    #endregion
}
```

## Attaching Component Dynamically
The snippet below shows how to add a component dynamically, meaning, attach a script in runtime.\
Let's say we want to add the `Timer` script from the code above as a new component of a game object.

```csharp
timer = gameObject.AddComponent<Timer>();
```

## Time.time
_"The time at the beginning of this frame (Read Only)."_ (From the Scripting API, [Time.time](https://docs.unity3d.com/ScriptReference/Time-time.html))

One way we can use this property is to find how long something has executed.

```csharp
startTime = Time.time; // assuming startTime is a field in the class
// some code...
float elapsedTime = Time.time;
print("It took " + elapsedTime + " to execute.");
```

## Spawning A Game Object
We first specify the location to spawn then instantiate the game object there.

```csharp
// decide where to spawn
Vector3 location = new Vector3(
    <x_location>,
    <y_location>,
    -Camera.main.transform.position.z);
// convert the spawn location from camera to world point
Vector3 worldLocation =  Camera.main.ScreenToWorldPoint(location);

// spawn it to the game world
GameObject gameObject = Instantiate(prefabGameObject) as GameObject;

// alternative way to spawn:
Instantiate<GameObject>(prefabGameObject, worldLocation,
    Quaternion.identity);
```

`Camera.main.transform.position.z` gives us the `z` position of the main camera, in other words, the screen.\
What basically happens here is that we are deciding in **which point in the screen** do we want to spawn the game object then from that, we convert those coordinates to the coordinates of the game world.\

> Why do we need to convert, i.e., use `Camera.main.ScreenToWorldPoint(location)`? Since the game world is 3D and the camera is 2D.

> **A quick note:** the camera, or screen, coordinates are in pixels.

`Quaternion` means rotation and `identity` means no rotation.

## Tags
### Find A Game Object
```csharp
GameObject gameObject = GameObject.FindWithTag(<string>);
```

Returns one active `GameObject` tagged `<string>`. Returns `null` if no `GameObject` was found. (From the Scripting API, [GameObject.FindWithTag](https://docs.unity3d.com/ScriptReference/GameObject.FindWithTag.html))

### Find How Many Game Objects In Scene
```csharp
GameObject.FindGameObjectsWithTag(<string>).Length
```

`GameObject.FindGameObjectsWithTag` returns an array of game objects tagged `<string>`. And the `Length` property will tell us how many there are.

## OnBecameInsivisible
We would want to remove a game object that are not visible anymore on the screen. We can use `OnBecameInsivisible` to check if it is outside the camera then destroy it.

```csharp
void OnBecameInvisible()
{
    Destroy(gameObject);
}
```

> `OnBecameInvisible` is part of the `MonoBehaviour` class hence it is overridden to your script.
