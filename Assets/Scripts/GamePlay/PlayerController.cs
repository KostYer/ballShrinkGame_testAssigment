
using System.Collections;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
 
  
    [SerializeField] private GamePlayEventHubSO gamePlayEventHub = default;
    [SerializeField] private InputEventHubSO inputEventHubSO = default;
    [SerializeField] private float stopDistance =1f; //stop distance from moving ball to obstacle
    [SerializeField] GameObject pr_projectile = default;
    [SerializeField] private float movementSpeed = 1f;

    //private PlayerAnimation playerAnimation;

    [Range(0.0f, 1f)]
    public float deathScale;
    private Vector3 startScale;

    public Transform shootPoint;
    [SerializeField] InputListener inputListener;

    public LayerMask InteractableLayers; /*obstacles, finish*/


    [SerializeField]  float ballScalingSpeed = 1f;


  
    void Start()
    {
        startScale = transform.localScale;
        

}

public void ShrinkBall()
    {
        StartCoroutine(nameof(ShrinkBallCor)); 
    
    }
    private IEnumerator ShrinkBallCor()
    {
        float step = 0.1f;
      

        while (true)
        {
            Vector3 startScale = transform.localScale;
            Vector3 endScale = new Vector3(startScale.x * (1 - step), startScale.y * (1 - step), startScale.z * (1 - step));

            transform.localScale = Vector3.Lerp(startScale, endScale, ballScalingSpeed * Time.deltaTime);

            if (transform.localScale.x <= deathScale) { OnPlayerDied(); }
            gamePlayEventHub.PlayerResized();
            yield return null;
        }
    }

    public void StopBallShrink()
    {
        StopCoroutine(nameof(ShrinkBallCor));
      
      
    }

    public void MovePlayerFurther(Vector3 derection, Transform closestObstacle)
    {
        StartCoroutine(MoveBallCor(derection, closestObstacle));
 


    }

    private IEnumerator MoveBallCor(Vector3 direction, Transform closestObstacle)
    {

        float step = movementSpeed * Time.deltaTime;
        while (Vector3.Distance(transform.position, closestObstacle.transform.position) >= stopDistance)
        {

            transform.position = Vector3.Lerp(transform.position, transform.position+direction, step);
            gamePlayEventHub.BallChangedPosition();
            yield return null;
             
        }

    }


    public void MoveToLevelFinish(Transform levelFinish)
    {
        StartCoroutine(nameof(MoveToFinish), levelFinish);
       

    }

    private IEnumerator MoveToFinish(Transform levelFinish)
    {
     
        float dist = Vector3.Distance(transform.position, levelFinish.position);
        while (Vector3.Distance(transform.position, levelFinish.position) >= 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, levelFinish.position, movementSpeed * Time.deltaTime);
            gamePlayEventHub.BallChangedPosition();
            yield return null;
        }
      
        gamePlayEventHub.LevelFinished();
    }

        private void  OnPlayerDied()
    {
        gamePlayEventHub.PlayerDied();
        Debug.Log("player died");
    }

     



}

 
 