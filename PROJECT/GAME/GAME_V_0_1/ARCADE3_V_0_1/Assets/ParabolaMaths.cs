using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ParabolaMaths
{
    public static Vector2 V2Parabola(Vector2 start, Vector2 end, float height, float t)
    {
        Func<float, float> f = x => -4 * height * x * x + 4 * height * x;

        //Interpolation
        var mid = Vector2.Lerp(start, end, t);

        //                             Interpolation StartPos EndPos Time
        return new Vector2(mid.x, f(t) + Mathf.Lerp(start.y, end.y, t));
    }

    public static Vector3 V3Parabola(Vector3 start, Vector3 end, float height, float t)
    {

        Func<float, float> f = x => -4 * height * x * x + 4 * height * x;
        
        //Interpolation
        var mid = Vector3.Lerp(start, end, t);

        //                             Interpolation StartPos EndPos Time  Midpos
        return new Vector3(mid.x, f(t) + Mathf.Lerp(start.y, end.y, t), mid.z);
    }

}
