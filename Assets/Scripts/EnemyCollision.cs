using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "PlayerMesh")
        {
            SoundMgr.inst.PlayHit();
            GameMgr.inst.PlayerHealth -= 1;
            Destroy(this.transform.parent.gameObject, 0);
        }
    }
 
}
