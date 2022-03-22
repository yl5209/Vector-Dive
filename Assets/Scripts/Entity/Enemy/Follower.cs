using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class Follower : Agent
{
    protected override void CalculateForces()
    {
        ApplyForce(Seek(target_seek));
    }

    protected override void CalculateTargets()
    {
        target_seek = Player.instance.gameObject.transform.position;
    }
}
