using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("충돌이 시작되었습니다.");
    }

    void OnCollisionStay(Collision collision)
    {
        Debug.Log("충돌 상태가 유지되고 있습니다.");
    }

    void OnCollisionExit(Collision collision)
    {
        Debug.Log("충돌 상태에서 벗어났습니다.");
    }
}
