    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMovementScript : MonoBehaviour
{
    public iTweenPath path;
    public float speed;
    public iTween.EaseType easeType;

    // Start is called before the first frame update
    void Start()
    {
       
        path.nodes[0] = this.transform.position;
        iTween.MoveTo(gameObject, iTween.Hash("path", path.nodes.ToArray(), "speed", speed, "loopType", "pingPong", "easeType", easeType));
    }
}
