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
    public int PlayerHealth = 3;
    public int Score = 0;

    public bool playerIsAlive = true;

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
        if (PlayerHealth <= 0)  //check if player is alive
            onPlayerDeath();
    }

    public void ToggleMagnet(bool state)
    {
        magnetOn = state;
        magnet.GetComponent<MeshRenderer>().enabled = state;
        magnet.GetComponent<SphereCollider>().enabled = state;
    }

    public void onPlayerDeath()
    {
        playerIsAlive = false;  //set alive to false
        //maybe put explosion animation here?
        player.transform.GetChild(0).gameObject.SetActive(false);   //hide player mesh
        //maybe activate a game over screen?
    }
}
