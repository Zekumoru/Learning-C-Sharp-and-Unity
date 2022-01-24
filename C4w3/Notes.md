# Notes
## Content
[Delegates](#delegates)

[Event Handlers](#event-handlers)
  - [UnityEvent](#unityevent)
  - [UnityAction](#unityaction)
  - [Unity Example](#unity-example)
    - [Creating An Event](#creating-an-event)
    - [Using An Event And Invoking Listener](#using-an-event-and-invoking-listener)
    - [Adding An Event Listener](#adding-an-event-listener)
    - [My Experience On Making Events](#my-experience-on-making-events)

[Event Manager](#event-manager)
  - [Code Example](#code-example)
    - [Invoker](#invoker)
    - [Listener](#listener)
  - [EventManager Analysis (How It Works)](#eventmanager-analysis-how-it-works)

[Menu](#menu)
  - [Creating A Simple Menu Button](#creating-a-simple-menu-button)
  - [Creating A Simple Menu](#creating-a-simple-menu)

[Scene Management](#scene-management)
  - [Example](#example)
  - [When There Are Multiple Scenes In The Game](#when-there-are-multiple-scenes-in-the-game)

[Quitting The Application (Game)](#quitting-the-application-game)
  - [Example](#example-1)

[Menu Manager](#menu-manager)
  - [MenuName enumeration class](#menuname-enumeration-class)
  - [MenuManager static class](#menumanager-static-class)
  - [Pause Menu class](#pause-menu-class)
  - [Script That Checks If The User Pauses](#script-that-checks-if-the-user-pauses)

## Delegates
_"Delegates are used to pass methods as arguments to other methods. Event handlers are nothing more than methods that are invoked through delegates."_ (From Microsoft Docs, [Delegates](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/#:~:text=A%20delegate%20is%20a%20type,compatible%20signature%20and%20return%20type.&text=In%20other%20words%2C%20a%20method,return%20type%20as%20the%20delegate.))

Basically it is similar to a pointer in C or C++ but instead of passing a reference to an object, we pass a reference to a method, and that is what we call a **delegate**.

## Event Handlers
They are methods which respond to events when they occur. In Unity, there are `UnityEvent` and `UnityAction`.

### UnityEvent
`UnityEvent` is a family of classes that provide events for us. We can add event listeners to `UnityEvent`s and invoke them as necessary.

### UnityAction
`UnityAction` is a family of classes that provide delegates for us.

### Unity Example
#### Creating An Event
```csharp
public class ThisIsAnEvent : UnityEvent {}
```

Sometimes, we want to be able to have arguments to events and fortunately Unity provided us four `UnityEvent` classes that we can inherit from.

```csharp
public class ThisIsAnEvent : UnityEvent<T0> {}
public class ThisIsAnEvent : UnityEvent<T0, T1> {}
public class ThisIsAnEvent : UnityEvent<T0, T1, T2> {}
public class ThisIsAnEvent : UnityEvent<T0, T1, T2, T3> {}
```

Where `T0`, `T1`, `T2`, and `T3` are some data type depending on what you need.\
There's also the `UnityEventBase` which we can use if we want more than 4 arguments.

> You need to use the directive `UnityEngine.Events`

#### Using An Event And Invoking Listener
```csharp
public class Invoker : MonoBehaviour
{
    // events
    ThisIsAnEvent anEvent = new ThisIsAnEvent();

    // invoke listeners
    void ImmaMakeAnEventForListeners()
    {
        anEvent.Invoke();
    }

    // listeners
    void AddEventListener(UnityAction listener)
    {
        anEvent.AddListener(listener);
    }
}
```

Depending on which `UnityEvent` class you used, the code `UnityAction listener` can be either `UnityAction<T0> listener`, `UnityAction<T0, T1> listener`, and so on. Also the code `anEvent.Invoke()` will need arguments that we pass if we used `UnityEvent`s with arguments.

#### Adding An Event Listener
```csharp
public class EventListener : MonoBehaviour
{
    void Start()
    {
        // add delegate to listener
        Invoker invoker =
            GameObject.FindGameObjectWithTag("Invoker")
            .GetComponent<Invoker>();
        invoker.AddEventListener(DelegateMethod);
    }

    public void DelegateMethod()
    {
        // do something...
    }
}
```

#### My Experience On Making Events
It seems that events are similar to but is not an [Observer pattern](https://en.wikipedia.org/wiki/Observer_pattern).

To implement the Unity Event-Action, we create a class which would be the name of the event and **inherits** from `UnityEvent` because it is an event (duh).

Then we use this new event class to create instances of it to another classes where we could then invoke an event if something occurs there and when we say invoke, execute a method from yet another class that will handle the event.

Basically there are three classes, one is the event class, the other class does interesting things and invokes the event field (from the event class) when it does the interesting thing, and another class which handles what to do with the invoked event (which is where the delegate method is located which handles the event).

> **DO NOT** forget to instantiate a new instance on the event variable. I am talking about this `ThisIsAnEvent anEvent = new ThisIsAnEvent();`

## Event Manager
An event manager is a static class that will make it so that none of the objects need to know about each other at all.

### Code Example
```csharp
public static class EventManager
{
    static Invoker _invoker;
    static UnityAction _listener;

    public static void AddInvoker(Invoker invoker)
    {
        _invoker = invoker;
        if (listener != null)
        {
            invoker.AddEventListener(listener);
        }
    }

    public static void AddListener(UnityAction listener)
    {
        _listener = listener;
        if (invoker != null)
        {
            invoker.AddEventListener(listener);
        }
    }
}
```

Notice how our event manager decouples the invoker and the listener by acting as an intermediary between them. Hence, refactoring our event Unity Example above will now look like the code below.

Also, notice the `if` statements, it makes sure that it does not matter which gets assigned first, either the event or the listener. This is good because we do not need to restrain ourselves making sure that the event gets assigned first or the listener gets assigned first.

#### Invoker
```csharp
public class Invoker : MonoBehaviour
{
    void Start()
    {
        // some code ...

        // Pass this script as the invoker
        EventManager.AddInvoker(this);
    }

    // some code ...
}
```

#### Listener
```csharp
public class EventListener : MonoBehaviour
{
    void Start()
    {
        // add delegate to listener in the event manager
        EventManager.AddListener(DelegateMethod);
    }

    public void DelegateMethod()
    {
        // do something...
    }
}
```

Notice how we do not need to get the component anymore like before. This is one of the benefits having the event manager as the intermediary class between events and listeners.

### EventManager Analysis (How It Works)
What's basically happening with the event system is that, it still applies the events and delegates concepts but it's not apparent at first. However, the EventManager that the instructor made is for managing a list of invokers with their respective listeners.

To make the EventManager more general so that it can hold not only a list of one specific class (invoker) with its specific listeners, the instructor created a Dictionary to hold still invokers but now they are named, in other words, keyed, using an enumeration of name of events. Hence when multiple classes are invokers and we want a single EventManager to handle them, the Dictionary will do just that.

One important thing to note here is that the EventManager does NOT actually have the implementation you would expect with events and delegates. The actual adding of delegates are still within the classes themselves but how they are added are managed by the EventManager. This way, the objects of a class does not need to know other objects of another class.

## Menu
### Creating A Simple Menu Button
Create a class that has the delegate method which will be added as a listener for the menu button (which is in this case, an image).

- In the Hierarchy window, right-click and go to `UI`
- Select `Image` (then provide the image)

> If the image shows up distorted, click the `Set Native Size` button.

- Add a button component by going to `Add Component` > `UI` > `Button`
- Attach the script which has the delegate method in a game object (Camera for example but better approach is to have it attached to a Menu game object)
- Then in the button component, on the `On Click ()` box, select the `+` button to add a listener.
- In the listener selection window, navigate through the game object which has the delegate method then select that method.
- And that's it!

### Creating A Simple Menu
As always have a script which has the delegate methods.

- Create a new scene and name it `Menu` (or `Main Menu`)
- Add UI game objects like buttons
- Attach the script (which has the delegate methods) to the `Main Camera`
- In the `On Click ()` box of the buttons, add the delegate methods from the script there.

## Scene Management
To load a scene, we use the static method `SceneManager.LoadScene`. To be able to use that static method, we need the `using` directive `UnityEngine.SceneManagement`.

### Example
```csharp
public void PlayButtonOnClickEvent()
{
    SceneManager.LoadScene("NameOfTheSceneToLoad");
}
```

### When There Are Multiple Scenes In The Game
If we try to run a game with multiple scenes, Unity will actually give us an error stating `<some scene>` could not be loaded etc.\
To fix this, go to `File` > `Build Settings` then drag the scenes from the Scene folder there.

> **Caution:** The order which the scenes are listed in the Build Settings window matter. Hence it is highly advisable to put the main menu scene as the first scene in the list.

## Quitting The Application (Game)
To exit the game, we use the static method `Application.Quit`.

### Example
```csharp
public void QuitButtonOnClickEvent()
{
    Application.Quit();
}
```

## Menu Manager
For a more complex menu, we will need to have a static `MenuManager` class which will take of the more complicated menu system.

In this example, we will be making a pause menu when the game is paused by the user and this pause menu will have two buttons: _resume game_ and _back to main menu_.\
We will need the static `MenuManager` class, a enumeration `MenuName` class (which will contain the list of menus), and a `PauseMenu` script. And another class which will handle the case if the user presses the pause button.

### MenuName enumeration class
```csharp
public enum MenuName
{
    Main,
    Pause
}
```

### MenuManager static class
```csharp
public static class MenuManager
{
    public static void GoToMenu(MenuName name)
    {
        switch (name)
        {
            // Go to the main menu scene
            case MenuName.Main:
                SceneManager.LoadScene("MainMenu");
                break;

            // Instantiate pause menu
            case MainMenu.Pause:
                Object.Instantiate(Resources.Load("PauseMenu"));
                break;
        }
    }
}
```

Notice `Resources.Load("PauseMenu")`, we have a `PauseMenu` prefab in the Resources folder which has the _canvas_ game object that has the _resume game_ and _back to main menu_ buttons.

### Pause Menu class
This script is attached to the `PauseMenu` prefab and it has the delegate methods (or listeners if you prefer to call them that way) to handle the _resume game_ and _back to main menu_ events. In which these listeners are then added to their respective buttons in the `On Click ()` box.

```csharp
public class PauseMenu : MonoBehaviour
{
    // Pause the game
    void Start()
    {
        Time.timeScale = 0;
    }

    // Unpause the game and destroy this
    public void HandleResumeButtonOnClickEvent()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
    }

    // Go back to main menu
    public void HandleBackToMainMenuOnClickEvent()
    {
        // unpause the game
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
    }
}
```

Why do we need to unpause before going back to the main menu? Because if we were to leave it paused, when we go back to the main menu and start the game again from there, we will have a paused scene and we won't want that.

### Script That Checks If The User Pauses
Say we have an input manager that checks for the user inputs, we will handle there if the user presses the pause button, in this case let's say the `Escape` key is the pause button.

```csharp
public class InputManager : MonoBehaviour
{
    void Update()
    {
        // pause the game on 'esc' press
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuManager.GoToMenu(MenuName.Pause);
        }
    }
}
```
