using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start Called!");
    }

    void OnEnable()
    {
        Debug.Log("OnEnable Called!");
    }

    void OnDisable()
    {
        Debug.Log("OnDisable Called!");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update Called!");       
        transform.position += Vector3.forward*Time.deltaTime; 
    }


}
