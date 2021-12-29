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
