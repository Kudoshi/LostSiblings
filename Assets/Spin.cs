using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float turnSpeed;
    public bool turnLeft;
    // Start is called before the first frame update
    void Start()
    {
        if (turnLeft)
            turnSpeed = -turnSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right * turnSpeed * Time.deltaTime, Space.Self);
    }
}
