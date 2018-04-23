using System;
using UnityEngine;

public class GamepadController : TestController
{
    protected override bool Firing
    {
        get
        {
            return Input.GetAxis("Fire2") != 0;
        }
    }

    protected override bool Running
    {
        get
        {
            return Input.GetAxis("Jump") != 0;
        }
    }
}