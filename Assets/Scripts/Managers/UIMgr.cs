//Daniel Beeston
//dbees15@gmail.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMgr : MonoBehaviour
{
    // Start is called before the first frame update
    public static UIMgr inst;

    public Text HealthT;
    public Text VelocityT;
    public Text DebrisT;

    public Text ScoreT;
    public Text FinalDebrisT;
    public Text FinalEnemiesDestroyedT;

    public GameObject GameOverUI;
    public GameObject InfoUI;



    private void Awake()
    {
        inst = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameMgr.inst != null)
        {
            HealthT.text = GameMgr.inst.PlayerHealth.ToString();
            VelocityT.text = (Mathf.Round(GameMgr.inst.player.velocity.magnitude*10)*0.1).ToString() + " m/s";
            DebrisT.text = GameMgr.inst.Debris.ToString();
        }
        else
        {
            HealthT.text = "N/A";
            VelocityT.text = "N/A";
            DebrisT.text = "N/A";
        }
    }

    public void OnGameOver()
    {
        ScoreT.text = GameMgr.inst.Score.ToString();
        FinalDebrisT.text = GameMgr.inst.TotalDebrisCollected.ToString();
        FinalEnemiesDestroyedT.text = GameMgr.inst.TotalEnemiesDestroyed.ToString();


        GameOverUI.SetActive(true);
        InfoUI.SetActive(false);
    }
}
