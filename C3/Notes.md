# Notes
Since this week is pretty basic in the most part, I will be stuffing everything here rather than creating additional `Unity.md` and `C#.md` files.

## Contents
[RigidBody2D Kinematic](#rigidbody2d-kinematic)

[Heads Up Display (HUD)](#heads-up-display-hud)
  - [Adding A Canvas](#adding-a-canvas)
  - [Adding A Text](#adding-a-text)
  - [Adding A Script Component For The HUD](#adding-a-script-component-for-the-hud)

[Audio Basics](#audio-basics)
  - [Adding An Audio Source](#adding-an-audio-source)
  - [Playing The Audio With Script](#playing-the-audio-with-script)

[Audio Manager](#audio-manager)
  - [Creating An Audio Manager](#creating-an-audio-manager)

## RigidBody2D Kinematic
Rigidbody2d Kinematic -> _"This means we’ll be changing the position of the rigidbody ourselves rather than adding forces to move it."_

## Heads Up Display (HUD)
To put text on a screen, we use something called the **HUD**.

Text we output, menu items we click on, etc. are put into something called a **canvas**.

### Adding A Canvas
- Right-click the Hierarchy window
- Go to `UI`
- Select `Canvas`

You can rename it to `HUD`.

In the Inspector, the `Canvas Scaler` component should be `Scale With Screen Size` if we let the user to change the game's resolution, hence, it is a bad idea to leave it `Constant Pixel Size`.\
Changing it to `Scale With Screen Size`, we must also provide the reference resolution. `1280`x`720` is a good resolution, which is also a `16:9` resolution.

> When creating a canvas, we also get an `EventSystem` which responds to menu button clicks and so on.

### Adding A Text
- Right-click the canvas (or `HUD`)
- Go to `UI`
- Select `Text`

We can change the position, size, content, etc. of the text in the Inspector window.

You can also rename the text to what it is going to be. For example, if it is for score then name it `scoreText`.

> Inside the `Rect Transform`, it is appropriate to change where it should really be, for example, if it goes in the top center, change it that way. It is not enough just to specify its position to be in the top center because of screen resolution compatibility.

> If changing the size of the font disappears the text, change the width and height sizes.

### Adding A Script Component For The HUD
We attach the HUD script to the HUD game object in the Hierarchy window. And also in the script, we provide a serialize field for the `Text` game object.

We use `text` property from the `Text` class to change text.

> The `Text` class is in the `UnityEngine.UI` namespace so make sure to do `using`.

Provide a public method in the HUD script that gets called by other scripts if they want to change the text.

> To get the HUD from other scripts, we can put a tag on the HUD and use that tag to retrieve the game object.

## Audio Basics
The idea behind audio in Unity is that there are these things we call **Audio Listeners**, and they hear the audios that are currently being played and they play it in our speakers, headphones, etc.\
With 2D games, we don't really care where the audio comes from but with 3D games, it is much more interesting.

There are also these things called **Audio Sources**, we use those to actually play sounds.

By default, we already have an `Audio Listener` attached in the Main Camera.

### Adding An Audio Source
- Select the game object we want to add an audio source to
- Click `Add Component`
- Go to `Audio`
- Select `Audio Source`

The `Audio Clip` field is where we put the audio we are going to play.

> Uncheck `Play On Awake` to prevent the game object from playing the audio when the game started.

### Playing The Audio With Script
Get the `AudioSource` component then use the `Play()` method to play the sound.

```csharp
AudioSource audioSource = GetComponent<AudioSource>();
audioSource.Play();
```

## Audio Manager
One common issue with game objects playing the audio sources is that: What if we want to play an audio source to a game object when it gets destroyed? We can of course attach an audio source to that game object and play a sound when it gets destroyed but the problem is, when a game objects get destroyed by the `Destroy` method, the audio source gets destroyed along it as well.\
The solution is to have an **Audio Manager** which handles playing all the sounds we want to make, including that destroying sound.

### Creating An Audio Manager
Before we use the `AudioManager` script, we need a script initializer to it (like the one we did on the `ScreenUtils` with the `GameInitializer` script).\
There we check if we already initialized the `AudioManager`, if we did not, we then create an `AudioSource` by attaching it to the game audio initializer and script and pass it to the `AudioManager` because `AudioSource` is the one that will be playing our audio. We then tell Unity not to destroy this game audio initializer using `DontDestroyOnLoad(gameObject);`.\
If `AudioManager` is already initialized, then we just put in the `else` statement to destroy the game object. (So we don't create multiple instances of game audio initializer.)

We also create an audio clip name enumeration where we list the names of our audio clips. This is so that our code is decoupled in a way that if we ever change the audio clip files' names, we will not be like scouring our codes to apply those changes.

In our `AudioManager` script, we have fields that contains if our audio manager is already initialized, we also have an `AudioSource` (which we got from the game audio initializer), and a `Dictionary` of our audio clips. (The dictionary contains the names from the enumeration and the actual file names of our audio clips.)

We also have a public method where we pass in the type of audio from our enumeration to play. We use the `PlayOneShot` method to play the audio rather than the `Play` method. This is because the `Play` method waits for the audio to finish before playing another audio and with our `AudioManager` here, we wouldn't want that.

The implementation of the audio manager would be:
```csharp
public static class AudioManager
{
    // Fields
    static bool initialized = false;
    static AudioSource audioSource;
    static Dictionary<AudioClipName, AudioClip> audioClips =
        new Dictionary<AudioClipName, AudioClip>();

    // Properties
    public static bool Initialized
    {
        get { return initialized; }
    }

    // Methods
    public static void Initialize(AudioSource source)
    {
        initialized = true;
        audioSource = source;

        // add audio clips
        audioClips.Add(AudioClipName.SomeAudioName,
            Resources.Load<AudioClip>("ActualAudioFileName"));
        // add more...
    }

    public static void Play(AudioClipName name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }
}
```
