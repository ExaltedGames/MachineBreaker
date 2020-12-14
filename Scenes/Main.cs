using Godot;
using System;

public class Main : Node2D
{
	PackedScene Player = (PackedScene)ResourceLoader.Load("res://Player.tscn");

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		AddChild(Player.Instance());
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
