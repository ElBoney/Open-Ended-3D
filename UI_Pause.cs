using Godot;
using System;

public class UI_Pause : Control
{
    Control userInterface;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        userInterface = GetNode<Control>("Reset");
        userInterface.Hide();
        Input.MouseMode = Input.MouseModeEnum.Captured;
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if(@event.IsActionPressed("ui_cancel") && !userInterface.Visible)
        {
            userInterface.Show();
            Input.MouseMode = Input.MouseModeEnum.Visible;
        }
        else if(@event.IsActionPressed("ui_cancel") && userInterface.Visible)
        {
            userInterface.Hide();
            Input.MouseMode = Input.MouseModeEnum.Captured;
        }
        if(@event.IsActionPressed("ui_accept") && userInterface.Visible){ GetTree().ReloadCurrentScene(); }
        if(@event.IsActionPressed("ui_reset")){ GetTree().ReloadCurrentScene(); }
    }

}
