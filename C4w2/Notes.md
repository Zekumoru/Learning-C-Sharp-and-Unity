# Notes
## Inheritance
Inheritance is a way to structure our code so that multiple classes share common fields, properties, and methods. But inheritance is powerful because it also lets us to extend a child class with its own specialized fields, properties, and methods.

Multiple inheritance is **NOT** supported in C# and that's for a good reason. And that reason is the **The Diamond Problem** or **The Deadly Diamond of Death**.\
Suppose we have a class `A` which has the children `B` and `C` and then we have a class `D` which has multiple inheritance with `B` and `C`. What if both `B` and `C` overridden methods from `A` then which of the overridden methods from `B` and `C` will `D` inherit from? And this is the **The Diamond Problem**.

The parent class can also be called **superclass** or **base class** and the child class can also be called **subclass** and **derived class**.

### Inheritance Example
```csharp
/// The parent class
class A
{
    public A(int bar)
    {
        // some code...
    }

    public virtual void Foo()
    {
        // some code...
    }
}

/// The child class
class B : A
{
    public B(int bar) : base(bar) {}

    public override void Foo()
    {
        // some code...
    }
}
```

We use the `virtual` keyword to tell C# that it is overridable and then we use the `override` keyword in the base class to tell C# that we are overriding that method from the parent class.

Notice that we can use the `base` keyword to call the parent's constructor.

> **Why do we need the keywords `virtual` and `override`?** In Java, all methods (non-`static`, non-`final`, and non-`private`) are virtual by default. More info [here](https://stackoverflow.com/questions/12752343/are-all-method-in-java-implictly-virtual).\
> Also, the `override` keyword in C#, just like in Java, is optional but advised to use.

### protected Keyword
Since all fields in a C# class are `private` by default, if we want our child classes to be able to use its parent's class' fields without using properties (if a field has one), we use the `protected` keyword.

```csharp
class A
{
    protected int foo;
}

class B : A
{
    void someFunction()
    {
        int bar = someValue + foo;
    }
}
```

### A Note About Inheritance
When creating child objects, it is preferable to store it in its parent class and use the `as` keyword to access child's specific methods.

> Remember `as` keyword from course 2 week 1? Remember that it returns null if an object cannot be type-casted to another class because they don't have a _is-a_ relationship, in other words, inheritance.

```csharp
class A {}
class B : A { void Foo() {} }

static void Main()
{
    A bObj = new B();
    (bObj as B).Foo();
}
```

### What Happens If We Don't Use `virtual` And `override`
If we put our child object in a parent class then if we try to call the specialized supposedly overridden method in our child class, that won't get called, rather, the parent's one will be called.

#### Example
```csharp
// parent class
class A
{
    public void Foo()
    {
        Console.WriteLine("I'm inside A!");
    }
}

// child class
class B : A
{
    public void Foo()
    {
        Console.WriteLine("I'm inside B!");
    }
}

// main method
class Program
{
    static void Main(string[] args)
    {
        A obj = new B();
        obj.Foo();
    }
}
```

**Output:** `I'm inside A!`

Also, even if we put `virtual` only without writing `override` in the child class, we will still get the same output.

If we, however, only write the `override` keyword, we will get an error saying we cannot override a non-virtual method.
