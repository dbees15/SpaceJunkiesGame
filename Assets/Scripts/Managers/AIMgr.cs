

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMgr : MonoBehaviour
{
    public static AIMgr inst;

    //public float hitRadius = 50.0f;

    //RaycastHit hit;
    //int layerMask;

    private void Awake()
    {
        inst = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //layerMask = LayerMask.GetMask("Ocean");
        // enemies follow player
    }

    void HandleFollow(Entity381Advanced targetEnt)
    {
        //for (int i = 0; i < enemyList.Length; i++)
        //{
        //    Follow follow = new Follow(enemyList[i], targetEnt);
        //    UnitAI uai = enemyList[i].GetComponent<UnitAI>();

        //    if (Input.GetKey(KeyCode.LeftShift))
        //    {
        //        uai.AddCommand(follow);
        //    }
        //    else
        //    {
        //        uai.SetCommand(follow);
        //    }
        //}
    }



    // Update is called once per frame
    void Update()
    {
        //if(Input.GetMouseButtonDown(1) && SelectionMgr.inst.selectedEntity!=null)
        //{
        //   if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit, float.MaxValue, layerMask))
        //    {
        //        Vector3 pos = hit.point;
        //        pos.y = 0;

        //        Entity381 ent = Utils.findClosestEntity(pos, hitRadius);
        //        if(ent == SelectionMgr.inst.selectedEntity)
        //        {
        //            SelectionMgr.inst.selectedEntity.GetComponent<UnitAI>().ClearCommands();
        //            ent = null;
        //        }

    }

}
