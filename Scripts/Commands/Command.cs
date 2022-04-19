//Daniel Beeston
//dbees15@gmail.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Command
{
    public Entity381 entity;

    public Command(Entity381 ent)
    {
        entity = ent;
    }

    public virtual void Init()
    {

    }

    public virtual void Tick()
    {
        
    }

    public virtual bool IsDone()
    {
        return false;
    }

    public virtual void Stop()
    {

    }
}
