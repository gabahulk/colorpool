using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    public static float GetScreenWidth()
    {
        var pos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
        return pos.x;
    }


    public static float GetScreenHeight()
    {
        var pos = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
        return pos.y;
    }
}
