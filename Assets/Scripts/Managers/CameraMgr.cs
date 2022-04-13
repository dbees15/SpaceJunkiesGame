//Daniel Beeston
//dbees15@gmail.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMgr : MonoBehaviour
{
    public static CameraMgr inst;

    private void Awake()
    {
        inst = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }


    public GameObject RTSCameraRig;

    public GameObject YawNode;      //child of RTSCameraRig
    public GameObject PitchNode;    //child of YawNode
    public GameObject RollNode;     //child of PitchNode
    //Camera is child of RollNode

    public float cameraMoveSpeed = 1.0f;
    public float cameraTurnSpeed = 1.0f;

    public Vector3 CurrentYawEulerAngles = Vector3.zero;
    public Vector3 CurrentPitchEulerAngles = Vector3.zero;

    public bool isRTSMode = true;

    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            YawNode.transform.Translate(Vector3.forward * Time.deltaTime * cameraMoveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            YawNode.transform.Translate(Vector3.back * Time.deltaTime * cameraMoveSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            YawNode.transform.Translate(Vector3.left * Time.deltaTime * cameraMoveSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            YawNode.transform.Translate(Vector3.right * Time.deltaTime * cameraMoveSpeed);
        }

        if (Input.GetKey(KeyCode.R))
        {
            YawNode.transform.Translate(Vector3.up * Time.deltaTime * cameraMoveSpeed);
        }
        if (Input.GetKey(KeyCode.F))
        {
            YawNode.transform.Translate(Vector3.down * Time.deltaTime * cameraMoveSpeed);
        }


        CurrentYawEulerAngles = YawNode.transform.localEulerAngles;
        if (Input.GetKey(KeyCode.Q))
        {
            CurrentYawEulerAngles.y -= cameraTurnSpeed * Time.deltaTime;   
        }
        if (Input.GetKey(KeyCode.E))
        {
            CurrentYawEulerAngles.y += cameraTurnSpeed * Time.deltaTime;
        }
        YawNode.transform.localEulerAngles = CurrentYawEulerAngles;

        CurrentPitchEulerAngles = PitchNode.transform.localEulerAngles;
        if (Input.GetKey(KeyCode.Z))
        {
            CurrentPitchEulerAngles.x -= cameraTurnSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.X))
        {
            CurrentPitchEulerAngles.x += cameraTurnSpeed * Time.deltaTime;
        }

        PitchNode.transform.localEulerAngles = CurrentPitchEulerAngles;


        if(Input.GetKeyUp(KeyCode.C))
        {
            isRTSMode = !isRTSMode;
            changeCamera();
        }

    }

    public void changeCamera()
    {
        if (!isRTSMode && (SelectionMgr.inst.selectedEntity != null))
        {
            YawNode.transform.SetParent(SelectionMgr.inst.selectedEntity.cameraRig.transform);
            YawNode.transform.localPosition = Vector3.zero;
            YawNode.transform.localEulerAngles = Vector3.zero;
            PitchNode.transform.localEulerAngles = Vector3.zero;

        }
        else
        {
            YawNode.transform.SetParent(RTSCameraRig.transform);
            YawNode.transform.localPosition = Vector3.zero;
            YawNode.transform.localEulerAngles = Vector3.zero;
            PitchNode.transform.localEulerAngles = Vector3.zero;
        }
    }
}
