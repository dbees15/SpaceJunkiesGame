using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //void Update()
    //{
    //    
    //}

    private void OnTriggerEnter(Collider other) //is called when there is a collision with another gameobject with a collider (such as debris)
    {

        print("collision with " + other.name);
        if (other.name == "DebrisMesh")
        {
            other.GetComponentInParent<Debris>().enabled = true;
        }
    }
}
