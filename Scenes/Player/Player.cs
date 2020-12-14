using Godot;
using System;

public class Player : Node2D
{
	[Export]
	private int speed = 100;
	
	private Vector2 screenSize;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		screenSize = GetViewport().Size;
		Position = screenSize/2;
	}
	
	public override void _Process(float dt)
	{
		var v = new Vector2();
		var sprite = GetNode<AnimatedSprite>("AnimatedSprite");
		if(Input.IsActionPressed("ui_up"))
		{
			v.y -= 1;
		}
		if(Input.IsActionPressed("ui_down"))
		{
			v.y += 1;
		}
		if(Input.IsActionPressed("ui_left"))
		{
			v.x -= 1;
		}
		if(Input.IsActionPressed("ui_right"))
		{
			v.x += 1;
		}
		
		if(v.x > 0)
		{
			sprite.Animation = "right";
		}else if(v.x < 0)
		{
			sprite.Animation = "left";
		}else
		{
			sprite.Animation = "idle";
		}
		
		sprite.Play();
		
		v = v.Normalized() * speed;
		Position += v * dt;
	}
}
