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

    public Text nameT;
    public Text speedT;
    public Text desiredspeedT;
    public Text headingT;
    public Text desiredheadingT;

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
        if(SelectionMgr.inst.selectedEntity != null)
        {
            nameT.text = SelectionMgr.inst.selectedEntity.name;
            speedT.text = SelectionMgr.inst.selectedEntity.speed.ToString();
            desiredspeedT.text = SelectionMgr.inst.selectedEntity.desiredSpeed.ToString();
            headingT.text = SelectionMgr.inst.selectedEntity.heading.ToString();
            desiredheadingT.text = SelectionMgr.inst.selectedEntity.desiredHeading.ToString();
        }
        else
        {
            nameT.text = "N/A";
            speedT.text = "N/A";
            desiredspeedT.text = "N/A";
            headingT.text = "N/A";
            desiredheadingT.text = "N/A";
        }
    }
}
