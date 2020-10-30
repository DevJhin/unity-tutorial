using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidpointExample : MonoBehaviour
{
    public GameObject firstObject;
    public GameObject secondObject;

    public GameObject midObject;

    void Update()
    {
        //GameObject의 transform에 접근하여 position 값을 가져옵니다.
        Vector3 firstPos = firstObject.transform.position;
        Vector3 secondPos = secondObject.transform.position;

        Vector3 midPos;

        //방법1: Vector3의 덧셈/나눗셈 활용
        midPos = (firstPos + secondPos)/2;

        //방법2: 두 지점 사이의 거리와 차이 벡터를 이용
        float distance = Vector3.Distance(firstPos, secondPos);
        Vector3 diffVector = (secondPos - firstPos).normalized;

        midPos = firstPos + diffVector * (distance/2);

        midObject.transform.position = midPos;
    }
}
