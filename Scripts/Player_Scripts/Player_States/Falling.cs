using Godot;
using System;

public class Falling : Base_State
{
    public override void State_Process(float delta)
    {
        Vector3 move_input = Get_Input();
        if(grav_felt > terminal_velocity){grav_felt -= grav_increment;}

        game_character.MoveAndSlide(new Vector3(move_input.x * walk_speed, grav_felt, move_input.z * walk_speed), Vector3.Up);
        
        if(game_character.IsOnFloor()){state_machine.Change_State(Base_State.States.Grounded);}
    }
}
