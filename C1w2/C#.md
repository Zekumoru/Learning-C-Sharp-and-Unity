# C-Sharp Code Snippets
## Creating objects
From exercises 8 and 9: Creating objects then calling its methods  

> A thing to note is that when creating methods with classes C#,
> notice the convention that it uses camel-case and the first
> letter is in uppercase.

```csharp
MyClass myObj = new MyClass();
myObj.MyMethod();
```

## Random Number Generator
From exercise 8 and 9: It wasn't taught on how to create one but it's still
worth knowing how to make one.  

> The instructor made a static RandomNumberGenerator class.
> It seems this is to make the RNG more unified, having only one instance of it.

```csharp
// Create a Random instance and generate a random integer from 0 to n
int n = maxValue;
Random rand = new Random();
Console.WriteLine(rand.Next(maxValue));
```
