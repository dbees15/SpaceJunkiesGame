//Daniel Beeston
//dbees15@gmail.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : Command
{
    public Vector3 teleportPosition;
    public float doneDistance = 10;

    public Teleport(Entity381 ent, Vector3 pos): base(ent)
    {
        teleportPosition = pos;
    }

    public override void Init()
    {
        Debug.Log("Teleporting Entity to " + teleportPosition);
    }

    public override void Tick()
    {
        entity.position = teleportPosition;
    }

    public override bool IsDone()
    {
        return (Vector3.Distance(teleportPosition,entity.position) < doneDistance);
    }

    public override void Stop()
    {

    }
}
