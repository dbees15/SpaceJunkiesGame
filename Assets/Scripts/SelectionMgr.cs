//Daniel Beeston
//dbees15@gmail.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionMgr : MonoBehaviour
{
    
    public static SelectionMgr inst;

    public int selectedEntityIndex = 0;
    public Entity381 selectedEntity;

    public List<Entity381> entityList;
    public Entity381 closestEntity;
    public float radius = 10.0f;
    public Vector3 intersectionPoint = Vector3.zero;



    private void Awake()
    {
        inst = this;
    }
    /*
    // Start is called before the first frame update
    void Start()
    {
        foreach (Entity381 ent in EntityMgr.inst.entities)
        {
            ent.selectionCylinder.SetActive(false);
            selectedEntity.selectionCylinder.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            SelectNextEntity();
            if(!CameraMgr.inst.isRTSMode)
                CameraMgr.inst.changeCamera();
        }

        RaycastHit hit;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            print("Clicked!");
            
            entityList.Clear();

            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit, Mathf.Infinity))
            {
                intersectionPoint = hit.point;

                for(int i=0;i<EntityMgr.inst.entities.Count; i++)
                {
                    Entity381 Obj = EntityMgr.inst.entities[i];
                    if (Vector3.Distance(intersectionPoint, EntityMgr.inst.entities[i].position) < radius)
                    {
                        entityList.Add(EntityMgr.inst.entities[i]);
                    }

                }
                if(entityList.Count > 0)
                {
                    closestEntity = findClosestEntity(intersectionPoint);
                    SelectClosestEntity(closestEntity);
                }
                else
                {
                    closestEntity = null;
                    UnSelectAll();
                    selectedEntity = null;
                }
            }
            else
            {
                closestEntity = null;
                UnSelectAll();
                selectedEntity = null;

            }


        }

            
    }

    public void SelectNextEntity()
    {
        selectedEntityIndex = (selectedEntityIndex >= EntityMgr.inst.entities.Count - 1? 0 : selectedEntityIndex + 1);
        selectedEntity = EntityMgr.inst.entities[selectedEntityIndex];
        UnSelectAll();
        selectedEntity.isSelected = true;
        selectedEntity.selectionCylinder.SetActive(true);
    }

    public void UnSelectAll()
    {
        foreach (Entity381 ent in EntityMgr.inst.entities)
        {
            ent.isSelected = false;
            ent.selectionCylinder.SetActive(false);
        }
            
    }

    public Entity381 findClosestEntity(Vector3 IntersectionPoint)
    {
        Entity381 ety = selectedEntity;
        float _min = float.MaxValue;
        for(int i=0; i<entityList.Count; i++)
        {
            if(Vector3.Distance(IntersectionPoint,entityList[i].position) < _min)
            {
                _min = Vector3.Distance(IntersectionPoint, entityList[i].position);
                ety = entityList[i];
            }
        }
        return ety;
        
    }

    public void SelectClosestEntity(Entity381 ety)
    {
        selectedEntity = ety;
        UnSelectAll();
        selectedEntity.isSelected = true;
        ety.selectionCylinder.SetActive(true);
    }
    */
}

