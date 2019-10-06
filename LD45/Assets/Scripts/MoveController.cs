using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{

    public Vector3 speedForward, speedBack, speedLeft, speedRight, camDrag;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(speedForward);
            CamDrag(6, 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(speedBack);
            CamDrag(6, 1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(speedLeft);
            CamDrag(6, 1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speedRight);
            CamDrag(6, 1);
        }
    }

    public void CamDrag(int power, float height)
    {
        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, height)/power, transform.position.z);
    }
}
