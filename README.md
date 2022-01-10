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

`OnBecameInsivisible` tells us if the game object has left the screen, in other words, not visible on the screen anymore. This can be used to prevent wasting resources on game objects that are not seen in the scene anymore.

#### Tags
`GameObject.FindWithTag(<string>);` returns one active `GameObject` with the tag `<string>`.

`GameObject.FindGameObjectsWithTag(<string>)` returns a list of active game objects tagged `<string>`. This will be useful if we want to know how many active game objects tagged `<string>` there are using the `Length` property.

## Course 2 Week 2 (C2w2)
### Summary
Learned about handling inputs such as the keyboard, mouse, and the joystick/gamepad. The **Input Manager** and adding new axes, they provide the name of the controls/inputs and how they are interacted, and how to access them using `Input.GetAxes`.

Also, learned about _"clamping"_ a game object, in other words, maintaining that game object within the screen.

And other miscellaneous such as accessing game object's script methods.

### C#
It has not been taught in this week.

### Unity
#### Input Handling
##### Mouse Inputs
Mouse inputs can be obtained using `Input.GetMouseButtonDown(<int>)` or `Input.GetMouseButtonUp(<int>)`.

> A point to be aware of is that there is a method called `Input.GetMouseButton` which acts the same as `Input.GetMouseButtonDown` but will continuously return true while the given button is held. So caution not to confuse them.

##### Inputs Using Axes
Since `Input.GetAxis` returns a float, it depends on what the meaning of a positive or negative input is. (More about this on [Input.GetAxis](https://docs.unity3d.com/ScriptReference/Input.GetAxis.html))

```csharp
if (Input.GetAxis("NameOfTheAxisToCheck") > 0)
{
    // code...
}
```

#### Screen And Clamping
Created a static `ScreenUtils` class which initializes its fields on screen coordinates of the camera to their world locations for efficiency. This static class is then used for implementing clamping. It also uses the methods `Screen.width` and `Screen.height` to get the main camera's coordinates. And it gets initialized by the `GameInitializer` class attached to the main camera inside the `Awake` method of `MonoBehaviour`.

#### Awake and Start
Explained the difference between `Awake` and `Start` which `Awake` gets called when instantiated and `Start` gets called when the game moved to the next frame.

#### Regions
Utilized _regions_ to increase code readability.
```csharp
#region Name of the Region

// code...

#endregion
```

> regions can be collapsed using an advanced editor like Visual Studio.

## Course 2 Week 3 (C2w3)
No dedicated folder has been made for this week because it touches on the basic stuff about loops: _while_ and _for_.

> Which strangely enough, the instructor did not teach about _do-while_ loops.

## Course 2 Week 4 (C2w4)
### Summary
Learned about _.dll_ files (Dynamic-link Library) and how to add then use them.

Also learned about arrays and lists, enumerations, and some `MonoBehaviour` methods and tags and some physics.

### C#
#### Lists
Of course, arrays are simple so I rather not go in to them. Same goes for lists but I will list down the syntaxes, so to speak, of C#'s `List` class.

> To be able to use `List`, you need to add its directive `using System.Collections.Generic`.

```csharp
// creating a list
List<dataType> list = new List<dataType>();

// Adding an element
list.Add(value);

// Adding an array
list.AddRange(array);

// Removing an element
list.Remove(value);
list.RemoveAt(<index>);

// Clearing the list (removing all elements)
list.Clear();

// Get size of list
list.Count();
```

#### foreach Loop
It is the same as the _for_ loop but it iteratively accesses an element without the use of an index.

```csharp
foreach (DataType element in list)
{
    // some code...
}
```

#### Using Loops While Removing Element
It is **recommended** and **wise** to use a backward loop rather than a forward one when removing an element in a loop. Why? That's because if we were to use a forward loop, when we removed an item, it will ignore the next element because that next element used to be the next until we removed an element and it got pushed down.

```csharp
for (int i = list.Count() - 1; i >= 0; i--)
{
    if (someCondition)
    {
        list.RemoveAt(i);
    }
}
```

Improper way: forward loop
```csharp
for (int i = 0; i < list.Count(); i++)
{
    if (someCondition)
    {
        list.RemoveAt(i);
    }
}
```

#### Enumeration
List of defined constants to increase code readability.

##### Creating an enumeration class
```csharp
public enum EnumerationName
{
    Element1,
    Element2,
    Element3
}
```

##### Converting Enum Element To String
```csharp
string str = EnumerationName.Element1.ToString();
```

##### MonoBehaviour Related Methods
`OnMouseDown` gets called when user clicked inside of the game object's colliders. `OnTriggerStay2D` gets called when it detects it is inside of another game object's collider, which is better than `OnCollisionEnter2D` if it so happens we triggered multiple game objects at once.

> In order for `OnTriggerStay2D` to work, we must make sure we ticked off **Is Trigger** check-box in the game object's Inspector.

##### Setting Tags Dynamically
```csharp
GameObject.tag = nameOfNewTagString;
```

##### Resetting Force (Physics 2D)
To reset the applied force from using `RigidBody2D.AddForce`, we simply set its velocity to zero.

```csharp
someRigidBody2D.velocity = Vector2.zero;
```
