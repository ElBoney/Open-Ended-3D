using Godot;
using System;

//Provides a Base class for all State Classes
public class Base_State : Node
{
    // public enum States
    // {
    //     Grounded,
    //     Jumping,
    //     Falling,
    //     Wallrunning,
    //     Waiting
    // }
    

    public State_Machine state_machine;
    public KinematicBody game_character;

    public virtual void Initialize()
    {

    }

    public virtual void State_Process(float delta)
    {
    }

    public virtual void State_Input(InputEvent @event)
    {

    }


}