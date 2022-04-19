//Daniel Beeston
//dbees15@gmail.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : Command
{
    public Vector3 movePosition;
    public float doneDistance = 10;

    public Move(Entity381 ent, Vector3 pos) : base(ent)
    {
        movePosition = pos;
    }

    public override void Init()
    {
        Debug.Log("Moving Entity to " + movePosition);
    }


    Vector3 diff = Vector3.zero;
    float angle = 0;
    public override void Tick()
    {
        diff = movePosition - entity.position;
        angle = Mathf.Atan2(diff.x, diff.z) * Mathf.Rad2Deg;
        angle = Utils.Degress360(angle);
        entity.desiredHeading = angle;
        entity.desiredSpeed = entity.maxSpeed;
    }

    public override bool IsDone()
    {
        return (Vector3.Distance(movePosition, entity.position) < doneDistance);
    }

    public override void Stop()
    {
        entity.desiredSpeed = 0;
    }

}