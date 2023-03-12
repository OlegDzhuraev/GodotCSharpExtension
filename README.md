# Godot CSharp Extension
Here is some extensions, which can be useful, especially if you're switching from Unity.

All of these extensions is a subject to change, since now I'm only exploring a Godot APIs and can miss smth.

## How to install
Download sources and drop it to your project folder. Possible, in future it will be made as plugin, but now there is no need to do it this way.

Add `using InsaneOne.GodotExt;` at start of your scripts, which use extensions.

## Physics Extensions
### Raycast 2D and 3D
Godot original API returns a Dictionary, which is kinda weird for C# users. You can use RayCast nodes, but for me it looks not a good solution.
So, now there is API to Raycast like in Unity:
```cs
var viewport = GetViewport();
var from = new Vector2(0, 50);
var to = new Vector2(50, 50);
RaycastHit2D hit = new RaycastHit2D(); // you can cache it once and reuse for periodic raycasts
if (PhysicsExt.Raycast2D(viewport, from, to, ref hit)) // also supports collision mask
{
  GD.Print(hit.Position);
  GD.Print(hit.Node); // Node2D of the hitted collider
  GD.Print(hit.Normal);
}

// short usage
RaycastHit2D hit = new RaycastHit2D();
if (PhysicsExt.Raycast2D(GetViewport(), new Vector2(0, 50), new Vector2(50, 50), ref hit))
{
  // do something
}
```

Same can be used for 3D.

## Transform extension
In class, extends Node2D, you can now use `this.GetUp()` and `this.GetRight()` to get a node direction vector (like Unity transform.up), instead of usage of BasisXform.

Same extensions was made for Node3D, but I recommend to use Basis instead.

## License
MIT
