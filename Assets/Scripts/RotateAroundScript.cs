using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundScript : MonoBehaviour
{
    public Transform pivot;
    Vector3 previousPivotPosition;
    public float speed = 1;

    private void Start()
    {
        previousPivotPosition = pivot.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pivotDelta = pivot.position - previousPivotPosition;
        transform.RotateAround(pivot.position, Vector3.forward, speed * Time.deltaTime);
    }
}