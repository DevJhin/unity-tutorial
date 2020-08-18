using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{

    [Header("Explosion Settings")]
    public float ExplosionDelay;
    
    public float ExplosionRange;

    public float ExplosionForce;

    private float WaitTime;

    [Header("References")]
    public MeshRenderer BodyRenderer;
    public Collider BodyCollider;

    public Light BodyLight;

    public GameObject ExplodeParticleObject;

    private bool HasExploded;



    void Start()
    {
        HasExploded = false;

        WaitTime = 0;
        ExplodeParticleObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        WaitTime +=Time.deltaTime;

        if(!HasExploded && WaitTime >= ExplosionDelay)
        {
            Explode();
        }
        
        if(HasExploded)
        {
            BodyLight.intensity = Mathf.MoveTowards(BodyLight.intensity,0,14f*Time.deltaTime);
        }
    }


    /// <summary>
    /// Called when Grenade explodes.
    /// </summary>
    void Explode()
    {
        //Set state to exploded(Prevents duplicated explosion).
        HasExploded = true;

        //Detect colliders within explosion range.
        Collider[] colliders = Physics.OverlapSphere(transform.position, ExplosionRange);
        foreach(var collider in colliders)
        {
            Rigidbody rb = collider.attachedRigidbody;
            if(rb == null || collider == BodyCollider) continue;

            rb.AddExplosionForce(ExplosionForce, transform.position, ExplosionRange);
        }

        ExplodeParticleObject.SetActive(true);
        BodyRenderer.enabled = false;

        BodyLight.intensity = 8f;
        BodyLight.range = 8f;

        Destroy(gameObject, 3f);
    }


}
