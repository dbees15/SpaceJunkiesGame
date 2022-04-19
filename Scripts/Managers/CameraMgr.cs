//Daniel Beeston
//dbees15@gmail.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMgr : MonoBehaviour
{
    public static CameraMgr inst;

    private void Awake()
    {
        inst = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject CameraRig;
    public Entity381Advanced player;
    public float height = 20;

    void Update()
    {
        //CameraRig.transform.position = player.position + Vector3.up * height;
    }

}
