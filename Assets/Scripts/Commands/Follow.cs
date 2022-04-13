//Daniel Beeston
//dbees15@gmail.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : Command
{
    public Entity381 targetEntity;
    public Vector3 targetPosition;
    public float doneDistance = 20;
    public float followDistance = 75;

    public Follow(Entity381 ent, Entity381 target) : base(ent)
    {
        targetEntity = target;
    }

    public override void Init()
    {
    }

    Vector3 diff = Vector3.zero;
    float angle = 0;
    public override void Tick()
    {
        targetPosition = targetEntity.transform.TransformPoint(Vector3.right * followDistance);
        //targetEntity.transform.position + Vector3.right*followDistance;
        diff = targetPosition - entity.position;

        Debug.DrawLine(entity.position, targetPosition, Color.red, 0.05f);

        if (diff.magnitude > doneDistance)
        {
            angle = Mathf.Atan2(diff.x, diff.z) * Mathf.Rad2Deg;
            angle = Utils.Degress360(angle);
            entity.desiredHeading = angle;
            entity.desiredSpeed = entity.maxSpeed;
        }
        else
        {
            entity.desiredHeading = targetEntity.heading;
            if(targetEntity.speed <= entity.maxSpeed)
            {
                entity.desiredSpeed = targetEntity.speed;
            }                
            else
            {
                entity.desiredSpeed = entity.maxSpeed;
            }

        }

    }

    public override bool IsDone()
    {
        //return (Vector3.Distance(teleportPosition, entity.position) < doneDistance);
        return false;
    }

    public override void Stop()
    {
        entity.desiredSpeed = 0;
    }
}
