using Godot;

namespace InsaneOne.GodotExt;

public static class TransformExt
{
	public static Vector2 GetRight(this Node2D node2D) => node2D.Transform.BasisXform(Vector2.Right);
	public static Vector2 GetUp(this Node2D node2D) => node2D.Transform.BasisXform(Vector2.Up);
	
	/// <summary> Recommended to use node3D.Basis instead. </summary>
	public static Vector3 GetRight(this Node3D node3D) => node3D.Basis.X;
	
	/// <summary> Recommended to use node3D.Basis instead. </summary>
	public static Vector3 GetUp(this Node3D node3D) => node3D.Basis.Y;
	
	/// <summary> Recommended to use node3D.Basis instead. </summary>
	public static Vector3 GetForward(this Node3D node3D) => node3D.Basis.Z;
}