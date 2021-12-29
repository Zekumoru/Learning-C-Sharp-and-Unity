# Unity Code Snippets
## Content
[Scaling A Sprite](#scaling-a-sprite)

[Applying Force With Rigidbody2D](#applying-force-with-rigidbody2d)

[Resolving Collisions](#resolving-collisions)

[Bonus: Moving Game Object To A Random Direction](#bonus-moving-game-object-to-a-random-direction)

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
From exercise 13.\
After setting up collisions, if we want to resolve, in other words, do something when a collision has occurred, we can override `OnCollisionEnter2D` method from the `MonoBehaviour` class.

```csharp
void OnCollisionEnter2D(Collision2D col)
{
    // do something when collision occurred
}
```

[Collision2D](https://docs.unity3d.com/ScriptReference/30_search.html?q=Collision2D) is basically details about the collision, like, which colliders collided, etc.

> Go to `Notes.md` then to _Collisions_ for more info.

## Bonus: Moving Game Object To A Random Direction
From the video about collisions, this code snippet was given and it moves a game object to a random direction by giving it a random angle to go to and a random magnitude, i.e., speed.

```csharp
// Generate random magnitude
const float MinImpulseForce = 3f;
const float MaxImpulseForce = 5f;
float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);

// Generate random angle
float angle = Random.Range(0, 2 * Mathf.PI);
Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

// Add gravity to game object
GetComponent<Rigidbody2D>().AddForce(
    direction * magnitude,
    ForceMode2D.Impulse);
```

> Notice the line `direction * magnitude`\
> `*` is an overloaded operator which multiplies `magnitude` to both the `x` and `y` of the `Vector2` instance.
