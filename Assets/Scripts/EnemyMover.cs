using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public float Speed;
    public float Offset;
    private Rigidbody body;
    private Vector3 nextPosition;
    private int nextPointIndex;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        SetNextPosition();
    }

    void SetNextPosition()
    {
        nextPosition = Waypoints.Points[nextPointIndex++].position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Vector3.Distance(transform.position, nextPosition) >= Offset)
        {
            Vector3 direction = nextPosition - transform.position;
            Quaternion angle = Quaternion.LookRotation(direction);
            angle.x = 0;
            angle.z = 0;
            transform.rotation = angle;
            body.MovePosition(transform.position + transform.forward * Speed);
        }
        else
        {
            SetNextPosition();
        }
    }
}
