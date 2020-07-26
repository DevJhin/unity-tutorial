using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            transform.position -= Vector3.forward;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            transform.position -= Vector3.right;
        }
    }
}
