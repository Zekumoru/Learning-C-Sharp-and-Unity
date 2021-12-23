# C-Sharp Code Snippets
## Printing to Screen

 - From exercise 1 and 3: Printing to the screen
```csharp
Console.WriteLine(string);
Console.WriteLine(); // an empty new line
```

 - From exercise 4: Taking an integer input
```csharp
Console.Write("Input: "); // writes to screen without newline
int input = int.Parse(Console.ReadLine());
Console.WriteLine("Your input is " + input);
```

- From exercise 6: Using math and taking float inputs
```csharp
Console.Write("Enter an angle in degrees: ");
float angleDegrees = float.Parse(Console.ReadLine());
// Since Math.Cos and Math.Sin use radians, let's convert our degrees
float angleRadians = angleDegrees * ((float) Math.PI / 180);
Console.WriteLine("Sine of " + angleDegrees + " degrees: " + Math.Sin(angleRadians));
Console.WriteLine("Cosine of " + angleDegrees + " degrees: " + Math.Cos(angleRadians));
```
