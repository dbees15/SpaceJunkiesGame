using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public static GameMgr inst;

    public Entity381Advanced player;
    public GameObject Magnet;

    public bool magnetOn;   //main bool to control magnet behavior

    //Maybe vectors of game objects, such as enemies and scrap

    private void Awake()
    {
        inst = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        ToggleMagnet(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleMagnet(bool state)
    {
        magnetOn = state;
        Magnet.GetComponent<MeshRenderer>().enabled = state;
        Magnet.GetComponent<SphereCollider>().enabled = state;
    }
}
