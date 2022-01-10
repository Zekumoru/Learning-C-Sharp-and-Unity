# Unity
## Contents
[MonoBehaviour Related Methods](#monobehaviour-related-methods)
  - [OnMouseDown](#onmousedown)
  - [OnTriggerStay2D](#ontriggerstay2d)

[Tags](#tags)
  - [Setting Tag Dynamically](#setting-tag-dynamically)

[Physics Related](#physics-related)
  - [Resetting Force](#resetting-force)

## MonoBehaviour Related Methods
### OnMouseDown
From _Ted The Collector_ video lecture.

Gets called when user clicked inside of the game object's colliders.

```csharp
void OnMouseDown()
{
    // code...
}
```

### OnTriggerStay2D
From _Ted The Collector_ video lecture.

Gets called when it detects it is inside of another game object's collider.

```csharp
void OnTriggerStay2D(Collider2D other)
{
    // code...
}
```

`OnTriggerStay2D` is better than `OnCollisionEnter2D` if we were to check if we collided with another game object because what if we collided with two game objects at the same time? Then `OnCollisionEnter2D` will only be called once ignoring the other collided game object while `OnTriggerStay2D` will be called as long as it is inside other game objects' colliders.

> `OnTriggerStay2D` will **NOT be called** if we do not check off **Is Trigger** in the Box Collider 2D component!

## Tags
### Setting Tag Dynamically
```csharp
GameObject.tag = nameOfNewTagString;
```

## Physics Related
### Resetting Force
To reset the applied force from using `RigidBody2D.AddForce`, we simply set its velocity to zero.

```csharp
someRigidBody2D.velocity = Vector2.zero;
```
