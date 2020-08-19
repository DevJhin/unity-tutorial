using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBomb : MonoBehaviour
{
    [Header("Explosion Settings")]

    /// <summary>
    /// 폭발까지 걸리는 지연 시간.
    /// </summary>
    public float ExplosionDelay;

    /// <summary>
    /// 폭탄의 폭발 범위.
    /// </summary>
    public float ExplosionRange;

    /// <summary>
    /// 폭탄의 폭발력(폭발의 세기).
    /// </summary>
    public float ExplosionForce;


    [Header("References")]
    public MeshRenderer BodyRenderer;
    public Collider BodyCollider;

    public Light BodyLight;

    public GameObject ExplodeParticleObject;

    /// <summary>
    /// 타이머가 시작된 후, 경과한 시간을 기록합니다.
    /// </summary>
    private float currentTimer;

    /// <summary>
    /// 폭탄이 충돌하여 타이머가 시작되었는지 확인합니다.
    /// </summary>
    private bool isTimerStart;

    /// <summary>
    /// 이미 폭탄이 폭발한 상태인지 확인합니다.
    /// </summary>
    private bool hasExploded;


    void Start()
    {
        hasExploded = false;

        currentTimer = 0;
        ExplodeParticleObject.SetActive(false);
    }


    void Update()
    {
       //폭발 타이머가 시작되었을 경우
        if (isTimerStart)
        { 
            //현재 타이머 경과 시간을 업데이트 합니다.
            currentTimer +=Time.deltaTime;

            //타이머 시간이 충분히 경과했다면 폭발을 처리하는 함수를 호출합니다.
            //두 번 폭발하지 않도록 hasExploded 변수를 사용하여 이미 한 번 폭발한 상태인지 체크합니다.
            if (!hasExploded && currentTimer >= ExplosionDelay)
            {
                Explode();
            }

        }
        
        //폭발 한 뒤에 빛이 점점 희미해지는 효과를 연출합니다.
        if(hasExploded)
        {
            BodyLight.intensity = Mathf.MoveTowards(BodyLight.intensity,0,14f*Time.deltaTime);
        }
    }

    /// <summary>
    /// 이 오브젝트가 충돌했을 경우, 폭발 타이머를 시작합니다.
    /// </summary>
    private void OnCollisionEnter(Collision collision)
    {
        if (!hasExploded)
        {
            Explode();
        }
    }


    /// <summary>
    /// 폭탄이 폭발했을 때의 작업을 처리합니다.
    /// </summary>
    void Explode()
    {
        //Set state to exploded(Prevents duplicated explosion).
        hasExploded = true;

        //OverlapSphere를 사용하여 범위 내에 존재하는 모든 Collider의 배열을 가져옵니다.
        Collider[] colliders = Physics.OverlapSphere(transform.position, ExplosionRange);

        foreach(var collider in colliders)
        {
            Rigidbody rb = collider.attachedRigidbody;

            //어떤 Collider는 Rigidbody를 가지고 있지 않을 수 있습니다.
            //따라서 이 경우는 예외로 처리하여 아무런 작업을 수행하지 않습니다.
            if(rb == null || collider == BodyCollider) continue;

            //Collider가 Rigidbody를 가졌을 경우, 폭발 효과를 연출할 수 있도록 AddExplosionForce를 사용합니다.
            rb.AddExplosionForce(ExplosionForce, transform.position, ExplosionRange);
        }

        ExplodeParticleObject.SetActive(true);
        BodyRenderer.enabled = false;
        
        //폭발 시점에서의 Light 효과를 아주 밝게 설정합니다.
        BodyLight.intensity = 8f;
        BodyLight.range = 8f;

        Destroy(gameObject, 3f);
    }



}
