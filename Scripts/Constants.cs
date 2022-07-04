using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{
    public static float FLOOR_LEVEL = 0.125f;

    public static Vector3 getGroundedVector3(Vector3 v)
    {
        return new Vector3(v.x, FLOOR_LEVEL, v.z);
    }
}
