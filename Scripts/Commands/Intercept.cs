//Daniel Beeston
//dbees15@gmail.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intercept : Command
{
    public float doneDistance = 10;
    public Entity381 target;
    public Entity381Advanced targetAdv;

    public Vector3 predictedPosition = Vector3.zero;
    public Vector3 diff = Vector3.zero;
    public float t = 0;
    public float angle = 0;

    public Intercept(Entity381 ent, Entity381 targetEntity) : base(ent)
    {
        target = targetEntity;
    }

    public Intercept(Entity381 ent, Entity381Advanced targetEntityAdv) : base(ent)
    {
        targetAdv = targetEntityAdv;
    }

    public override void Init()
    {

    }

    public override void Tick()
    {
        t = (targetAdv.position - entity.position).magnitude / (targetAdv.velocity - entity.velocity).magnitude;
        predictedPosition = targetAdv.position + targetAdv.velocity * t;

        diff = predictedPosition - entity.position;
        angle = Mathf.Atan2(diff.x, diff.z) * Mathf.Rad2Deg;
        angle = Utils.Degress360(angle);
        entity.desiredHeading = angle;
        entity.desiredSpeed = entity.maxSpeed;
        Debug.DrawLine(entity.position, predictedPosition, Color.red, 0.05f);
    }

    public override bool IsDone()
    {
        return (Vector3.Distance(targetAdv.position, entity.position) < doneDistance);
    }

    public override void Stop()
    {
        entity.desiredSpeed = 0;
        if(Vector3.Distance(targetAdv.position, entity.position) < doneDistance)
        {
            entity.desiredSpeed = 0;
            entity.speed = 0;
            targetAdv.desiredVelocity = Vector3.zero;
            targetAdv.GetComponent<UnitAI>().ClearCommands();
        }
    }
}