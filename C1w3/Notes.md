# Notes
## Sprites
A sprite is a graphical asset which can be either a single image or a sprite
sheet or sprite strip.

> Sprite sheet and sprite strip are the same. And they both mean an image
> with multiple frames or sets of sprites for animations.

### Adding sprites on Unity
- Create a _sprites_ folder in the Project window.
- Drag and drop the sprites you want into that folder.

## Game Object
Game objects are entities that are actually in the game.

### Adding game objects
- Select the sprite from the _sprites_ folder and drag them over into a _scene_
inside the Hierarchy window.

> Tip: If the sprites turn out to be small in the game view, rather than
> resizing the sprites themselves, we can change the camera's size by selecting
> the _Main Camera_ and changing its size in the Inspector window.
> This way, we prevent our sprites to become pixelated due to resizing it larger.

> Always know beforehand your assets' sizes. Also, as a general rule, always
> make sure your assets' sizes are a power of 2. E.g. 16x16, 8x32, etc.
> It will help your GPU. :)

## Unity's Component System
Components affect the states and behaviors of a game object. They are located in the Inspector window and we can attach or remove components to game objects.

### A C# script is a component too!
Asides from the components Unity gave us, we can also create our own components using C# scripts to modify the behavior of game objects.

#### Creating scripts on Unity
- Create a new folder called _scripts_ in the Project window.
- Right-click the _scripts_ folder then create a new **C# Script**.
- Double-click the new script to modify it. (Which will open up the IDE you've chosen to edit scripts)

> When modifying a script, don't forget to save it before leaving the IDE or before using that script.

#### Creating a component with a C# script
- Select the C# script to attach, i.e., add it as a component to a game object
- Drag the selected script to a game object inside a _scene_

> The script is a class, but when the script is attached as a component,
> the game object gets an instance (an object) of that class.

> Basically scripts are custom components.

## Debugging A Script
Debugging means to find bugs, in other words, errors in your code.

### The Debugging Process
Before we debug, we must:
- Discover there's a bug in the game
- Form a hypothesis what's causing it
- Use the debugger to confirm the hypothesis or find the actual bug
- Fix it the bug

### Debugging using Visual Studio
- Select a breakpoint\
  A breakpoint stops the program from running in that point which you
  then check the environment (look at the variables' values, etc.) to
  debug.
- Run the debugger by either going to the Debug tab and selecting _Attach Unity Debugger_ or simply just click the _Attach to Unity_ button just next the green play button.
- While debugging, we can step over, i.e., execute the next line of code or do whatever you want.

## 2D Physics
Unity has a 2D and a 3D physics engines. However, throughout this course, only the 2D physics engine will be used.

### Adding 2D Physics to a game object
- Select game object and go to Inspector
- Add component
- Select 2D Physics
- Select Rigidbody 2D

> If you run the game, you'll notice that the game object will fall out the screen because of gravity.

### Turning off gravity
- Go to Edit
- Go to Project Settings
- Select Physics 2D
- Set gravity's `y` to `0`

> By default, you'll notice the gravity is set to `x: 0` and `y: -9.81`\
> Remember that `-9.81` value? Yep, that's the gravity, or gravitational acceleration, on Earth.

## Collisions
### Collision Detection
Detecting collisions between game objects.\
Applying collision detection is as simple as just attaching a 2D collider component to a game object. Collision detections will then be handled by the Unity physics engine.

### Collision Resolution
Resolving a collision between game objects. In other words, do something when a collision has happened.\

### Materials
A physic material contains the friction and the bounciness of a game object.

## Prefabs
A prefab lets you easily reuse an already existing customized game object without having to set it up again.

Say, for example, you created a game object, added components, did whatever. Now you need another of this game object with same configurations. Rather than doing everything again for that new game object. We can turn our existing customized game object into a prefab which will let us to easily reuse that game object.

> Basically, a prefab can be likened to a class.

> Also, prefabs are super useful when you want to create that customized game object in runtime. (_spawning_, like, spawning an enemy or something)
