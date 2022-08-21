using Godot;
using System;

public class Main : Node
{
    Control userInterface;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        userInterface = GetNode<Control>("UI/Reset");
        userInterface.Hide();
        Input.SetMouseMode(Input.MouseMode.Captured);
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if(@event.IsActionPressed("ui_cancel") && !userInterface.Visible)
        {
            userInterface.Show();
            Input.SetMouseMode(Input.MouseMode.Visible);
        }
        else if(@event.IsActionPressed("ui_cancel") && userInterface.Visible)
        {
            userInterface.Hide();
            Input.SetMouseMode(Input.MouseMode.Captured);
        }
        if(@event.IsActionPressed("ui_accept") && userInterface.Visible){ GetTree().ReloadCurrentScene(); }
        if(@event.IsActionPressed("ui_reset")){ GetTree().ReloadCurrentScene(); }
    }

}
