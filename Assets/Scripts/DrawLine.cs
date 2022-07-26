using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform drawTo;
    private void Start()
    {
        if (lineRenderer == null) Debug.LogError("lineRenderer not assigned in editor");
        if (drawTo == null) Debug.LogError("drawTo not assigned in editor");

        lineRenderer.SetPosition(0, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(1, drawTo.transform.position);
    }
}
