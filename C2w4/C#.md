# C#
## Contents
[Arrays](#arrays)
  - [Declaring And Assigning An Array](#declaring-and-assigning-an-array)
  - [Accessing An Array](#accessing-an-array)

[Lists](#lists)
  - [Declaring And Assigning A List](#declaring-and-assigning-a-list)
  - [Accessing A List](#accessing-a-list)
  - [Size Of A List](#size-of-a-list)
  - [Adding An Element](#adding-an-element)
  - [Adding Elements With Array](#adding-elements-with-array)
  - [Removing An Element](#removing-an-element)
  - [Removing All Elements (Clear)](#removing-all-elements-clear)

[Loops Related](#loops-related)
  - [foreach Loop](#foreach-loop)
  - [Proper way to remove an element from a list using a loop](#proper-way-to-remove-an-element-from-a-list-using-a-loop)

[Enumeration](#enumeration)
  - [Making An Enumeration](#making-an-enumeration)
  - [Converting Enum Element To String](#converting-enum-element-to-string)

## Arrays
Collection of the same data type elements.\

### Declaring And Assigning An Array
```csharp
// declare and define an array that can hold 5 elements
int[] arr1 = new int[5];

// or, if we already know how many we need and what the values are
int[] arr2 = { 45, 25, 97, 1, 89 };
```

### Accessing An Array
```csharp
arr1[<index>];

// or, to change the content of an entry
arr1[<index>] = someNumber;
```

## Lists
A **list** is the same as an array but it is dynamic, meaning, it does not need a fixed size.

### Declaring And Assigning A List
```csharp
List<int> list = new List<int>();
```

### Accessing A List
It is the same procedure as an array.

```csharp
list[<index>];
```

### Size Of A List
```csharp
list.Count();
```

### Adding An Element
```csharp
list.Add(someValue);
```

> Entries in an array or list is called an _element_.

### Adding Elements With Array
```csharp
someArray = { 23, 45, 1 };
list.AddRange(someArray);
```

### Removing An Element
```csharp
list.Remove(someValue);
list.RemoveAt(<index>);
```

### Removing All Elements (Clear)
```csharp
list.Clear();
```

## Loops Related
### foreach Loop
It is the same as the _for_ loop but it iteratively accesses an element without the use of an index.

```csharp
foreach (int number in list)
{
    // some code...
}
```

> A **foreach** loop cannot be used when adding or removing an element from a list.

### Proper way to remove an element from a list using a loop
If we want to remove a particular element from the list, we must use a backward loop rather than a forward loop.

Proper way: backward loop
```csharp
for (int i = list.Count() - 1; i >= 0; i--)
{
    if (someCondition)
    {
        list.RemoveAt(i);
    }
}
```

Improper way: forward loop
```csharp
for (int i = 0; i < list.Count(); i++)
{
    if (someCondition)
    {
        list.RemoveAt(i);
    }
}
```

This is improper because if we were to remove an element midway, the loop will ignore the next element because that next element used to be the next but got pushed to the removed element hence why it will be ignored.

## Enumeration
_"Enumeration (or enum) is a value data type in C#. It is mainly used to assign the names or string values to integral constants, that make a program easy to read and maintain."_ (From [GeeksForGeeks, C# Enumeration](https://www.geeksforgeeks.org/c-sharp-enumeration-or-enum/))

### Making An Enumeration
```csharp
public enum EnumerationName
{
    Element1,
    Element2,
    Element3
}
```

### Converting Enum Element To String
```csharp
string str = EnumerationName.Element1.ToString();
```
