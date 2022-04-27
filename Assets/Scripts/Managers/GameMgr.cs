using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public static GameMgr inst;

    public Entity381Advanced player;
    public GameObject magnet;
    public GameObject playerProjectile;

    public int Debris = 0;  //current debris
    public int PlayerHealth = 3;    //curent health
    public int Score = 0;   //current score

    public int TotalEnemiesDestroyed = 0;
    public int TotalDebrisCollected = 0;

    public int MapSize = 200;   //size of the play area square

    public int maxEnemies = 15;
    public int currentEnemies = 0;

    public bool playerIsAlive = true;
    public float projectileSpeed = 20;  //speed projectile travel at

    public bool magnetOn;   //main bool to control magnet behavior


    private void Awake()
    {
        inst = this;
        MapSize /= 2; 
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

        if (magnetOn)
            SoundMgr.inst.PlayMagnet();
        else
            SoundMgr.inst.StopMagnet();

        magnet.GetComponent<MeshRenderer>().enabled = state;
        magnet.GetComponent<SphereCollider>().enabled = state;
    }

    public void onPlayerDeath()
    {
        playerIsAlive = false;  //set alive to false
        //maybe put explosion animation here?
        player.transform.GetChild(0).gameObject.SetActive(false);   //hide player mesh
        UIMgr.inst.OnGameOver();
        //maybe activate a game over screen?
        //SoundMgr.inst.PlayGameOver(); // plays multiple times
    }

    public bool PlayerInBounds()    //check if player is in the map
    {
        return (player.position.x < MapSize) &&
               (player.position.x > -1*MapSize) &&
               (player.position.z < MapSize) &&
               (player.position.z > -1*MapSize);
    }

    public bool PointInBounds(Vector3 p) //check if a point is in map bounds
    {
        return (p.x < MapSize) &&
       (p.x > -1 * MapSize) &&
       (p.z < MapSize) &&
       (p.z > -1 * MapSize);
    }
}
