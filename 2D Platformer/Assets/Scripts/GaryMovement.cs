using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaryMovement : PlayerMovement
{
    protected override void Start()
    {
        base.Start();
        speedMod = 5;
        jumpMod = 5;
    }
}
