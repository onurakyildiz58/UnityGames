using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedApply : MonoBehaviour
{
    // 0 km/h  = 185 degree
    // 360 km/h = -80 degree

    public tachometer th;

    private const float minDegree = 185.0f;
    private const float maxDegree = -80.0f;

    private Transform stickDegree;
    public float maxSpeed;
    public float speed;

    public GameObject stick;

    private void Awake()
    {
        stickDegree = stick.transform;
        speed = 0;
    }
    
    void Update()
    {
        speed = th.speed;
        maxSpeed = th.maxSpeed;

        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }

        stickDegree.eulerAngles = new Vector3(0, 0, GetSpeedRatio());
    }

    public float GetSpeedRatio()
    {
        float maxTurn = minDegree - maxDegree;
        float speedNormalized = speed / maxSpeed;

        return minDegree - speedNormalized * maxTurn;
    }
}
