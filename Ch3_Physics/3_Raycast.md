# Raycast

##Raycast
게임 Scene에 존재하는 Collider를 감지하는 방법은 Collider끼리 충돌시키는 것 외에도 Raycast라는 방법을 사용할 수 있습니다.

Raycast는 한 지점에서 특정 방향으로 가상의 Ray를 쏴서, 그 Ray와 충돌하는 Collider가 있는지 검사하는 기능입니다. 레이캐스트는 RigidBody와 같은 다른 컴포넌트를 사용할 필요 없이 스크립트 상에서 쉽게 사용할 수 있기 때문에, 단순한 Collider 감지 기능이라면 Raycast를 사용하는 것이 매우 편리합니다.

##함수
1. origin: Ray의 시작 위치
2.

```cs
public static bool Raycast(Vector3 origin, Vector3 direction, float maxDistance = Mathf.Infinity, int layerMask = DefaultRaycastLayers);
```



```cs
void Update()
   {
      ///Ray와 Collider 와의 충돌 정보를 저장합니다.
       RaycastHit hit;



       if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
       {
           Debug.Log("Did Hit");
       }
       else
       {
           Debug.Log("Did not Hit");
       }
   }
```
