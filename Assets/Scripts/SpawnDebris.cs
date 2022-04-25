//Julian Fliegler
//flieglerj@nevada.unr.edu

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDebris : MonoBehaviour
{
    public GameObject debrisPrefab;
    public Debris[] debris;

    public float respawnTime = 10;
    private Vector3 screenBounds;
    public float gameplayRange = 30;
    public float yLevel = -2;   //what y level to spawn on

    // Start is called before the first frame update
    void Start()
    {
        var horzBound = 4 * Camera.main.orthographicSize;
        var vertBound = horzBound * Screen.width / Screen.height;
        screenBounds = new Vector3(vertBound, 0, horzBound); 
        Init();
        StartCoroutine(RunSpawn());
    } 
    
    private void Init()
    {
        debris = new Debris[100];
        for (int i = 0; i < debris.Length; i++)
        {
            debris[i] = Instantiate(debrisPrefab).GetComponent<Debris>();
            //debris[i].transform.position = new Vector3(Random.Range(-screenBounds.x, screenBounds.x), yLevel, Random.Range(-screenBounds.z, screenBounds.z)); 

            //spawn debris in map bounds
            debris[i].transform.position = new Vector3(Random.Range(-GameMgr.inst.MapSize, GameMgr.inst.MapSize), yLevel, Random.Range(-GameMgr.inst.MapSize, GameMgr.inst.MapSize));
        }

        for(int i = 0; i < 15; i++) //spawn a few clouds of debris
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        debris = new Debris[5];
        Vector3 position = Vector3.zero;

        do
        {
            position = new Vector3(Random.Range(-gameplayRange, gameplayRange), yLevel, Random.Range(-gameplayRange, gameplayRange)); // place randomly in space
            // recalc until out of view
        }
        while (IsWithinView(position) && GameMgr.inst.PointInBounds(position));


        for (int i = 0; i < debris.Length; i++)
        {
            debris[i] = Instantiate(debrisPrefab).GetComponent<Debris>();
            debris[i].transform.position = new Vector3(Random.Range(position.x - 5, position.x + 5), yLevel, Random.Range(position.z - 5, position.z + 5)); // clump 5 at a time
        }
    }
    
    IEnumerator RunSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            Spawn();
        }
    }

    private bool IsWithinView(Vector3 pos)
    {
        if (pos.x > -screenBounds.x && pos.x < screenBounds.x)
        {
            return true;
        }
        else
        {
            return false;
        }
            
    }
}
