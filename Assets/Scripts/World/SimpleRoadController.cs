using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRoadController : MonoBehaviour
{

    public Transform DestPoint;

    public float StartY=0;

    private static int _speed=10;
    public static int _speedMultiplier = 1;
    public static int Speed { get { return _speed* _speedMultiplier; } private set { _speed = value; } }

    public static void Stop()
    {
        _speed = 0;
    }
    public static void Run()
    {
        _speed = 10;
    }

    void Start()
    {
        StartY = transform.position.y;
    }

    
    void FixedUpdate()
    {
        if(transform.position.x== DestPoint.position.x)
        {
            transform.position = new Vector3(0, StartY, 0);
        }
        transform.position = Vector3.MoveTowards(transform.position, DestPoint.position, Speed * Time.fixedDeltaTime);
    }
}
