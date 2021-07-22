using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public float MoveSpeed;
    public float ScrollSpeed;
    public Vector2 MoveLimit;
    public Vector2 ZoomLimit;
    public Vector2 RotateLimit;

    void Update()
    {
        Vector3 position = transform.position;
        Vector3 rotation = transform.rotation.eulerAngles;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        position += (Vector3.right * horizontal + Vector3.forward * vertical) * MoveSpeed * Time.deltaTime;
        position.y -= scroll * ScrollSpeed * Time.deltaTime * 200f;
        position.x -= scroll * ScrollSpeed * Time.deltaTime * 100f;

        position.x = Mathf.Clamp(position.x, -MoveLimit.x, MoveLimit.x);
        position.z = Mathf.Clamp(position.z, -MoveLimit.y, MoveLimit.y);
        position.y = Mathf.Clamp(position.y, ZoomLimit.x, ZoomLimit.y);
        rotation.x = Mathf.Clamp(rotation.x, RotateLimit.x, RotateLimit.y);

        transform.position = position;
        transform.rotation = Quaternion.Euler(rotation);
    }
}
