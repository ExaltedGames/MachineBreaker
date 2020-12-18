using Godot;
using System;

public class Main : Node2D
{
	PackedScene Player = (PackedScene)ResourceLoader.Load("res://Scenes/Player/Player.tscn");
	PackedScene PlayerBall = (PackedScene)ResourceLoader.Load("res://Scenes/Player/PlayerBall.tscn");

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		AddChild(Player.Instance());
		AddChild(PlayerBall.Instance());
		
	}
	
	public void _input(InputEvent e)
	{
		if(e is InputEventKey eventKey)
		{
			if(eventKey.Pressed && eventKey.Scancode == (int)KeyList.Escape){
				GetTree().Quit();
			}
		}
	}
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
