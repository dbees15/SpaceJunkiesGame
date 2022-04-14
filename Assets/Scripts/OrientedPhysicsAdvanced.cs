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
    public GameObject playerAnchor;
    public Vector3 deltaVelocity;
    public float turnEpsilon = 0.2f;

    // Update is called once per frame
    void Update()
    {
        /*
        if (Utils.ApproximatelyEqual(entity.speed, entity.desiredSpeed)) { }
        else if (entity.speed < entity.desiredSpeed)
        {
            entity.speed = entity.speed + entity.acceleration * Time.deltaTime;
        }
        else if (entity.speed > entity.desiredSpeed)
        {
            entity.speed = entity.speed - entity.acceleration * Time.deltaTime;
        */

        //handle x-axis velocity
        if(Utils.ApproximatelyEqual(entity.velocity.x,entity.desiredVelocity.x))
        {
            entity.velocity.x = entity.desiredVelocity.x;
        }
        else if(entity.velocity.x < entity.desiredVelocity.x)
        {
            deltaVelocity += Vector3.right*entity.acceleration;
        }
        else
        {
            deltaVelocity -= Vector3.right * entity.acceleration;
        }

        //handle z-axis velocity
        if (Utils.ApproximatelyEqual(entity.velocity.z, entity.desiredVelocity.z))
        {
            entity.velocity.z = entity.desiredVelocity.z;
        }
        else if (entity.velocity.z < entity.desiredVelocity.z)
        {
            deltaVelocity += Vector3.forward * entity.acceleration;
        }
        else
        {
            deltaVelocity -= Vector3.forward * entity.acceleration;
        }

        //if (deltaVelocity.magnitude > 1)
        //    deltaVelocity = deltaVelocity.normalized;

        
        if (Utils.ApproximatelyEqual(entity.heading, entity.desiredHeading,0.2f))
        {
            entity.heading = entity.desiredHeading;
        }
        else if (Utils.AngleDiffPosNeg(entity.desiredHeading, entity.heading) > 0)
        {
            entity.heading += entity.turnRate * Time.deltaTime;
        }
        else if (Utils.AngleDiffPosNeg(entity.desiredHeading, entity.heading) < 0)
        {
            entity.heading -= entity.turnRate * Time.deltaTime;
        }
        entity.heading = Utils.Degress360(entity.heading);

        //entity.speed = Utils.Clamp(entity.speed, entity.minSpeed, entity.maxSpeed);
        //entity.desiredSpeed = Utils.Clamp(entity.desiredSpeed, entity.minSpeed, entity.maxSpeed);

        //entity.velocity.y = 0;
        //entity.velocity.x = Mathf.Sin(entity.heading * Mathf.Deg2Rad) * entity.speed;
        //entity.velocity.z = Mathf.Cos(entity.heading * Mathf.Deg2Rad) * entity.speed;

        

        entity.velocity = deltaVelocity;

        entity.position = entity.position + entity.velocity * Time.deltaTime;
       
        playerAnchor.transform.position = entity.position;
        //transform.localPosition = entity.position;
        eulerRotation.y = entity.heading;
        transform.localEulerAngles = eulerRotation;
    }

    public Vector3 eulerRotation = Vector3.zero;

}
