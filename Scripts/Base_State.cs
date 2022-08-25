using Godot;
using System;

//Provides a Base class for all State Classes
public class Base_State : Node
{
    public enum States
    {
        Grounded,
        Jumping,
        Falling,
        Wallrunning,
        Waiting
    }
    
        public float grav_increment = 1;
        public static float grav_felt = 0;
        public const float terminal_velocity = -50;
        public float walk_speed = 10;
        public float jump_hight = 25;

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

    public Vector3 Get_Input()
    {
        Vector3 move_input = new Vector3(0,0,0);
        move_input.x = Input.GetAxis("ui_left", "ui_right");
        move_input.z = Input.GetAxis("ui_up", "ui_down");
        move_input = move_input.Normalized();
        return Rotate_Input(move_input);
    }

    public void Rotate_Character(Vector3 direction)
    {
        if(direction != Vector3.Zero)
        {
        game_character.GetNode<Spatial>("CharPivot").LookAt(game_character.Translation + direction, Vector3.Up);
        }
    }

    public Vector3 Rotate_Input(Vector3 input)
    {
        return input.Rotated(Vector3.Up ,game_character.GetNode<Spatial>("CamPivot").Rotation.y);
    }

}