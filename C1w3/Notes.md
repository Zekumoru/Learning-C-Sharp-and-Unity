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
