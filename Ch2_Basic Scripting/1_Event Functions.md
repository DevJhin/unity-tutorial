#	유니티 C# 스크립팅 기초
## 유니티 이벤트 함수

우리가 작성한 스크립트를 엔진과 함께 잘 작동하도록 하는 것은 쉬운 일이 아닙니다. 스크립트를 유니티 엔진의 산더미 같은 소스코드 중간에 끼워넣을 수도 없는 노릇입니다.

이러한 상황을 해결하기 위해 유니티 엔진에서는 **이벤트** 함수라는 것이 존재합니다.

이벤트 함수는 우리가 작성한 코드가 유니티 엔진의 게임 루프에 맞추어 실행될 수 있도록 유니티 엔진에서 정의한 함수입니다. 유니티 엔진이 알아서 이 함수들을 감지해서 정해진 타이밍에 해당 함수를 실행하기 때문에, 이들 이벤트 함수들을 몇가지 익혀두기만 하면 우리가 작성한 코드가 유니티 엔진과 함께 잘 돌아가게 만들 수 있습니다.

## 종류
### 1.	`Start()`
게임이 시작되었을 때, 또는 오브젝트가 처음 생성되었을 때 실행되는 함수입니다.

  ```cs
  void Start()
  {
    //Do Something on initialization.
  }
  ```

### 2.	`Update()`
매 프레임마다 실행되는 함수입니다.
오브젝트의 이동과 같이, 매 프레임마다 갱신되어야 하는 작업은 Update에서 처리합니다.

  ```cs
  //Do Something by every frame.
  void Update()
  {
    transform.position += Vector3.Up;
  }
  ```

### 3. `OnEnable()/OnDisable()`
  컴포넌트(스크립트)가 활성화/비활성화 되었을 때 실행되는 함수입니다.

  유니티에서는 필요에 따라서 컴포넌트를 활성화 또는 비활성화 하는 것이 가능합니다.
  컴포넌트를 활성화/비활성화 시키려면 아래와 같이 Editor에서 체크박스를 클릭하는 방법도 있으며

![](images/script_enable.png)

  아니면, 스크립트를 통해 활성화/비활성화 시키는 방법도 있습니다.

  ```cs

  public RigidBody rigidBody;

  void Start()
  {
    //Rigidbody 컴포넌트를 비활성화 시킨다.
    rigidBody.enabled = false;
  }


  ```

  하지만, 스크립트의 상태가 전환될 때 마다 특정 작업을 수행해야 하는 상황이 있습니다. 따라서, 이런 상황을 대처하기 위해, 유니티 엔진에서는 `OnEnable`과 `OnDisable`함수가 마련되어 있습니다.

```cs
  void OnEnable()
  {
      //Do Something on enable.
  }

  void OnDiable()
  {
      //Do Something on disable.
  }
```

**알아두세요**
> 앞서 설명드린 이벤트 함수들은 사실 많이 쓰이는 몇가지만 뽑은 것으로, 이 외에도 다양한 상황에서 활용할 수 있는 다양한 이벤트 함수들이 존재합니다.

> 특히, `OnTriggerEnter/Stay/Exit`, `OnCollsionEnter/Stay/Exit`과 같이 충돌판정과 관련된 **물리 이벤트 함수** 들은 여기서 다루지 않고, 이후의 **'Physics'** 챕터에서 더 자세히 다루도록 하겠습니다.


## 예제:



## 비고
사실, 유니티 엔진의 Event 함수의 종류는 앞서 소개한 것들보다 훨씬 많이 존재합니다.

`Awake()`, `FixedUpdate()`, `LateUpdate()` 등의 다양한 상황에서 실행되는 다른 event 함수들이 존재하지만,
간단한 작업이라면 위의 `Start()`, `Update()`만으로도 충분하기 때문에 지금은 다루지 않도록 하겠습니다.


유니티 엔진의 이벤트 함수에 대한 더 자세한 내용이 알고싶으시다면 관련 [Unity API](https://docs.unity3d.com/Manual/ExecutionOrder.html)를 확인하시기 바랍니다.  
