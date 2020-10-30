using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

   void Update(){
   // Space 키 눌렀을 때 한 번 실행
   if(Input.GetKeyDown(KeyCode.Space))
   {
       Debug.Log("Space Pressed!");
   }
   // Space 키를 누르는 중에 계속 실행
   else if(Input.GetKey(KeyCode.Space))
   {
       Debug.Log("Space Pressing!");
   }
   // Space 키를 누르다가 놓았을 때 한 번 실행
   else if(Input.GetKeyUp(KeyCode.Space))
   {
       Debug.Log("Space Released!");
   }
 }
}
