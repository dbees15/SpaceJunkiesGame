//Daniel Beeston
//dbees15@gmail.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAI : MonoBehaviour
{
    public List<Command> commandList;

    // Start is called before the first frame update
    void Start()
    {
        commandList.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        if(commandList.Count > 0)   //check if list is empty
        {
            if(!commandList[0].IsDone())    //tick if command isn't done
            {
                commandList[0].Tick();
            }   
            else                            //remove if command is done
            {
                commandList[0].Stop();
                commandList.RemoveAt(0);
            }
            
        }
    }


    public void AddCommand(Command cmd)    //add command to list
    {
        print("Added Command!");
        commandList.Add(cmd);
    }

    public void SetCommand(Command cmd)    //clear list and set command to cmd
    {
        ClearCommands();
        commandList.Add(cmd);
    }

    public void ClearCommands()
    {
        if (commandList.Count > 0)
        {
            commandList[0].Stop();
        }
        commandList.Clear();
    }

}
