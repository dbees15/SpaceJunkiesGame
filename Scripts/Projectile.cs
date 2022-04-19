using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int projectiletype; //set to 0 for a player projectile, 1 for enemy projectile


    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other) //is called when there is a collision with another gameobject with a collider (such as an enemy)
    {
        print("collision with " + other.name);
        if(projectiletype==0)   //if player projectile
        {
            if(other.name == "EnemyMesh")
            {
                GameMgr.inst.Score += 1;
                Destroy(this.gameObject.GetComponentInParent<Transform>().gameObject,0);
            }
        }
        else //if enemy projectile
        {
            if (other.name == "PlayerMesh")
            {
                Destroy(this.gameObject.GetComponentInParent<Transform>().gameObject, 0);
            }
        }
    }
}
