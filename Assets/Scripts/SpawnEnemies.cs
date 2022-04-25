//Julian Fliegler
//flieglerj@nevada.unr.edu

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject[] enemy;
    public float respawnTime = 20;
    public int numEnemiesInit = 2;
    private Vector3 screenBounds;
    public float gameplayRange = 50;


    // Start is called before the first frame update
    void Start()
    {
        var horzBound = 3 * Camera.main.orthographicSize;
        var vertBound = horzBound * Screen.width / Screen.height;
        screenBounds = new Vector3(vertBound, 0, horzBound); //Camera.main.ViewportToWorldPoint(new Vector3(Screen.width, Camera.main.transform.position.y, Screen.height));
        Init();
        StartCoroutine(RunSpawn());
    }

    private void Init()
    {
        enemy = new GameObject[numEnemiesInit];
        for (int i = 0; i < enemy.Length; i++)
        {
            enemy[i] = Instantiate(enemyPrefab) as GameObject;
            enemy[i].SetActive(true);
            //enemy[i].transform.position = new Vector3(Random.Range(-screenBounds.x, screenBounds.x), 0, Random.Range(-screenBounds.z, screenBounds.z));
            enemy[i].transform.position = new Vector3(Random.Range(-GameMgr.inst.MapSize, GameMgr.inst.MapSize), 0, Random.Range(-GameMgr.inst.MapSize, GameMgr.inst.MapSize));
        }
    }

    private void Spawn()
    {
        Vector3 position = Vector3.zero;

        do
        {
            // recalc until out of view
            position = new Vector3(Random.Range(-GameMgr.inst.MapSize, GameMgr.inst.MapSize), 0, Random.Range(-GameMgr.inst.MapSize, GameMgr.inst.MapSize)); ; // place randomly in space
        }
        while (IsWithinView(position));

        enemy[0] = Instantiate(enemyPrefab) as GameObject; // spawn one enemy at a time
        enemy[0].transform.position = new Vector3(position.x, 0, position.z);
        enemy[0].gameObject.SetActive(true);
    }

    IEnumerator RunSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);

            if(GameMgr.inst.currentEnemies < GameMgr.inst.maxEnemies)
                Spawn();
        }
    }

    private bool IsWithinView(Vector3 pos)
    {
        if (pos.magnitude > -screenBounds.magnitude && pos.magnitude < screenBounds.magnitude)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}
