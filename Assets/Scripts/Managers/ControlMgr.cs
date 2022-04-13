//Daniel Beeston
//dbees15@gmail.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMgr : MonoBehaviour
{

    public static ControlMgr inst;
    public float deltaSpeed = 1;
    public float deltaHeading = 4;

    private void Awake()
    {
        inst = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            Application.Quit();

        if(SelectionMgr.inst.selectedEntity != null)
        {
            if (Input.GetKeyUp(KeyCode.W)) 
                SelectionMgr.inst.selectedEntity.desiredSpeed += deltaSpeed;
            if (Input.GetKeyUp(KeyCode.S))
                SelectionMgr.inst.selectedEntity.desiredSpeed -= deltaSpeed;


            if (Input.GetKeyUp(KeyCode.A))
                SelectionMgr.inst.selectedEntity.desiredHeading -= deltaHeading;
            if (Input.GetKeyUp(KeyCode.D))
                SelectionMgr.inst.selectedEntity.desiredHeading += deltaHeading;

            SelectionMgr.inst.selectedEntity.desiredHeading = Utils.Degress360(SelectionMgr.inst.selectedEntity.desiredHeading);
        }

    }
}
