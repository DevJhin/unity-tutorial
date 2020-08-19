using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Raycast 기능을 사용하여 Floor에 폭탄 배치 지점을 지정하는 클래스.
/// </summary>
public class GrenadeLocater : MonoBehaviour
{
    public GameObject LocaterUI;
    public GameObject Grenade;


    ///현재 플레이어 카메라
    private Camera Cam;

    ///바닥 레이어
    private LayerMask FloorLayerMask;
    
    void Start()
    {
        //현재 사용 중인 카메라를 참조합니다.
        Cam = Camera.main;
        
        //특정 Collider(Floor)에 대해서만 Raycast가 수행되도록 레이어 마스크를 설정해줍니다. 
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
                    
                    //Grenade 배치 후, 이 컴포넌트를 비활성화합니다.
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

    /// <summary>
    /// 화면 상에서의 마우스 포인터의 위치를 World 상에서의 Ray로 변환합니다.
    /// </summary>
    /// <returns></returns>
    public Ray ScreenPosToRay()
    {
        Vector3 mousePosition = Input.mousePosition;
        // 마우스 포인터 위치를 뷰포트 공간으로 변환합니다.
        Vector3 viewportPoint = Cam.ScreenToViewportPoint(mousePosition);

        //변환한 뷰포트 위치에서 시작하는 Ray를 계산합니다.
        return Cam.ViewportPointToRay(viewportPoint);
    }

}
