using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogStrike : PlayerAttack
{
    public override int power => 10;
    protected override String attackName => "Dogstrike";
}
