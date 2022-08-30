using Godot;
using System;

public class SceneHandler : Node
{
    public Node current_level;
    public ResourceInteractiveLoader loader;
    AnimationPlayer anim_player;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        current_level = GetChild(0);
        GD.Print(current_level.Name);
        anim_player = GetNode<AnimationPlayer>("AnimationPlayer");
    }

    public void Change_Level(string new_level)
    {
        loader = ResourceLoader.LoadInteractive(new_level);
        GD.Print(loader);
        anim_player.Play("fade_to_black");
    }

    public void On_Fade_To_Black(string anim_name)
    {
        if (anim_name == "fade_to_black")
        {
            loader.Wait();

            var init_level = (PackedScene)loader.GetResource();
            Node level_instance = init_level.Instance();
            current_level.QueueFree();
            AddChild(level_instance);

            current_level = level_instance;
            loader.Dispose();

            anim_player.Play("fade_scene_in");
        }
    }
}