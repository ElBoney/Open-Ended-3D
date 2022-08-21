using Godot;
using System;

public class SceneHandler : Node
{
    public Node current_level;
    public Node level_instance = null;
    AnimationPlayer anim_player;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        current_level = GetNode("Main");
        anim_player = GetNode<AnimationPlayer>("AnimationPlayer");
    }

    public void ChangeLevel(string new_level)
    {
        anim_player.Play("fade_to_black");

        var level_name = (PackedScene)ResourceLoader.Load(new_level);
        level_instance = level_name.Instance();
    }

    public void On_Fade_To_Black(string anim_name)
    {
        if(anim_name == "fade_to_black")
        {
            current_level.QueueFree();
            AddChild(level_instance);

            current_level = level_instance;
            level_instance = null;

            anim_player.Play("fade_scene_in");
        }
    }
}
