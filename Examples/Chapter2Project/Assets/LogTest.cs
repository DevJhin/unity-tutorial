using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello, Log!");
        Debug.LogWarning("Hello, LogWarning!");
        Debug.LogError("Hello, LogError!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
