using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaryMovement : PlayerMovement
{
    protected override float speedMod => 5;
    protected override float jumpMod => 5;
}
