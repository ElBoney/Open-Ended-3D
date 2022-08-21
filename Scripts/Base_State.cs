using Godot;
using System;

//Provides a Base class for all State Classes
public class Base_State : Node
{
    public enum States
    {
        Grounded,
        Running,
        Jumping,
        Falling,
        Wallrunning,
        Waiting
    }
    
        float grav_increment = 1;
        float walk_speed = 10;
        
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
