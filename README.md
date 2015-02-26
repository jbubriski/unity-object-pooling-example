# Unity Object Pooling Example

An object pooling example in Unity 3D.

## How To

Make sure you have the latest Unity installed (4.6.1f1 at time of writing), download this code, open the project and hit run.

By Default, the project does *NOT* use object pooling.  Run the project to see how the game works without it.  To enable object pooling, select the Bullet and Player prefabs and enable the "Use Object Pooling" flags on them.

To the side of the ships in the game there is a sphere that increases/decreases in size based on the number of instantiated bullets.  With Object Pooling you can see that the size doesn't fluctuate at all.  This is meant to visualize memory usage, but probably isn't a perfect example.  If you have Unity Pro you can probably use the built in profiler to correctly see the positive impacts of Object Pooling on memory usage.

## Result

Enabling object pooling should result in 2 things.

The first result is visual: The number of bullets on the screen is limited to 10 at a time.  This may or may not be something that you want when you're using Object Pooling in your own code.  It should be relatively easy to enable the Object Pool to create more objects on the fly.

The second result is transparent to the gameplay but probably more important: Objects are reused to reduce memory spikes/thrashing.  This probably isn't something that is important early on in your game development, but can make a game run more consistently when implemented where needed.

## Credit

Thanks to Jared for the idea to use the spheres to visualize memory usage.
