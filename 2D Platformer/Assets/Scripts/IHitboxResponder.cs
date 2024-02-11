using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHitboxResponder{
    void collisionedWith(Collider collider);
}
