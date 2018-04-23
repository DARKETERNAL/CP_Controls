using UnityEngine;

public class TestController : BaseController
{
    protected override bool Firing
    {
        get
        {
            return Input.GetKeyDown(KeyCode.Space);
        }
    }

    protected override bool Moving
    {
        get
        {
            return MovementFactor != 0F;
        }
    }

    protected override bool Rotating
    {
        get
        {
            return RotationFactor != 0F;
        }
    }

    protected override bool Running
    {
        get
        {
            return Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        }
    }

    protected override float MovementFactor
    {
        get { return Input.GetAxis("Vertical"); }
    }

    protected override float RotationFactor
    {
        get { return Input.GetAxis("Horizontal"); }
    }
}