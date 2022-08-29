using Godot;
using System;

public class Teleporter : Area
{
    [Signal]
    public delegate void sceneExited(string nextScene);
    [Export]
    string scene_string;
    Node scene_handler;
    
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        scene_handler = GetTree().Root.GetNode<Node>("SceneHandler");
        Connect("sceneExited", scene_handler, "Change_Level");
    }

    public void _on_Teleporter_body_entered(Node body)
    {
        if(body.GetGroups().Contains("Player"))
        {
            //GD.Print(scene_to_teleport_to);
            EmitSignal("sceneExited", scene_string);
        }
    }
}
