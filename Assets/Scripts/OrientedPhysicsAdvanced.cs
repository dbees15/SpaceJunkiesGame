//Daniel Beeston
//dbees15@gmail.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientedPhysicsAdvanced : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        entity.position = transform.localPosition;
    }

    public Entity381Advanced entity;


    // Update is called once per frame
    void Update()
    {
        if (Utils.ApproximatelyEqual(entity.speed, entity.desiredSpeed)) { }
        else if (entity.speed < entity.desiredSpeed)
        {
            entity.speed = entity.speed + entity.acceleration * Time.deltaTime;
        }
        else if (entity.speed > entity.desiredSpeed)
        {
            entity.speed = entity.speed - entity.acceleration * Time.deltaTime;
        }

        if()


        if (Utils.ApproximatelyEqual(entity.heading, entity.desiredHeading))
        { }
        else if (Utils.AngleDiffPosNeg(entity.desiredHeading, entity.heading) > 0)
        {
            entity.heading += entity.turnRate * Time.deltaTime;
        }
        else if (Utils.AngleDiffPosNeg(entity.desiredHeading, entity.heading) < 0)
        {
            entity.heading -= entity.turnRate * Time.deltaTime;
        }
        entity.heading = Utils.Degress360(entity.heading);

        entity.speed = Utils.Clamp(entity.speed, entity.minSpeed, entity.maxSpeed);
        entity.desiredSpeed = Utils.Clamp(entity.desiredSpeed, entity.minSpeed, entity.maxSpeed);

        entity.velocity.y = 0;
        entity.velocity.x = Mathf.Sin(entity.heading * Mathf.Deg2Rad) * entity.speed;
        entity.velocity.z = Mathf.Cos(entity.heading * Mathf.Deg2Rad) * entity.speed;

        entity.position = entity.position + entity.velocity * Time.deltaTime;
        transform.localPosition = entity.position;
        eulerRotation.y = entity.heading;
        transform.localEulerAngles = eulerRotation;
    }

    public Vector3 eulerRotation = Vector3.zero;

}
