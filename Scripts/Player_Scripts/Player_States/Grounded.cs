using Godot;
using System;

public class Grounded : Base_State
{

    public override void State_Process(float delta)
    {
        Vector3 move_input = Get_Input();
        game_character.MoveAndSlideWithSnap(new Vector3(move_input.x * walk_speed, -grav_increment, move_input.z * walk_speed), Vector3.Down * 10, Vector3.Up);

        if(!game_character.IsOnFloor()){state_machine.Change_State(Base_State.States.Falling);}
    }


}
