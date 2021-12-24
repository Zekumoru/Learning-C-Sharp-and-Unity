# Learning C# and Unity
I will be writing here all of those nifty code snippets that I learn from the
C#/Unity course.  
Also, when I said nifty codes, only nifty codes! I won't be explaining whatever
basic concepts were required like what a class, inheritance, virtual, etc. are.  
That aside, there will surely be notes when they are necessary.

> Writing such a description for myself, ah! I ought mine future self aide-memoires.

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
