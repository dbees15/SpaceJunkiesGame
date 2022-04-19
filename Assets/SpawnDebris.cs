//Julian Fliegler
//flieglerj@nevada.unr.edu

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDebris : MonoBehaviour
{
    public GameObject debrisPrefab;
    public Debris[] debris;

    public float respawnTime = 1.0f;
    private Vector3 screenBounds;
    public float gameplayRange = 50.0f;

    // Start is called before the first frame update
    void Start()
    {
        var horzBound = 3 * Camera.main.orthographicSize;
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
            debris[i].transform.position = new Vector3(Random.Range(-screenBounds.x, screenBounds.x), 0, Random.Range(-screenBounds.z, screenBounds.z));  
        }
    }

    private void Spawn()
    {
        debris = new Debris[5];
        Vector3 position = Vector3.zero;

        while (IsWithinView(position))
        {
            // recalc until out of view
            position = new Vector3(Random.Range(-gameplayRange, gameplayRange), 0, Random.Range(-gameplayRange, gameplayRange)); // place randomly in space
        }
        for (int i = 0; i < debris.Length; i++)
        {
            debris[i] = Instantiate(debrisPrefab).GetComponent<Debris>();
            debris[i].transform.position = new Vector3(Random.Range(position.x - 5, position.x + 5), 0, Random.Range(position.z - 5, position.z + 5)); // clump 5 at a time
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
