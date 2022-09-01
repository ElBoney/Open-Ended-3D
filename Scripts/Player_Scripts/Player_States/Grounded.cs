using Godot;
using System;

public class Grounded : Player_State
{
    Base_State jumping_state;
    Base_State falling_state;

    public override void _Ready()
    {
        jumping_state = GetNode<Base_State>("../Jumping");
        falling_state = GetNode<Base_State>("../Falling");
    }
    public override void State_Process(float delta)
    {
        Vector3 move_input = Get_Input();
        Rotate_Character(move_input);
        game_character.MoveAndSlideWithSnap(new Vector3(move_input.x * walk_speed, -grav_increment, move_input.z * walk_speed), Vector3.Down * 10, Vector3.Up, true);

        if(!game_character.IsOnFloor()){state_machine.Change_State(falling_state);}
    }

    public override void State_Input(InputEvent @event)
    {
        if(@event.IsActionPressed("ui_select"))
        {
            state_machine.Change_State(jumping_state);
        }
    }


}
