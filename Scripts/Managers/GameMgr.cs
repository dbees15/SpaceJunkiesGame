using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public static GameMgr inst;

    public Entity381Advanced player;
    public GameObject magnet;
    public GameObject playerProjectile;

    public int Debris = 0;
    public int Score = 0;

    public float projectileSpeed = 20;

    public bool magnetOn;   //main bool to control magnet behavior


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
        magnet.GetComponent<MeshRenderer>().enabled = state;
        magnet.GetComponent<SphereCollider>().enabled = state;
    }
}
