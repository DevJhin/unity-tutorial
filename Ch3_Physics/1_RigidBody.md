# Intro
물리 효과를 활용할 수 있는 대표적인 Component를 사용하는 방법

## Rigidbody




### Force

### AddForce
Rigidbody를 통해서 물체에 물리적 힘을 가하는 효과를 만들 수 있습니다. 예를 들어, 공을 던지거나 포탄을 발사하는 효과를 만들 때 사용할 수 있습니다.

```cs
public class ExampleClass : MonoBehaviour
{
    public float thrust = 1.0f;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddForce(transform.forward * thrust);
    }
}
```

### AddExplosionForce
Rigibody에 **폭발** 효과를 연출할 수 있는 힘을 가합니다. 예를 들어, 폭탄이 폭발할 때 주변 물체가 폭발에 휩쓸려 날아가는 효과를 만들어낼 때 사용할 수 있습니다. AddExplosionForce 함수는 기본적으로 아래의 3가지  

|Arguments|설명|
|-|-|
|explosionForce|폭발력. 폭발 지점에서 나오는 힘의 세기|
|explosionPosition	|폭발이 시작되는 중심 위치.|
|explosionRadius| 폭발 최대 반경. 즉, 폭발력이 미치는 힘의 범위.|
```cs
// Applies an explosion force to all nearby rigidbodies
public class ExampleClass : MonoBehaviour
{
    public float radius = 5.0F;
    public float power = 10.0F;

    void Start()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius);
        }
    }
}
```


#### 예제: TimeBomb 폭발 효과
앞에서 배운 내용을 활용해서 바닥이나 벽 등 주변 물체에 부딪히면 일정시간 뒤에 폭발하는 시한 폭탄을 만들어 봅시다.





### Physics 클래스
유니티 엔진에서는 물리 효과를 사용할 수 있는
