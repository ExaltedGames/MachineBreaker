using Godot;
using System;

public class PlayerBall : KinematicBody2D
{
   	private Vector2 screenSize;
	private Vector2 velocity;
	[Export]
	private float speed = 20;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		screenSize = GetViewport().Size;
		Position = screenSize/2;
		velocity = new Vector2(0,-1);
	}
	
	public override void _Process(float dt)
	{
		var collision = MoveAndCollide((velocity * speed) * dt);
		// r = GetNode<CollisionShape2D>("CollisionShape2D").radius;
		if(collision != null)
		{
			velocity = velocity.Bounce(collision.Normal);
		}
	}
}
