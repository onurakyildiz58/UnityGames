using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackRender : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private GameObject TrackPath;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        TrackPath = this.gameObject;

        int numofpath = TrackPath.transform.childCount;
        lineRenderer.positionCount = numofpath + 1;

        for (int x = 0; x < numofpath; x++)
        {
            lineRenderer.SetPosition(x, new Vector3(TrackPath.transform.GetChild(x).transform.position.x, 4, TrackPath.transform.GetChild(x).transform.position.z));
        }

        lineRenderer.SetPosition(numofpath, lineRenderer.GetPosition(0));

        lineRenderer.startWidth = 7f;
        lineRenderer.endWidth = 7f;
    }

    void Update()
    {
        
    }
}
