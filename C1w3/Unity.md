# Unity Code Snippets
## Scaling A Sprite
From exercise 11.\
We take the current scale of the game object then we scale it using its `x` and `y` properties.

```csharp
Vector3 newScale = transform.localScale;
newScale.x *= someConstantX; // scales horizontally (makes wider)
newScale.y *= someConstantY; // scales vertically (makes taller)
transform.localScale = newScale;
```

> **Why do we not do it directly like `transform.localScale.x` and `transform.localScale.y`?** Well, think of it this way, `transform.localScale` is actually a get method, meaning, we are returning the `localScale` variable from a method and not the `localScale` variable directly itself!

> TL:DR; `transform.localScale` is basically like `transform.GetLocalScale()`.\
> It doesn't look like it because of a syntax exclusive to C# called *[Get Set Properties](https://www.w3schools.com/cs/cs_properties.php)*.
