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

## Applying Force With Rigidbody2D
From exercise 12.\
We take the Rigidbody2D component and add force to it by supplying the coordinates using `Vector2`.

```csharp
GetComponent<Rigidbody2D>().AddForce(
    new Vector2(<force x>, <force y>),
    ForceMode2D.Impulse);
```

`<force x>` when negative, applies force to the left, and when positive, to the right.
`<force y>` when negative, applies force downward, and when positive, upward.

> Check [ForceMode2D.Impulse](https://docs.unity3d.com/ScriptReference/ForceMode2D.Impulse.html) to learn about it

## Resolving Collisions
Go to `Notes.md` then to _Collisions_ for more info.\
From exercise 13,
