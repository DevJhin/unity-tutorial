# 충돌 판정
앞에서 물리적 성질을 정의하는 RigidBody와 물리적 형태를 정의하는 Collider에 대해 배웠으니, 이제는 두 오브젝트 간의 충돌을 만들 수 있습니다.

유니티 엔진에서 오브젝트 간의 충돌을 발생시키기 위해서는 아래의 조건들을 모두 만족해야 합니다.

  1. 두 오브젝트 중 하나는 반드시 활성화된 RigidBody를 가지고 있어야 한다.
  2. 두 오브젝트 모두 Collider를 가지고 있어야 한다.


## Collider vs Trigger
Collider 에서 `IsTrigger`로 ㅅ Trigger 모드로 설정할 수 있습니다.

Collider는


반면, Trigger는 두 콜라이더가 충돌 했는지,


Collider를 Trigger모드로 설정했을 경우, 충돌이 발생했는지 안 했는지만 판단합니다.

## Collision 이벤트 함수

i.	OnTriggerEnter/Stay/Exit



ii.	OnCollisionEnter/Stay/Exit
D.	물리 Fuction
i.	Raycast
ii.
예제: Grenade Gun
