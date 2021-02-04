using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public LayerMask layerMask;
    public LayerMask finisPointLayer;
    public float initialImpactRadius=0.015f;
    [SerializeField] private GamePlayEventHubSO gamePlayEvents = default;

    [SerializeField] private float projectileInitialSize;
    private Vector3 impactPoint = Vector3.negativeInfinity;
  
    private float projectileSpeed = 5f;

    //public Projectile projectile;
    private float elapsedTime = 0f;
    private float initialScale = 0.2f;
    private float increaseRadiusStep = 0.015f;

    [SerializeField] float projectileScalingSpeed = 4f;

    private void Start()
    {
        this.transform.localScale = new Vector3(initialScale, initialScale, initialScale);
  
    }

    private void OnTriggerEnter(Collider other)
    {
        ///other.gameObject.GetComponent<Renderer>().material.color = Color.green;
       
        ExplosionDamage(other.transform.position, initialImpactRadius);
        impactPoint = other.transform.position;
        ///  collider.GetComponent<SphereCollider>().enabled = false;
        //this.gameObject.SetActive(false);
      
        Destroy(this.gameObject);
    }

    void ExplosionDamage(Vector3 center, float radius)
    {

        ////int layerMask = LayerMask.NameToLayer(" ");
        Collider[] hitColliders = Physics.OverlapSphere(center, radius,  layerMask);
        foreach (var hitCollider in hitColliders)
        {
            /// hitCollider.gameObject.GetComponent<Renderer>().material.color = Color.green;
            //hitCollider.gameObject.SetActive(false);
            if (hitCollider.gameObject.layer != finisPointLayer)
                hitCollider.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            Destroy(hitCollider.gameObject);
           

        }
        gamePlayEvents.ProjectileDestoryed();
    }

  
    public void ResizeProjectile( )
    {
         //projectile =  GetComponent<Projectile>();
        StartCoroutine(nameof(GrowProjectile));
        StartCoroutine(nameof(IncreaseImpactRadius));
    }


    public void IncreaseImpactRadius()
    {
 
        StartCoroutine(nameof(IncreaseImpactRadiusCor));
    }
    private IEnumerator GrowProjectile(  )
    {
        float step =- 0.1f;

        while (true)
        {
            Vector3 startScale = this.transform.localScale;
            Vector3 endScale = new Vector3(startScale.x * (1 - step), startScale.y * (1 - step), startScale.z * (1 - step));
            this.transform.localScale = Vector3.Lerp(startScale, endScale, projectileScalingSpeed * Time.deltaTime);
            yield return null;
        }
    }
 

    public void Launch(Vector3 target)
    {
        StopCoroutine(nameof(GrowProjectile));
        Vector3 shootDirection = (target - this.transform.position).normalized;

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(shootDirection * projectileSpeed, ForceMode.Impulse);
        StopCoroutine(nameof(IncreaseImpactRadiusCor));
    }

    private IEnumerator IncreaseImpactRadiusCor()
    {
         

        while (true)
        {
            initialImpactRadius += increaseRadiusStep;
            yield return null;
        }
    }

    private void OnDrawGizmos()
    {
        if (impactPoint.Equals(Vector3.negativeInfinity)) return;
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(impactPoint, initialImpactRadius);
    }
}
