using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Entity381 entity;
    public float interceptSpeed = 5;

    Vector3 diff;
    float angle;        

    // Start is called before the first frame update
    void Start()
    {
        HandleIntercept(GameMgr.inst.player);
    }

    // Update is called once per frame
    void Update()
    {
        entity.desiredSpeed = interceptSpeed;
        diff = GameMgr.inst.player.position - entity.position;
        angle = Mathf.Atan2(diff.x, diff.z) * Mathf.Rad2Deg;
        angle = Utils.Degress360(angle);
        entity.desiredHeading = angle;
        entity.heading = angle;
    }

    private void HandleIntercept(Entity381Advanced targetEnt)
    {
        Intercept intercept = new Intercept(entity, targetEnt);
        UnitAI uai = entity.GetComponent<UnitAI>();

        //if (Input.GetKey(KeyCode.LeftShift))
        //{
            uai.AddCommand(intercept);
        //}
        //else
        //{
        //    uai.SetCommand(intercept);
        //}
    }
}
