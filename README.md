# Learning C# and Unity
I will be writing here all of those nifty code snippets that I learn from the
C#/Unity course.  
Also, when I said nifty codes, only nifty codes! I won't be explaining whatever
basic concepts were required like what a class, inheritance, virtual, etc. are.  
That aside, there will surely be notes when they are necessary.

> Writing such a description for myself, ah! I ought mine future self aide-memoires.

## Content
[Course 1 Week 1 (C1w1)](#course-1-week-1-c1w1)
  - [C#](#c)
  - [Unity](#unity)

[Course 1 Week 2 (C1w2)](#course-1-week-2-c1w2)
  - [C#](#c-1)
  - [Unity](#unity-1)

[Course 1 Week 3/4 (C1w3-4)](#course-1-week-34-c1w3-4)
  - [Summary](#summary)
  - [C#](#c-2)
  - [Unity](#unity-2)

[Course 2 Week 1 (C2w1)](#course-2-week-1-c2w1)
  - [Summary](#summary-1)
  - [C#](#c-3)
    - [SerializeField](#serializefield)
    - [as Keyword](#as-keyword)
  - [Unity](#unity-3)
    - [Animation related](#animation-related)
    - [Spawning related](#spawning-related)
    - [Tags](#tags)


## Course 1 Week 1 (C1w1)
### C#
Started with basic input/output and some math functions.  

```csharp
Console.Write(string);
Console.WriteLine(string);
int.Parse(Console.ReadLine());
float.Parse(Console.ReadLine());

// Math related
Math.PI
Math.Sin(<radians>);
Math.Cos(<radians>);
```

### Unity
Output to console.

```csharp
print(string);
```

## Course 1 Week 2 (C1w2)
### C#
Creating objects, accessing methods, and random number generator.  

```csharp
Random rand = new Random(); // Create object
rand.next(int);             // Accessing method, returns a random integer
                            // between 0 to the specified int
```

### Unity
Unity wasn't taught in this week.

## Course 1 Week 3/4 (C1w3-4)
It seems that the course's structure has changed.\
Former week 4 has been pushed to Course 2 Week 1 whilst Week 3 became Week 4.

### Summary
Learned about what are sprites, game objects, unity's component system, debugging a script, 2D physics, collisions, and prefabs.

### C#
Codes related solely to C# wasn't taught in this week.

### Unity
Changing game object's scale using `transform.localScale`, using `Rigidbody2D` to add gravity to a game object, and resolving collisions by overriding `OnCollisionEnter2D`.

## Course 2 Week 1 (C2w1)
### Summary
Learned about time properties (`Time.deltaTime` and `Time.time`) and made a `Timer` script with those.\
Made a spawner script which spawns game objects into the game world and also, learned to make explosion animations and attach these to a game object to explode it.

### C#
#### SerializeField
`[SerializeField]` shows up the private fields of a script in the Unity Editor (Inspector window).

#### as Keyword
`as` keyword is a type casting method which returns `null` instead of an exception if cannot successfully perform the cast. It also cannot be used on primitive types.

```csharp
GameObject gameObject = Instantiate(somePrefab) as GameObject;
int num = someFloat as int; // NOT POSSIBLE!
```

### Unity
#### Animation related
`Animator.GetCurrentAnimatorStateInfo(<layerIndex>).normalizedTime` returns a float where the integer part tells how many times the animation has looped and the decimal part tells the progress of the animation.

#### Spawning related
`Camera.main.ScreenToWorldPoint(<Vector3>)` returns a `Vector3` which contains the coordinates in the game world by the specifed `<Vector3>` screen coordinates.

`Instantiate<GameObject>(<Object>, <Vector3>, <Quaternion>)` creates a game object in the game world in the `<Vector3>` location. `<Quaternion>` specifies the rotation of the game object when spawned.

`Quaternion.identity` means no rotation.

`Destroy(<Object>)` erases the specified game object `<Object>` from the game world.

#### Tags
`GameObject.FindWithTag(<string>);` returns one active `GameObject` with the tag `<string>`.
