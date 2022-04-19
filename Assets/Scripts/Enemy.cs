using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //entity properties
    public Entity381 entity;
    public float maxspeed = 6.5f;
    public int health = 3;

    public float maxfollowdistance = 20; //max distance enemy will follow
    public float maxinterceptdistance = 10; //max distance enemy will intercept

    //intercept variables
    public float doneDistance = 10;
    public Entity381 target;
    public Entity381Advanced targetAdv;

    public Vector3 predictedPosition = Vector3.zero;
    
    public float t = 0;
    public float angle = 0;
    
    //follow and intercept variables
    public Vector3 diff = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        entity = this.GetComponent<Entity381>();
        entity.turnRate = 60;
        entity.maxSpeed = maxspeed;
        targetAdv = GameMgr.inst.player;
        //HandleIntercept(GameMgr.inst.player);
    }

    // Update is called once per frame


    //Enemy State Machine:
    //When below maxfollowdistance: follow
    //when between maxfollowdistance and maxinterceptdistance: intercept
    //otherwise do nothing
    
    float dist = 0;
    void Update()   
    {
        dist = Vector3.Distance(GameMgr.inst.player.position, entity.position);

        if(dist < maxinterceptdistance)    //follow distance
        {
            t = (targetAdv.position - entity.position).magnitude / (targetAdv.velocity - entity.velocity).magnitude;
            predictedPosition = targetAdv.position + targetAdv.velocity * t;

            diff = predictedPosition - entity.position;
            angle = Mathf.Atan2(diff.x, diff.z) * Mathf.Rad2Deg;
            angle = Utils.Degress360(angle);
            entity.desiredHeading = angle;
            entity.desiredSpeed = maxspeed;
            Debug.DrawLine(entity.position, predictedPosition, Color.red, 0.05f);
        }
        else if(dist < maxfollowdistance)  //intercept distance
        {
            entity.desiredSpeed = maxspeed;
            diff = GameMgr.inst.player.position - entity.position;
            angle = Mathf.Atan2(diff.x, diff.z) * Mathf.Rad2Deg;
            angle = Utils.Degress360(angle);
            entity.desiredHeading = angle;
            //entity.heading = angle;
            Debug.DrawLine(entity.position, GameMgr.inst.player.position, Color.red, 0.05f);
        }



        else //do nothing when far
        {
            entity.desiredSpeed = 0;
        }


    }

    private void HandleIntercept(Entity381Advanced targetEnt)
    {
        //Intercept intercept = new Intercept(entity, targetEnt);
        //UnitAI uai = entity.GetComponent<UnitAI>();

        //if (Input.GetKey(KeyCode.LeftShift))
        //{
            //uai.AddCommand(intercept);
        //}
        //else
        //{
        //    uai.SetCommand(intercept);
        //}
    }
}
