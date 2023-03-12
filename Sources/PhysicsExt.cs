using Godot;

namespace InsaneOne.GodotExt;

public struct RaycastHit2D
{
	public Vector2 Position;
	public Vector2 Normal;
	public Node2D Node;
}

public struct RaycastHit3D
{
	public Vector3 Position;
	public Vector3 Normal;
	public Node3D Node;
}

public static class PhysicsExt
{
	/// <summary> RayCast2D node can be used instead. </summary>
	public static bool Raycast2D(Viewport viewport, Vector2 origin, Vector2 to, ref RaycastHit2D hit, uint collisionMask = uint.MaxValue)
	{
		var state = PhysicsServer2D.SpaceGetDirectState(viewport.World2D.Space);
		var result = state.IntersectRay(PhysicsRayQueryParameters2D.Create(origin, to, collisionMask));

		if (result.Count == 0)
			return false;

		hit.Position = (Vector2) result["position"];
		hit.Normal = (Vector2) result["normal"];
		hit.Node = (Node2D) result["collider"];

		return true;
	}
	
	/// <summary> RayCast3D node can be used instead. </summary>
	public static bool Raycast3D(Viewport viewport, Vector3 origin, Vector3 to, ref RaycastHit3D hit, uint collisionMask = uint.MaxValue)
	{
		var state = PhysicsServer3D.SpaceGetDirectState(viewport.World3D.Space);
		var result = state.IntersectRay(PhysicsRayQueryParameters3D.Create(origin, to, collisionMask));

		if (result.Count == 0)
			return false;

		hit.Position = (Vector3) result["position"];
		hit.Normal = (Vector3) result["normal"];
		hit.Node = (Node3D) result["collider"];

		return true;
	}

	// todo overlapsphere analogue? or maybe just use area 3d built in component

	// todo several points can be needed
	public static bool GetHitByScreenPoint2D(Viewport viewport, Vector2 screenPoint, ref RaycastHit2D hit)
	{
		var state = PhysicsServer2D.SpaceGetDirectState(viewport.World2D.Space);
		var result = state.IntersectPoint(new PhysicsPointQueryParameters2D { Position = screenPoint });
		
		if (result.Count == 0 || result[0].Count == 0)
			return false;

		hit.Position = screenPoint;
		hit.Normal = Vector2.Zero;
		hit.Node = (Node2D) result[0]["collider"];

		return true;
	}
	
	public static bool RaycastFromCamera3D(Camera3D cam, Vector2 screenPoint, ref RaycastHit3D hit)
	{
		var from = cam.ProjectRayOrigin(screenPoint);
		var to = from + cam.ProjectRayNormal(screenPoint) * 1000;

		return Raycast3D(cam.GetViewport(), from, to, ref hit);
	}
}
