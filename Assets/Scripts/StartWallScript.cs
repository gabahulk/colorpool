using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWallScript : MonoBehaviour
{
    void Awake()
    {
        transform.position = new Vector3(0, -Util.GetScreenHeight(), 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
