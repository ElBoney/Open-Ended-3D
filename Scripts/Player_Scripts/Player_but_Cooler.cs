using Godot;
using System;

public class Player_but_Cooler : KinematicBody
{

    State_Machine state_machine;
     public Spatial cam_pivot;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        cam_pivot = GetNode<Spatial>("CamPivot");
        state_machine = GetNode<State_Machine>("StateMachine");
        state_machine.Initialize(this);
    }

    public override void _PhysicsProcess(float delta)
    {
        state_machine.Process_Path(delta);
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        state_machine.Input_Path(@event);
    }
}
