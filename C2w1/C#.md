# C#
## Contents
[SerializeField](#serializefield)

[as Keyword](#as-keyword)


## SerializeField
_"Force Unity to serialize a private field._"\
From the Scripting API, [SerializeField](https://docs.unity3d.com/ScriptReference/SerializeField.html)

If you want to show up the private fields of a script in the Unity Editor, add the `SerializeField` attribute to those fields.

```csharp
[SerializeField]
GameObject gameObject;

[SerializeField]
Sprite sprite0;
[SerializeField]
Sprite sprite1;
```
## as Keyword
_Converts an `Object(Type)` into another `Object(Type)`. Returns `null` if the conversion is not possible instead of raising an `InvalidCastException`._ ([source](https://www.geeksforgeeks.org/c-sharp-as-operator-keyword/))

```csharp
GameObject gameObject = Instantiate(somePrefab) as GameObject;
if (gameObject == null)
{
    print("Cast is unsuccessful!");
}
else
{
    // do stuff...
}
```
