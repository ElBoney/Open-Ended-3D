using Godot;
using System;

public class Player : KinematicBody
{
    float grav_increment = 1;
    float grav_felt = 0;
    float walk_speed = 10;
    float real_speed = 10;
    float jump_hight = 25;
    bool is_running = false;
    Vector2 viewport;
    Vector3 move_direction = Vector3.Zero;
    Vector3 movement = Vector3.Zero;
    Spatial camera_crane;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        camera_crane = GetNode<Spatial>("CamPivot");
        viewport.x = GetViewport().Size.x;
        viewport.y = GetViewport().Size.y;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
    }

    public override void _PhysicsProcess(float delta)
    {
        if (IsOnFloor()){ grav_felt = -0.1f; }
        else if (grav_felt < 50){ grav_felt -= grav_increment;}
        GetInput();


        //wallrun take #2
        if(GetSlideCount() > 0)
        {
        if(is_running && move_direction.Dot(GetSlideCollision(0).Normal) < -0.01f && move_direction.Dot(GetSlideCollision(0).Normal) > -0.8f)
        {
            grav_felt = 0;
        }
        }

        movement = new Vector3(move_direction.x * real_speed, grav_felt, move_direction.z * real_speed);

        MoveAndSlideWithSnap(movement, Vector3.Down, Vector3.Up);

    }

    public void GetInput()
    {
        //get left-right / front-back input
        move_direction.x = Input.GetAxis("ui_left", "ui_right");
        move_direction.z = Input.GetAxis("ui_up", "ui_down");
        //normalizes and rotates the input vector, as well as rotating the character, only when in use.
        if(move_direction != Vector3.Zero)
        { 
            move_direction = move_direction.Normalized(); 
            move_direction = move_direction.Rotated(Vector3.Up, camera_crane.Rotation.y);
            GetNode<Spatial>("CharPivot").LookAt(Translation + move_direction, Vector3.Up);
        }

        //gets jump input and also applies the jump force directly
        if(Input.IsActionJustPressed("ui_select") && IsOnFloor())
        { 
            grav_felt = jump_hight;
            MoveAndSlide(new Vector3(0, grav_felt, 0), Vector3.Up);
        }

        //gets run input and sets real_speed and is_running accordingly
        if(Input.IsActionJustPressed("ui_run") && move_direction != Vector3.Zero)
        {
            real_speed = walk_speed * 2;
            is_running = true;
        }
        else if(move_direction == Vector3.Zero)
        {
            real_speed = walk_speed;
            is_running = false;
        }
    }

}
