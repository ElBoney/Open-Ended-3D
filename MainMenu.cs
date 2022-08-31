using Godot;
using System;

public class MainMenu : Control
{
    SceneHandler scene_handler;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // Button start_button = GetNode<Button>("StartButton");
        // Connect()
        scene_handler = GetTree().Root.GetNode<SceneHandler>("SceneHandler");
    }

    public void On_Start_Pressed()
    {
        scene_handler.Change_Level("res://Main.tscn");
    }
}
