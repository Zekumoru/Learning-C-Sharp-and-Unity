# Notes
## Content
[Technique on accessing an index when making your own list.](#technique-on-accessing-an-index-when-making-your-own-list)

[Vector3.Distance](#vector3distance)

## Technique on accessing an index when making your own list.

```csharp
public T this[int index]
{
    get { return items[index]; }
}
```

## Vector3.Distance
Returns the distance between two Vector3, or Vector3 `a` and Vector3 `b` below.

```csharp
distance = Vector3.Distance(a, b);
```
