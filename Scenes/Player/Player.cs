using Godot;
using System;

public class Player : Node2D
{
	[Export]
	private int speed = 100;
	
	public bool canCatch = false;
	public bool isHolding = false;
	private Vector2 screenSize;
	private KinematicBody2D playerBall;
	private AnimatedSprite sprite;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		screenSize = GetViewport().Size;
		Position = screenSize/2;
		sprite = GetNode<AnimatedSprite>("AnimatedSprite");
	}
	
	public override void _Process(float dt)
	{
		var v = new Vector2();
		
		//movement handling
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
		
		v = v.Normalized() * speed;
		Position += v * dt;
		
		if(isHolding)
		{
			sprite.Animation = "holding"+sprite.Animation;
			playerBall.Position = Position;
		}
		
		sprite.Play();
	}
	
	public override void _Input(InputEvent e)
	{
		if(e is InputEventKey eKey)
		{
			if(eKey.Pressed && eKey.Scancode == (int)KeyList.J && canCatch){
				//we'll defer actions taken on various inputs to their own functions to keep this compact
				catchBall();
			}
		}
	}
	
	private void catchBall()
	{
		playerBall.Hide();
		isHolding = true;
	}
	
	private void _on_CatchRadius_body_entered(Node body)
	{
		if(body.Name == "PlayerBall")
		{
			playerBall = (KinematicBody2D)body;
			canCatch = true;
		}
	}
	private void _on_CatchRadius_body_exited(Node body)
	{
		if(body.Name == "PlayerBall")
		{
			canCatch = false;
		}
	}
}
