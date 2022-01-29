# Space Invaders - Journal
My take on making the infamous _Space Invaders_ game. I will be writing here what I did, learn, and so on and so forth.

## Before I Start...
Let's plan what we need before we (actually, I) dive in and programing this thing.

I will be making a simple version of Space Invades which have only maybe one type of invader but is inflexible if we want more, the player, and the bullets. Also with a simple GUI which shows the player's score and lives, a main menu, a pause menu, and a high-score menu. And if possible an audio system.

With those said, I start now! (It's currently 4:15 p.m. on Jan 15, 2022)

## GameInitializer Awake vs Start
Okay, so this gave me quite the headache but basically, I have a static `EventManager` script that needs to be executed above all other scripts. However, in my case, Unity always execute those other scripts before `EventManager` hence a null exception error.

I was thinking of ways to have another script that should make sure it `EventManager` initializes first but that would make my code more coupled than I wanted it to be. It turns out that you can use the Unity's `Script Execution Order` in the `Project Settings` window in the `Edit` menu. Drag the script that needs to be run first inside `Script Execution Order` and make sure it is above `Default Time`.

Now that works but... I don't like that the Unity settings needs to know about this hence I saw the holy grail in the comment section: the `Awake` method. As a matter of fact, here's what the comments says:

> Matthias: _"But in this particular example you have, isn't it like 100,000 times more correct to do some of that in the Start method? Shouldn't you always only call external stuff in the Start method and not in Awake?"_\
> Code Monkey: _"Yes that is a good pattern to follow, initialize your scripts on Awake and only interact with other scripts on Start."_\
> From [Quick Tip: Script Execution Order (Unity Tutorial)](https://www.youtube.com/watch?v=JyxqvaUeXeQ))

## Update On My Work
Well, I've finished the program, I learned how to "properly" make my own `EventManager`. Since I don't like for other classes to inherit to some invoker class like the instructor did. I made a `List` of `UnityEvent<GameObject>`, rather than a custom made class to inherit from.

Another tricky thing I learned from this project is creating the invaders like putting them into some kind of grid, I had to draw and check how to do the calculations but in the end it works out.
