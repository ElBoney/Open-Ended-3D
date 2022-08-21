using Godot;
using System;

public class CamPivot : Spatial
{
    Vector2 mouse_input;
    float mouse_sensitivity = 1.0f;
    Vector3 camera_motion;
    public Spatial camera;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        mouse_input = new Vector2();
        camera = GetNode<Spatial>("Spatial");
        mouse_sensitivity *= 1000f;
        camera_motion = Rotation;
    }

    // public override void _Process(float delta)
    // {
    //     if(rotation_input != Vector2.Zero && Input.GetMouseMode() == Input.MouseMode.Captured)
    //     {
    //         this.RotateY(-rotation_input.x / 360);
    //         camera.RotateX(-rotation_input.y / 360);
    //     }
    // }

    public override void _Input(InputEvent @event)
    {
        if(@event is InputEventMouseMotion mouseMotion)
        {
            mouse_input = mouseMotion.Relative;
            Rotate_Camera();
        }
    }

    public void Rotate_Camera()
    {
        camera_motion.y -= mouse_input.x / mouse_sensitivity;
        camera_motion.x = Mathf.Clamp(camera_motion.x - mouse_input.y / mouse_sensitivity, -Mathf.Deg2Rad(90), Mathf.Deg2Rad(90));

        Rotation = new Vector3(Rotation.x, camera_motion.y, Rotation.z);
        camera.Rotation = new Vector3(camera_motion.x, camera.Rotation.y, camera.Rotation.z);
    }
}
