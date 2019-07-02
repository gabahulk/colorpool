using UnityEngine;

public class EndWallScript : MonoBehaviour
{
    void Awake()
    {
        transform.position = new Vector3(0, Util.GetScreenHeight(), -1);
    }
}
