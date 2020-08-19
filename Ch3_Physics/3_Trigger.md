# 충돌 판정
앞에서 물리적 성질을 정의하는 RigidBody와 물리적 형태를 정의하는 Collider에 대해 배웠으니, 이제는 두 오브젝트 간의 충돌을 만들 수 있습니다.

유니티 엔진에서 오브젝트 간의 충돌을 발생시키기 위해서는 반드시 아래의 조건들을 모두 만족해야 합니다.

  1. 두 오브젝트 중 하나는 반드시 활성화된 RigidBody를 가지고 있어야 한다.
  2. 두 오브젝트 모두 Collider를 가지고 있어야 한다.


## Collision 이벤트 함수

모든 Collision 이벤트 함수는 충돌이 발생했을 때의 정보를 가지고 있는 Collision 객체를 전달받습니다. Collision 객체는 아래

### OnCollisionEnter
다른 Collider와의 충돌 상태가 처음 시작되었을 때 호출됩니다.

### OnCollisionStay
다른 Collider와의 충돌 상태가 유지되는 동안 계속 호출됩니다.

### OnCollisionExit
다른 Collider와의 총돌 상태에서 빠져나왔을 때 호출됩니다.






## Trigger
Collider를 Trigger 모드로 설정할 수 있습니다.
Trigger는 일반 Collider와는 다르게 충돌 판정을 할 때, 다른 Collider와의 충돌여부만을 판단합니다. 즉, 어느 지점/어떤 방향에서 충돌이 발생했는지, 그리고 작용/반적용과 같은 구체적인 물리적인 효과는 고려하지 않습니다.

1. 두 오브젝트 중 하나는 반드시 활성화된 RigidBody를 가지고 있어야 한다.
2. 두 오브젝트 모두 Collider를 가지고 있어야 한다.

## Trigger vs Collision
Trigger와 Collision 모두 두 콜라이더 사이의 충돌을


Trigger는 **게임에서 캐릭터가 특정 영역에 도달했을 때, 특정 이벤트를 실행하는 기능** 처럼, 단순히 Collider 간에 충돌이 발생했는지만 확인하면 되는 상황에서 사용하기에 아주 적합합니다.



하지만, 만약 캐릭터가 해당 영역에서 부딪혀서 튀

## Trigger 이벤트 함수

모든 Trigger 이벤트 함수는 자신이 충돌한 Collider를 인수로 받습니다.

### OnTriggerEnter
Trigger가 다른 Collider와의 충돌 상태가 처음 시작되었을 때 호출됩니다.

### OnTriggerStay
Trigger기 다른 Collider와의 충돌 상태가 유지되는 동안 계속 호출됩니다.

### OnTriggerExit
Trigger가 다른 Collider와의 총돌 상태에서 빠져나왔을 때 호출됩니다.
