//Daniel Beeston
//dbees15@gmail.com

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{

    public static float EPSILON = 0.01f;
    public static bool ApproximatelyEqual(float a, float b)
    {
        return (Mathf.Abs(a - b) < EPSILON);
    }

    public static float Clamp(float val, float min, float max)
    {
        if (val < min)
            val = min;
        if (val > max)
            val = max;
        return val;
    }

    public static float AngleDiffPosNeg(float a, float b)
    {
        float diff = a - b;
        if (diff > 180)
            return diff - 360;
        if (diff < -180)
            return diff + 360;
        return diff;
    }

    public static float Degress360(float angleDegrees)
    {
        if (angleDegrees >= 360)
            angleDegrees -= 360;
        if (angleDegrees < 0)
            angleDegrees += 360;
        return angleDegrees;
    }

    public static Entity381 findClosestEntity(Vector3 Point, float radius)
    {
        Entity381 minent = null;
        float _min = float.MaxValue;
        foreach (Entity381 ent in EntityMgr.inst.entities)
        {
            float distance = Vector3.Distance(ent.position, Point);
            if(distance < radius)
            {
                if (distance < _min)
                {
                    _min = distance;
                    minent = ent;
                }
            }


        }

        return minent;

    }
}
