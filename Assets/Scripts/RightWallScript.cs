using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightWallScript : MonoBehaviour
{
    void Awake()
    {
        transform.position = new Vector3(Util.GetScreenWidth() , 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
