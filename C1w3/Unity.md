# Unity Code Snippets
## Scaling Sprites
From exercise 11.

```csharp
Vector3 newScale = transform.localScale;
newScale.x *= someConstantX;
newScale.y *= someConstantY;
transform.localScale = newScale;
```

We take the current scale of the game object then we scale it using its `x` and `y` properties.

> **Why do we not do it directly?** Well, think of it this way, `transform.localScale` is actually a get method, meaning, we are returning the `localScale` variable and not the `localScale` variable directly itself!

> TL:DR; `transform.localScale` is basically like `transform.GetLocalScale()`.\
> It doesn't look like it because of a syntax exclusive to C# called *Get Set Properties*.
