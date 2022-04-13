//Daniel Beeston
//dbees15@gmail.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intercept : Command
{
    public float doneDistance = 10;
    public Entity381 target;

    public Vector3 predictedPosition = Vector3.zero;
    public Vector3 diff = Vector3.zero;
    public float t = 0;
    public float angle = 0;

    public Intercept(Entity381 ent, Entity381 targetEntity) : base(ent)
    {
        target = targetEntity;
    }

    public override void Init()
    {
        //Debug.Log("Teleporting Entity to " + teleportPosition);
    }

    public override void Tick()
    {
        t = (target.position - entity.position).magnitude / (target.velocity - entity.velocity).magnitude;
        predictedPosition = target.position + target.velocity * t;

        diff = predictedPosition - entity.position;
        angle = Mathf.Atan2(diff.x, diff.z) * Mathf.Rad2Deg;
        angle = Utils.Degress360(angle);
        entity.desiredHeading = angle;
        entity.desiredSpeed = entity.maxSpeed;
        Debug.DrawLine(entity.position, predictedPosition, Color.red, 0.05f);

    }

    public override bool IsDone()
    {
        return (Vector3.Distance(target.position, entity.position) < doneDistance);
    }

    public override void Stop()
    {
        entity.desiredSpeed = 0;
        if(Vector3.Distance(target.position, entity.position) < doneDistance)
        {
            entity.desiredSpeed = 0;
            entity.speed = 0;
            target.desiredSpeed = 0;
            target.speed = 0;
            target.GetComponent<UnitAI>().ClearCommands();


        }
    }
}