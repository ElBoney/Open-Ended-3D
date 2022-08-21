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
    
        public float grav_increment = 1;
        public static float grav_felt = 0;
        public const float terminal_velocity = 50;
        public float walk_speed = 10;

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

    public Vector2 Get_Input()
    {
        Vector2 move_input = new Vector2(0,0);
        move_input.x = Input.GetAxis("ui_left", "ui_right");
        move_input.y = Input.GetAxis("ui_down", "ui_up");
        return move_input.Normalized();
    }

}