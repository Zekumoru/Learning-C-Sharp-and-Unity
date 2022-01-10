# Notes
## Clamping
_"The word **clamp** is used when we talk about keeping a particular value within a range of values or a specified set of values."_ (Dr. T)

Clamping just basically means maintain something within another something. For example, keep a game object within the screen so it doesn't get cut off so to speak.

## Input Manager
_"The **Input Manager** window allows you to define input axes and their associated actions for your Project. To access it, from Unity’s main menu, go to `Edit` > `Project Settings`, then select Input Manager from the navigation on the right."_ (From [Input Manager](https://docs.unity3d.com/Manual/class-InputManager.html))

It decouples inputs and logic. It also helps for the player to have the ability to change key bindings.\
An axis is an input that has a name and bound to a key, button, or joystick.

### Adding a new axis
Go to **Input Manager** then under `Axes`, change the size to create new axes then you will notice that the input manager will duplicate the last axis to the specified new size (assuming you incremented the size). This new axis (or, these new axes) can then be modified to create the new axis (axes) we need.

> As for the values of mouse inputs, `mouse 0` refers to the left mouse click, `mouse 1` to the right mouse click, and `mouse 2` for the middle mouse button.
