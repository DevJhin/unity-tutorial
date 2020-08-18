using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 마우스 포인터의 위치
/// </summary>
public class GrenadeLocater : MonoBehaviour
{
    Camera Cam;

    LayerMask FloorLayerMask;

    public GameObject LocaterUI;
    public GameObject Grenade;

    void Start()
    {
        //현재 사용 중인 카메라를 참조합니다.
        Cam = Camera.main;
        
        //특정 Collider에 대해서만 Raycast를 수행할 수 있도록
        FloorLayerMask = LayerMask.GetMask("Floor");

        LocaterUI.SetActive(false);
    }

    void Update()
    {
        //왼쪽 마우스 버튼을 누르는 동안 실행.
        if(Input.GetMouseButton(0))
        {
            //화면 위의 마우스 포인터 위치 
            Ray ray = ScreenPosToRay();

            //Raycast 충돌 시, 충돌 정보를 저장합니다.
            RaycastHit hitInfo;
            if(Physics.Raycast(ray, out hitInfo, 100f, FloorLayerMask))
            {
                //Raycast가 충돌한 바닥 지점
                Vector3 hitPoint = hitInfo.point;

                //충돌 지점을 표시하는 UI를 활성화하고 해당 지점에 배치.
                LocaterUI.SetActive(true);
                LocaterUI.transform.position = hitPoint;

                //스페이스 키를 누르면, Raycast 충돌 지점에 Grenade를 낙하시킵니다.
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    Vector3 locatePoint = hitPoint;
                    locatePoint.y+=3f;
                    
                    Grenade.transform.position = locatePoint;
                    Grenade.SetActive(true);
                    
                    //Grenade 배치 후, 이 컴포넌트를 비활성화한다.
                    this.enabled = false;                    
                }
            }
            else
            {
                LocaterUI.SetActive(false);
            }
        }
        else{
            LocaterUI.SetActive(false);
        }
    }

    public Ray ScreenPosToRay()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 viewportPoint = Cam.ScreenToViewportPoint(mousePosition);

        return Cam.ViewportPointToRay(viewportPoint);
    }

}
