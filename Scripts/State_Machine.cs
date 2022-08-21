using Godot;
using System;
using System.Collections.Generic;

public class State_Machine : Node
{
    KinematicBody game_character;
    Base_State current_state;

    public Dictionary<Enum, Base_State> states = new Dictionary<Enum, Base_State>();

    public override void _Ready()
    {
        states.Add(Base_State.States.Grounded, GetNode<Base_State>("Grounded"));
        states.Add(Base_State.States.Jumping, GetNode<Base_State>("Jumping"));
        states.Add(Base_State.States.Falling, GetNode<Base_State>("Falling"));
        states.Add(Base_State.States.Wallrunning, GetNode<Base_State>("WallRun"));
        Change_State(Base_State.States.Falling);
    }

    public void Change_State(Enum new_state)
    {
        current_state = states[new_state];
        current_state.Initialize();
    }
    public void Initialize(KinematicBody character_ref)
    {
        foreach(Base_State child in GetChildren())
        {
            child.game_character = character_ref;
            child.state_machine = this;
        }
    }

    public void Process_Path(float delta)
    {
        current_state.State_Process(delta);
    }

    public void Input_Path(InputEvent @event)
    {
        current_state.State_Input(@event);
    }

}
