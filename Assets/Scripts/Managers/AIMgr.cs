//Daniel Beeston
//dbees15@gmail.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMgr : MonoBehaviour
{
    public static AIMgr inst;

    public float hitRadius = 50.0f;

    RaycastHit hit;
    int layerMask;



    private void Awake()
    {
        inst = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        layerMask = LayerMask.GetMask("Ocean");
    }



    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1) && SelectionMgr.inst.selectedEntity!=null)
        {
           if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit, float.MaxValue, layerMask))
            {
                //Debug.DrawLine(Camera.main.transform.position,hit.point,Color.red,5);
                Vector3 pos = hit.point;
                pos.y = 0;
                
                //Debug.DrawLine(pos, pos + Vector3.right * hitRadius, Color.blue, 5);

                Entity381 ent = Utils.findClosestEntity(pos, hitRadius);
                if(ent == SelectionMgr.inst.selectedEntity)
                {
                    SelectionMgr.inst.selectedEntity.GetComponent<UnitAI>().ClearCommands();
                    ent = null;
                }
                    

                if (ent == null)
                {
                    if(Input.GetKey(KeyCode.LeftAlt))
                    {
                        //teleport
                        HandleTeleport(pos);
                    }
                    else
                    {
                        //move
                        HandleMove(pos);
                    }
                }
                else
                {
                    if(Input.GetKey(KeyCode.LeftControl))
                    {
                        //intercept
                        HandleIntercept(ent);
                    }
                    else
                    {
                        //follow
                        HandleFollow(ent);
                    }
                }
            }
           else
            {

            }
        }
    }

    void HandleTeleport(Vector3 point)
    {
        Teleport teleport = new Teleport(SelectionMgr.inst.selectedEntity, point);
        UnitAI uai = SelectionMgr.inst.selectedEntity.GetComponent<UnitAI>();
        if(Input.GetKey(KeyCode.LeftShift))
        {
            uai.AddCommand(teleport);
        }
        else
        {
            uai.SetCommand(teleport);
        }
    }

    void HandleMove(Vector3 point)
    {
        Move movecommand = new Move(SelectionMgr.inst.selectedEntity, point);
        UnitAI uai = SelectionMgr.inst.selectedEntity.GetComponent<UnitAI>();
        if (Input.GetKey(KeyCode.LeftShift))
        {
            uai.AddCommand(movecommand);
        }
        else
        {
            print("move!");
            uai.SetCommand(movecommand);
        }
    }

    void HandleFollow(Entity381 target)
    {
        Follow followcommand = new Follow(SelectionMgr.inst.selectedEntity, target);
        UnitAI uai = SelectionMgr.inst.selectedEntity.GetComponent<UnitAI>();
        if (Input.GetKey(KeyCode.LeftShift))
        {
            uai.AddCommand(followcommand);
        }
        else
        {
            print("Follow!");
            uai.SetCommand(followcommand);
        }
    }

    void HandleIntercept(Entity381 target)
    {
        Intercept interceptcommand = new Intercept(SelectionMgr.inst.selectedEntity, target);
        UnitAI uai = SelectionMgr.inst.selectedEntity.GetComponent<UnitAI>();
        if (Input.GetKey(KeyCode.LeftShift))
        {
            uai.AddCommand(interceptcommand);
        }
        else
        {
            print("Intercept!");
            uai.SetCommand(interceptcommand);
        }
    }
}
