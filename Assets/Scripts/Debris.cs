using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour
{
    AudioSource debrisPickup;

    public Entity381 entity;
    Vector3 diff;
    float angle;

    public float pickupVelocity = 10;
    public float pickupDistance = 0.2f;

    void Start()
    {
        debrisPickup = GetComponent<AudioSource>();
        entity = this.gameObject.GetComponent<Entity381>();
        entity.desiredSpeed = pickupVelocity;
        entity.maxSpeed = pickupVelocity;
    }

    void Update()
    {
        //make the debris move toward player if within distance
        entity.desiredSpeed = pickupVelocity;
        diff = GameMgr.inst.player.position - entity.position;
        angle = Mathf.Atan2(diff.x, diff.z) * Mathf.Rad2Deg;
        angle = Utils.Degress360(angle);
        entity.desiredHeading = angle;
        entity.heading = angle;


        //destroy the object and give player +1 debris when close enough
        if (Vector3.Distance(GameMgr.inst.player.position, new Vector3(entity.position.x, 0, entity.position.z)) < pickupDistance)
        {
            GameMgr.inst.Debris += 1;
            Destroy(this.gameObject.GetComponentInParent<Transform>().gameObject, 0);
        }

    
    }
}
